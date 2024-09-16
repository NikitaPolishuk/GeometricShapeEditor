using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum ShapeType
{
    parallelepiped,
    prism,
    sphere,
    capsule
}

namespace Asset.Scripts.Controller
{
    public class ShapesController : MonoBehaviour
    {
        [SerializeField] Transform _prismPivot;
        [SerializeField] Transform _spherePivot;
        [SerializeField] Transform _capsulePivot;
        [SerializeField] Transform _parallelepipedPivot;

        private IShapeFactory _prismFactory;
        private IShapeFactory _parallelepipedFactory;
        private Dictionary<ShapeType, IShape> _shapes = new Dictionary<ShapeType, IShape>();

        public Action<Dictionary<ShapeType, IShape>> ChangeShapes—ount;


        public void Init(IShapeFactory prismFactory, IShapeFactory parallelepipedFactory)
        {
            _prismFactory = prismFactory;
            _parallelepipedFactory = parallelepipedFactory;
        }

        public void GenerateShape(ShapeType shapeType, params object[] meshParameters)
        {
            if (_shapes.TryGetValue(shapeType, out var shape))
            {
                shape.UpdateMesh(meshParameters);
                return;
            }

            switch (shapeType)
            {
                case ShapeType.parallelepiped:
                    shape = _parallelepipedFactory.CreateShape(_parallelepipedPivot);
                    break;
                case ShapeType.prism:
                    shape = _prismFactory.CreateShape(_prismPivot);
                    break;
                case ShapeType.sphere:
                    break;
                case ShapeType.capsule:
                    break;
            }

            shape.UpdateMesh(meshParameters);
            _shapes.Add(shapeType, shape);
            ChangeShapes—ount?.Invoke(_shapes);
        }

        public void PaintShape(ShapeType shapeType, Color color)
        {
            if (_shapes.TryGetValue(shapeType, out var shape))
            {
                shape.Paint(color);
            }
        }

        public void DestroyShape(ShapeType shapeType)
        {
            if (_shapes.TryGetValue(shapeType, out var shape))
            {
                shape.Destroy();
                _shapes.Remove(shapeType);
            }

            ChangeShapes—ount?.Invoke(_shapes);
        }
    }
}
