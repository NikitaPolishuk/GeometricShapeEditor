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

    private const string CREATE_ERROR_TEXT = "Not all figure parameters are filled in";

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

        var lenght = float.TryParse(GetInputField(ParameterType.Length).text, out var lenghtParse);
        var width = float.TryParse(GetInputField(ParameterType.Width).text, out var widthParse);
        var height = float.TryParse(GetInputField(ParameterType.Height).text, out var heightParse);
        var edges = int.TryParse(GetInputField(ParameterType.Edges).text, out var edgesParse);
        var radius = float.TryParse(GetInputField(ParameterType.Radius).text, out var radiusParse);

        switch (_type)
        {
            case ShapeType.parallelepiped:
                if (!lenght || !width || !height)
                {
                    Debug.LogError(CREATE_ERROR_TEXT);
                    return;
                }
                shapesController.GenerateShape(_type, lenghtParse, widthParse, heightParse);
                break;
            case ShapeType.prism:
                if (!edges || !radius || !height)
                {
                    Debug.LogError(CREATE_ERROR_TEXT);
                    return;
                }
                shapesController.GenerateShape(_type, edgesParse, radiusParse, heightParse);
                break;
            case ShapeType.sphere:
                if (!edges || !radius)
                {
                    Debug.LogError(CREATE_ERROR_TEXT);
                    return;
                }
                shapesController.GenerateShape(_type, radiusParse, edgesParse);
                break;
            case ShapeType.capsule:
                if (!edges || !radius || !height)
                {
                    Debug.LogError(CREATE_ERROR_TEXT);
                    return;
                }
                shapesController.GenerateShape(_type, radiusParse, edgesParse, heightParse);
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
                SetActiveParameter(ParameterType.Radius, true);
                SetActiveParameter(ParameterType.Edges, true);
                break;
            case ShapeType.capsule:
                SetActiveParameter(ParameterType.Radius, true);
                SetActiveParameter(ParameterType.Edges, true);
                SetActiveParameter(ParameterType.Height, true);
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
