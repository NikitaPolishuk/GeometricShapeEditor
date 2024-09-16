using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShapesCreateView : BaseView
{
    [SerializeField] List<InputFieldData> _inputFields;
    [SerializeField] Button _createButton;
    [SerializeField] Button _deleteButton;
    private ShapeType _type;


    enum ParameterType
    {
        Height,
        Length,
        Width,
        Radius,
        Edges
    }

    [Serializable]
    struct InputFieldData
    {
        public ParameterType type;
        public TMP_InputField inputField;
    }


    private void Start()
    {
        _createButton.onClick.AddListener(CreateShape);
        _deleteButton.onClick.AddListener(DestroyShape);
    }

    private void CreateShape()
    {
        var shapesController = GameManager.Instance.ShapesController;

        switch (_type)
        {
            case ShapeType.parallelepiped:
                var lenght = float.Parse(GetInputField(ParameterType.Length).text);
                var width = float.Parse(GetInputField(ParameterType.Width).text);
                var height = float.Parse(GetInputField(ParameterType.Height).text);
                shapesController.GenerateShape(_type, lenght, width, height);
                break;
            case ShapeType.prism:
                var heightPrism = float.Parse(GetInputField(ParameterType.Height).text);
                var edges = int.Parse(GetInputField(ParameterType.Edges).text);
                var radius = float.Parse(GetInputField(ParameterType.Radius).text);
                shapesController.GenerateShape(_type, edges, radius, heightPrism);
                break;
            case ShapeType.sphere:
                break;
            case ShapeType.capsule:
                break;
        }
    }

    public void DestroyShape()
    {
        GameManager.Instance.ShapesController.DestroyShape(_type);
    }

    public void ChangeType(ShapeType type)
    {
        SetActiveAllParametrs(false);

        switch (type)
        {
            case ShapeType.parallelepiped:
                SetActiveParameter(ParameterType.Width, true);
                SetActiveParameter(ParameterType.Height, true);
                SetActiveParameter(ParameterType.Length, true);
                break;
            case ShapeType.prism:
                SetActiveParameter(ParameterType.Radius, true);
                SetActiveParameter(ParameterType.Edges, true);
                SetActiveParameter(ParameterType.Height, true);
                break;
            case ShapeType.sphere:
                break;
            case ShapeType.capsule:
                break;
        }

        _type = type;
    }

    private TMP_InputField GetInputField(ParameterType type)
    {
        return _inputFields.Find(value => value.type == type ).inputField;
    }

    private void SetActiveParameter(ParameterType type, bool value)
    {
        GetInputField(type).gameObject.SetActive(value);
    }

    private void SetActiveAllParametrs(bool value)
    {
        foreach (var field in _inputFields)
        {
            field.inputField.gameObject.SetActive(value);
        }
    }
}
