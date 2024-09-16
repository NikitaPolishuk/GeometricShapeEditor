using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainShapeView : BaseView
{
    [SerializeField] Button _sphereButton;
    [SerializeField] Button _capsuleButton;
    [SerializeField] Button _prismaButton;
    [SerializeField] Button _parallelepipedButton;
    [SerializeField] ShapesCreateView _shapesParametersView;
    [SerializeField] ShapePaintView _shapePaintView;
    private ShapeType _shapeType;

    private void Start()
    {
        _sphereButton.onClick.AddListener(() => ChangeShapeView(ShapeType.sphere));
        _capsuleButton.onClick.AddListener(() => ChangeShapeView(ShapeType.capsule));
        _prismaButton.onClick.AddListener(() => ChangeShapeView(ShapeType.prism));
        _parallelepipedButton.onClick.AddListener(() => ChangeShapeView(ShapeType.parallelepiped));
        GameManager.Instance.ShapesController.ChangeShapes—ount += ChangeShapes—ount;
    }

    private void ChangeShapes—ount(Dictionary<ShapeType, IShape> shapes)
    {
        if (shapes.ContainsKey(_shapeType))
        {
            _shapePaintView.ShowView();
            _shapePaintView.ChangePaintShape(_shapeType);
        }
    }

    private void ChangeShapeView(ShapeType shapeType)
    {
        SetCollorAllButtons(Color.red);

        switch (shapeType)
        {
            case ShapeType.parallelepiped:
                _parallelepipedButton.image.color = Color.green;
                break;
            case ShapeType.prism:
                _prismaButton.image.color = Color.green;
                break;
            case ShapeType.sphere:
                _sphereButton.image.color = Color.green;
                break;
            case ShapeType.capsule:
                _capsuleButton.image.color = Color.green;
                break;
            default:
                break;
        }

        _shapesParametersView.ShowView();
        _shapesParametersView.ChangeType(shapeType);
        _shapeType = shapeType;
    }

    private void SetCollorAllButtons(Color color)
    {
        _sphereButton.image.color = color;
        _capsuleButton.image.color = color;
        _prismaButton.image.color = color;
        _parallelepipedButton.image.color = color;
    }
}
