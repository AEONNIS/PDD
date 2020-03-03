using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(menuName = "Data/SignsPlacementTester")]
public class SignsPlacementTester : ScriptableObject
{
    [SerializeField] private List<Sign> _forDirectMainRoad;
    [SerializeField] private List<Sign> _forCurveMainRoad;
    private Sign[] _testSigns;

    public bool Test(Crossroad crossroad)
    {
        CreateTestSigns(crossroad);
        return _forDirectMainRoad.SequenceEqual(_testSigns) || _forCurveMainRoad.SequenceEqual(_testSigns);
    }

    private void CreateTestSigns(Crossroad crossroad)
    {
        _testSigns = new Sign[_forDirectMainRoad.Count];

        int delta = _forDirectMainRoad.IndexOf(crossroad.Roadbeds[0].Sign);
        delta = delta == -1 ? _forCurveMainRoad.IndexOf(crossroad.Roadbeds[0].Sign) : delta;

        for (int i = 0; i < _testSigns.Length; i++, delta++)
        {
            delta = delta < _testSigns.Length ? delta : 0;
            _testSigns[delta] = crossroad.Roadbeds[i].Sign;
        }
    }
}
