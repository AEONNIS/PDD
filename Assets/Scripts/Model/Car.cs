using Game.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Car : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private PathTrajectory _pathTrajectory;
    [SerializeField] private CarBacklight _backlight;
    [SerializeField] private CarPriorityPresenter _priorityPresenter;
    [SerializeField] private UIPointerListener _uiPointerListener;
    [SerializeField] private UnityEvent _userPrioritySet;

    private StartPoint _startPoint;
    private Path _path;
    private int _userPriority;
    private int _priority;
    private bool _hoveringPointer;

    public Path Path => _path;
    public bool IsOnMainRoad => _startPoint.Roadbed.MainRoad;
    public int UserPriority => _userPriority;
    public int Priority => _priority;
    public bool UserPriorityIsSet => _userPriority == 0 ? false : true;
    public bool PriorityIsSet => _priority == 0 ? false : true;
    public bool UserPriorityEqualsPriority => _userPriority == _priority ? true : false;

    public event UnityAction UserPrioritySet
    {
        add => _userPrioritySet.AddListener(value);
        remove => _userPrioritySet.RemoveListener(value);
    }

    public void Init(StartPoint startPoint, Path path, ChoiceCarPriority choiceCarPriority, GameState gameState, Camera mainCamera, UI ui)
    {
        _startPoint = startPoint;
        _path = path;
        List<Vector3> trajectoryPositions = new List<Vector3> { startPoint.PathStartPoint.position };
        trajectoryPositions.AddRange(path.TrajectoryPoints.Select(point => point.position));
        _pathTrajectory.Init(this, trajectoryPositions);
        _priorityPresenter.Init(this, choiceCarPriority, gameState, mainCamera);
        _uiPointerListener.SetUI(ui);
    }

    public void SetUserPriority(int userPriority)
    {
        _userPriority = userPriority;
        _priorityPresenter.Present(userPriority);
        _userPrioritySet?.Invoke();
    }

    public void SetPriority(int priority)
    {
        _priority = priority;
    }

    public void DisableBacklightIfPointerIsNoteHovering()
    {
        if (_hoveringPointer == false)
            _backlight.SetBacklightState(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _hoveringPointer = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _hoveringPointer = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _backlight.SetBacklightState(!_backlight.Backlight);
    }
}
