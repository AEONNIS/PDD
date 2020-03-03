using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crossroad : MonoBehaviour
{
    [SerializeField] private CarGenerator _carGenerator;
    [SerializeField] private List<Roadbed> _roadbeds;
    [SerializeField] private UnityEvent _allSignsSet;
    [SerializeField] private UnityEvent _allCarsUserPrioritiesSet;

    private List<Car> _cars = new List<Car>();

    public List<Roadbed> Roadbeds => _roadbeds;
    public List<Car> Cars => _cars;

    public event UnityAction AllSignsSet
    {
        add => _allSignsSet.AddListener(value);
        remove => _allSignsSet.RemoveListener(value);
    }
    public event UnityAction AllCarsUserPrioritiesSet
    {
        add => _allCarsUserPrioritiesSet.AddListener(value);
        remove => _allCarsUserPrioritiesSet.RemoveListener(value);
    }

    private void Awake()
    {
        List<StartPoint> allStartPoints = new List<StartPoint>();
        _roadbeds.ForEach(roadbed => roadbed.SignSet += OnSignSet);
        _roadbeds.ForEach(roadbed => allStartPoints.Add(roadbed.StartPoint));
        _carGenerator.Init(allStartPoints);
    }

    private void OnSignSet()
    {
        foreach (var roadbed in _roadbeds)
        {
            if (roadbed.Sign == null)
                return;
        }

        _allSignsSet?.Invoke();
    }

    private void OnCarUserPrioritySet()
    {
        foreach (Car car in _cars)
        {
            if (car.UserPriorityIsSet == false)
                return;
        }

        _allCarsUserPrioritiesSet?.Invoke();
    }

    public bool AllPrioritiesIsSet()
    {
        foreach (Car car in Cars)
        {
            if (car.PriorityIsSet == false)
                return false;
        }

        return true;
    }

    public void GenerateCars()
    {
        _cars = _carGenerator.Generate();
        _cars.ForEach(car => car.UserPrioritySet += OnCarUserPrioritySet);
    }

    public void ResetState()
    {
        _roadbeds.ForEach(roadbed => roadbed.ResetState());
        _cars = new List<Car>();
    }
}
