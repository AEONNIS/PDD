using System;
using UnityEngine;

public class StagesTimeLimiter : MonoBehaviour
{
    [SerializeField] private Timer _timerTemplate;
    [Header("Times:")]
    [SerializeField] [Range(1, 30)] private float _signsPlacementTime = 15.0f;
    [SerializeField] [Range(1, 50)] private float _choicePrioritiesTime = 30.0f;

    private Timer _timer;

    private void Awake()
    {
        _timer = Instantiate(_timerTemplate, transform);
    }

    public void StartTimerForStage(Stage stage, Action onEnd)
    {
        if (stage == Stage.SignsPlacement)
            _timer.StartTimer(_signsPlacementTime, onEnd);
        else
            _timer.StartTimer(_choicePrioritiesTime, onEnd);
    }

    public float StopTimer()
    {
        return _timer.StopTimer();
    }
}
