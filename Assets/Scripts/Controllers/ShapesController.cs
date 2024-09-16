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
        private IShapeFactory _sphereFactory;
        private IShapeFactory _capsuleFactory;
        public Dictionary<ShapeType, IShape> Shapes { get; private set; }

        public Action<Dictionary<ShapeType, IShape>> ChangeShapes—ount;


        public void Init(IShapeFactory prismFactory, IShapeFactory parallelepipedFactory, IShapeFactory sphereFactory, IShapeFactory capsuleFactory)
        {
            _prismFactory = prismFactory;
            _parallelepipedFactory = parallelepipedFactory;
            _sphereFactory = sphereFactory;
            _capsuleFactory = capsuleFactory;
           Shapes = new Dictionary<ShapeType, IShape>();
    }

        public void GenerateShape(ShapeType shapeType, params object[] meshParameters)
        {
            if (Shapes.TryGetValue(shapeType, out var shape))
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
                    shape = _sphereFactory.CreateShape(_spherePivot);
                    break;
                case ShapeType.capsule:
                    shape = _capsuleFactory.CreateShape(_capsulePivot);
                    break;
            }

            shape.UpdateMesh(meshParameters);
            Shapes.Add(shapeType, shape);
            ChangeShapes—ount?.Invoke(Shapes);
        }

        public void PaintShape(ShapeType shapeType, Color color)
        {
            if (Shapes.TryGetValue(shapeType, out var shape))
            {
                shape.Paint(color);
            }
        }

        public void DestroyShape(ShapeType shapeType)
        {
            if (Shapes.TryGetValue(shapeType, out var shape))
            {
                shape.Destroy();
                Shapes.Remove(shapeType);
            }

            ChangeShapes—ount?.Invoke(Shapes);
        }
    }
}
