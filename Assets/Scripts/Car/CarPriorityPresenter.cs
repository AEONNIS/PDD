using Game.UI;
using UnityEngine;
using UnityEngine.UI;

public class CarPriorityPresenter : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Vector2 _offsetPositionFromCar;
    [SerializeField] private Image _image;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _rightPriorityColor;
    [SerializeField] private Color _wrongPriorityColor;
    [SerializeField] private Text _text;
    [SerializeField] private Button _button;
    private Car _car;
    private ChoiceCarPriority _choiceCarPriority;

    public void Init(Car car, ChoiceCarPriority choiceCarPriority, GameState gameState, Camera mainCamera)
    {
        _car = car;
        _choiceCarPriority = choiceCarPriority;
        Vector2 position = mainCamera.WorldToScreenPoint(new Vector3(_car.transform.position.x, _car.transform.position.y, _car.transform.position.z));
        _rectTransform.position = position + _offsetPositionFromCar;

        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(OpenChoiceCarPriority);

        gameState.PrioritiesChecked += HighlightInColor;
    }

    private void OpenChoiceCarPriority()
    {
        _choiceCarPriority.Show(_car, _rectTransform.position);
    }

    public void Present(int userPriority)
    {
        _text.text = userPriority.ToString();
        _image.color = _defaultColor;
    }

    private void HighlightInColor()
    {
        _button.interactable = false;

        if (_car.UserPriorityEqualsPriority)
            _image.color = _rightPriorityColor;
        else
            _image.color = _wrongPriorityColor;
    }
}
