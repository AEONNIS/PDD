using Game.UI;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    [SerializeField] private Crossroad _crossroad;
    [SerializeField] private StagesTimeLimiter _timeLimiter;
    [SerializeField] private Timer _timerTemplate;
    [SerializeField] private RandomSignForRandomRoadbed _randomSignForRandomRoadbed;
    [SerializeField] private SignsPlacementTester _signsPlacementTester;
    [SerializeField] private CarsPrioritiesDeterminant _carsPrioritiesDeterminant;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private int _playerStatsNumberLastDays;
    [SerializeField] private UnityEvent _prioritiesChecked;
    [Header("UI Components:")]
    [SerializeField] private ChoiceSignPanel _choiceSignPanel;
    [SerializeField] private ChoiceCarPriority _choiceCarPriority;
    [SerializeField] private StagesPanel _stagesPanel;
    [SerializeField] private LosingPanel _losingPanel;
    [SerializeField] private PlayerStatsWindow _playerStatsWindow;
    [Header("Delays:")]
    [SerializeField] private float _losingPanelDelayForIncorrectSignsPlacement = 2.0f;
    [SerializeField] private float _losingPanelDelayForIncorrectChoicePriorities = 5.0f;

    private Timer _timer;
    private float _signsPlacementPastTime;
    private float _choicePrioritiesPastTime;

    public event UnityAction PrioritiesChecked
    {
        add => _prioritiesChecked.AddListener(value);
        remove => _prioritiesChecked.RemoveListener(value);
    }

    private void Awake()
    {
        _timer = Instantiate(_timerTemplate, transform);
    }

    private void Start()
    {
        StartSignsPlacement();
    }

    public void StartSignsPlacement()
    {
        _signsPlacementPastTime = 0.0f;
        _choicePrioritiesPastTime = 0.0f;
        _crossroad.ResetState();
        _stagesPanel.ResetPanel();

        _randomSignForRandomRoadbed.RandomChoice();
        _timeLimiter.StartTimerForStage(Stage.SignsPlacement, () => ToLose(ReasonLosing.TimeIsOver, 0.0f));
    }

    public bool CheckSignsPlacement()
    {
        _crossroad.Roadbeds.ForEach(roadbed => roadbed.ChoiceSignPoint.SetLockState(true));

        if (_signsPlacementTester.Test(_crossroad))
        {
            _signsPlacementPastTime = _timeLimiter.StopTimer();
            return true;
        }
        else
        {
            ToLose(ReasonLosing.WrongAnswer, _losingPanelDelayForIncorrectSignsPlacement);
            return false;
        }
    }

    public void StartChoicePriorities()
    {
        _crossroad.GenerateCars();
        _stagesPanel.ChoicePrioritiesInit(_crossroad.Cars);
        _timeLimiter.StartTimerForStage(Stage.ChoicePriorities, () => ToLose(ReasonLosing.TimeIsOver, 0.0f));
    }

    public void CheckPriorities()
    {
        _carsPrioritiesDeterminant.DeterminationPriorities(_crossroad);
        _prioritiesChecked?.Invoke();

        if (_stagesPanel.CheckPriorities())
        {
            _choicePrioritiesPastTime = _timeLimiter.StopTimer();
            _playerStats.AddRecords(GameResult.Win, _signsPlacementPastTime, _choicePrioritiesPastTime);
        }
        else
        {
            ToLose(ReasonLosing.WrongAnswer, _losingPanelDelayForIncorrectChoicePriorities);
        }
    }

    public void ShowPlayerStatsWindow()
    {
        _stagesPanel.gameObject.SetActive(false);
        _playerStatsWindow.Present(_playerStats.CalculateTotalResults(), _playerStats.CalculateResultsForLastDays(_playerStatsNumberLastDays));
    }

    public void PlayerStatsClearAndUpdateStatsWindow()
    {
        _playerStats.Clear();
        ShowPlayerStatsWindow();
    }

    private void ToLose(ReasonLosing reasonLosing, float losingPanelDelay)
    {
        _choiceSignPanel.gameObject.SetActive(false);
        _choiceCarPriority.gameObject.SetActive(false);
        _timeLimiter.StopTimer();

        GameResult gameResult = reasonLosing == ReasonLosing.TimeIsOver ? GameResult.TimeIsOverLoss : GameResult.WrongAnswerLoss;
        _playerStats.AddRecords(gameResult, 0.0f, 0.0f);

        if (losingPanelDelay > 0)
            _timer.StartTimer(losingPanelDelay, () => ShowLosingPanel(reasonLosing));
        else
            ShowLosingPanel(reasonLosing);
    }

    private void ShowLosingPanel(ReasonLosing reasonLosing)
    {
        _stagesPanel.gameObject.SetActive(false);
        _losingPanel.Init(reasonLosing);
    }
}

public enum Stage { SignsPlacement, ChoicePriorities }
public enum ReasonLosing { TimeIsOver, WrongAnswer }
