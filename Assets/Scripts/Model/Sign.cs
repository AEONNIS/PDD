using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Sign")]
public class Sign : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] Sprite _iconTop;
    [SerializeField] Sprite _iconDown;
    [SerializeField] private List<Direction> _mainRoadDirections;

    public string Name => _name;
    public Sprite IconTop => _iconTop;
    public Sprite IconDown => _iconDown;
    public List<Direction> MainRoadDirections => _mainRoadDirections;
}

public enum Direction { Top, Down, Left, Right }
