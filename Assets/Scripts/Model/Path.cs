using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Path
{
    [SerializeField] private CrossroadSide _side;
    [SerializeField] private PathDirection _direction;
    [SerializeField] private List<Transform> _trajectoryPoints;

    public CrossroadSide Side => _side;
    public PathDirection Direction => _direction;
    public List<Transform> TrajectoryPoints => _trajectoryPoints;

    public Path(CrossroadSide side, PathDirection direction)
    {
        _side = side;
        _direction = direction;
    }
}

public enum CrossroadSide { South, East, North, West }
public enum PathDirection { UTurn, LeftTurn, Direct, RightTurn }
