using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSignForRandomRoadbed : MonoBehaviour
{
    [SerializeField] private Crossroad _crossroad;
    private List<Sign> _signs;

    private void Awake()
    {
        _signs = Resources.LoadAll<Sign>("Signs").ToList();
    }

    public void RandomChoice()
    {
        ChoiceRandomRoadbed().SetSign(ChoiceRandomSign(), true);
    }

    private Roadbed ChoiceRandomRoadbed()
    {
        int i = Random.Range(0, _crossroad.Roadbeds.Count);
        return _crossroad.Roadbeds[i];
    }

    private Sign ChoiceRandomSign()
    {
        int i = Random.Range(0, _signs.Count);
        return _signs[i];
    }
}
