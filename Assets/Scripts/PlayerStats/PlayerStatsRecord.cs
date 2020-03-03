using System;
using UnityEngine;

[Serializable]
public class PlayerStatsRecord
{
    [SerializeField] private GameResult _result;
    [SerializeField] private long _dateTimeTicks;
    [SerializeField] private float _signsPlacementTime;
    [SerializeField] private float _choicePrioritiesTime;

    public PlayerStatsRecord(GameResult result, DateTime dateTime, float signsPlacementTime, float choicePrioritiesTime)
    {
        _result = result;
        _dateTimeTicks = dateTime.Ticks;
        _signsPlacementTime = signsPlacementTime;
        _choicePrioritiesTime = choicePrioritiesTime;
    }

    public GameResult Result => _result;
    public DateTime Date => new DateTime(_dateTimeTicks);
    public float GameTime => _signsPlacementTime + _choicePrioritiesTime;
    public float SignsPlacementTime => _signsPlacementTime;
    public float ChoicePrioritiesTime => _choicePrioritiesTime;
}

public enum GameResult { TimeIsOverLoss, WrongAnswerLoss, Win }
