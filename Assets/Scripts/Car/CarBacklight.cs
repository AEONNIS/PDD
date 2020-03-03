using UnityEngine;

public class CarBacklight : MonoBehaviour
{
    [SerializeField] private MeshRenderer _carRenderer;
    [SerializeField] private Material _carDefaultMaterial;
    [SerializeField] private Material _carOutlineMaterial;
    [SerializeField] private LineRenderer _pathRenderer;
    [SerializeField] private Color _pathDefaultColor;
    [SerializeField] private Color _pathBacklightColor;
    [SerializeField] private float _pathDefaultWidth;
    [SerializeField] private float _pathBacklightWidth;
    private bool _backlight;

    public bool Backlight => _backlight;

    public void SetBacklightState(bool active)
    {
        if (active)
            SetBacklightState(_carOutlineMaterial, _pathBacklightColor, _pathBacklightWidth, true);
        else
            SetBacklightState(_carDefaultMaterial, _pathDefaultColor, _pathDefaultWidth, false);
    }

    private void SetBacklightState(Material carMaterial, Color pathColor, float pathWidth, bool backlight)
    {
        _carRenderer.material = carMaterial;
        _pathRenderer.startColor = pathColor;
        _pathRenderer.endColor = pathColor;
        _pathRenderer.widthMultiplier = pathWidth;
        _backlight = backlight;
    }
}
