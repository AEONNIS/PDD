using UnityEngine;
using UnityEngine.Events;

public class Roadbed : MonoBehaviour
{
    [SerializeField] private ChoiceSignPoint _choiceSignPoint;
    [SerializeField] private SignPresenter _signScenePresenter;
    [SerializeField] private StartPoint _startPoint;
    [SerializeField] private Path _uTurnPath;
    [SerializeField] private Path _leftTurnPath;
    [SerializeField] private Path _directPath;
    [SerializeField] private Path _rightTurnPath;
    [SerializeField] private UnityEvent _signSet;

    private Sign _sign = null;
    private bool _mainRoad = false;
    private Car _car;

    public ChoiceSignPoint ChoiceSignPoint => _choiceSignPoint;
    public StartPoint StartPoint => _startPoint;
    public Path UTurnPath => _uTurnPath;
    public Path LeftTurnPath => _leftTurnPath;
    public Path DirectPath => _directPath;
    public Path RightTurnPath => _rightTurnPath;
    public Sign Sign => _sign;
    public bool MainRoad => _mainRoad;
    public Car Car => _car;

    public event UnityAction SignSet
    {
        add => _signSet.AddListener(value);
        remove => _signSet.RemoveListener(value);
    }

    public void SetSign(Sign sign, bool blockChoiceSign = false)
    {
        _choiceSignPoint.SetLockState(blockChoiceSign);
        _sign = sign;
        _mainRoad = _sign.MainRoadDirections.Contains(Direction.Down) ? true : false;
        _signScenePresenter.Present(sign);
        _signSet?.Invoke();
    }

    public void SetCar(Car car)
    {
        _car = car;
    }

    public void ResetState()
    {
        _choiceSignPoint.SetLockState(false);
        _sign = null;
        _mainRoad = false;
        _signScenePresenter.Present(null);

        if (Car != null)
        {
            Destroy(_car.gameObject);
            _car = null;
        }
    }
}
