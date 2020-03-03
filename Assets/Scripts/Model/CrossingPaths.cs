using System;
using UnityEngine;

[Serializable]
public class CrossingPaths
{
    [SerializeField] private Path _aPath;
    [SerializeField] private Path _bPath;
    [SerializeField] private HindranceAtCrossing _aHindranceAtCrossing;

    public Path APath => _aPath;
    public Path BPath => _bPath;
    public HindranceAtCrossing AHindranceAtCrossing => _aHindranceAtCrossing;
}

public enum HindranceAtCrossing { NoCrossing, NoHindrance, LeftHindrance, RightHindrance }
