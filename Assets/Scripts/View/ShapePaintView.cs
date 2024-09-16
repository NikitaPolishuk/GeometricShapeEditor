using UnityEngine;
using UnityEngine.UI;

public class ShapePaintView : BaseView
{
    [SerializeField] Slider _redSlider;
    [SerializeField] Slider _greenSlider;
    [SerializeField] Slider _blueSlider;
    [SerializeField] Button _paintButton;
    private ShapeType _paintShapeType;

    private void Start()
    {
        _redSlider.onValueChanged.AddListener(value => ChangeColorButton());
        _greenSlider.onValueChanged.AddListener(value => ChangeColorButton());
        _blueSlider.onValueChanged.AddListener(value => ChangeColorButton());

        _paintButton.onClick.AddListener(() => GameManager.Instance.ShapesController.PaintShape(_paintShapeType, GetPaintColor()));
        ChangeColorButton();
    }

    public void ChangePaintShape(ShapeType type)
    {
        _paintShapeType = type;
    }

    private Color GetPaintColor()
    {
        var red = _redSlider.value;
        var green = _greenSlider.value;
        var blue = _blueSlider.value;

        return new Color(red, green, blue);
    }    

    private void ChangeColorButton()
    {
        _paintButton.image.color = GetPaintColor();
    }
}
