using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    [SerializeField] private List<Car> _carsTemplate;
    [SerializeField] private int _minNumberCars = 2;
    [SerializeField] private int _maxNumberCars = 4;
    private List<StartPoint> _allStartPoints;
    private List<Car> _cars;

    public void Init(List<StartPoint> allStartPoints)
    {
        _allStartPoints = allStartPoints;
        _minNumberCars = _minNumberCars >= 2 && _minNumberCars <= _maxNumberCars ? _minNumberCars : 2;
        _maxNumberCars = _maxNumberCars >= _minNumberCars && _maxNumberCars <= _allStartPoints.Count ? _maxNumberCars : _allStartPoints.Count;
    }

    public List<Car> Generate()
    {
        _cars = new List<Car>();
        List<int> indicesStartPoints = new List<int>();
        int countCars = Random.Range(_minNumberCars, _maxNumberCars + 1);

        while (indicesStartPoints.Count < countCars)
        {
            int startPointIndex = Random.Range(0, _allStartPoints.Count);
            if (indicesStartPoints.Contains(startPointIndex) == false)
                indicesStartPoints.Add(startPointIndex);
        }

        indicesStartPoints.ForEach(index => GenerateCar(_allStartPoints[index]));
        return _cars;
    }

    private void GenerateCar(StartPoint startPoint)
    {
        _cars.Add(startPoint.CreateCar(_carsTemplate[Random.Range(0, _carsTemplate.Count)], GeneratePath(startPoint.Roadbed)));
    }

    private Path GeneratePath(Roadbed roadbed)
    {
        int i = Random.Range(0, 4);
        if (i == 0)
            return roadbed.UTurnPath;
        else if (i == 1)
            return roadbed.LeftTurnPath;
        else if (i == 2)
            return roadbed.DirectPath;
        else
            return roadbed.RightTurnPath;
    }
}
