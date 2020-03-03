using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/CarsPrioritiesDeterminant")]
public class CarsPrioritiesDeterminant : ScriptableObject
{
    [SerializeField] private List<CrossingPaths> _templateCrossings;

    public void DeterminationPriorities(Crossroad crossroad)
    {
        for (int i = 1; crossroad.AllPrioritiesIsSet() == false; i++)
        {
            foreach (Car car in FindCarsWithMinPriority(crossroad))
                car.SetPriority(i);
        }
    }

    private List<Car> FindCarsWithMinPriority(Crossroad crossroad)
    {
        List<Car> cars = crossroad.Cars.Where(car => car.PriorityIsSet == false).ToList();
        List<Car> removalCars = new List<Car>();

        for (int a = 0; a < cars.Count - 1; a++)
        {
            for (int b = a + 1; b < cars.Count; b++)
            {
                ComparisonResult result = ComparePriorities(cars[a], cars[b]);

                if (result == ComparisonResult.Less)
                    removalCars.Add(cars[b]);
                else if (result == ComparisonResult.More)
                    removalCars.Add(cars[a]);
            }
        }

        removalCars.ForEach(car => cars.Remove(car));
        return cars;
    }

    private ComparisonResult ComparePriorities(Car carA, Car carB)
    {
        HindranceAtCrossing hindranceAtCrossing = TestCrossingPaths(carA, carB);

        if (hindranceAtCrossing == HindranceAtCrossing.NoCrossing)
        {
            return ComparisonResult.Equally;
        }
        else
        {
            if (carA.IsOnMainRoad == true && carB.IsOnMainRoad == false)
            {
                return ComparisonResult.Less;
            }
            else if (carA.IsOnMainRoad == false && carB.IsOnMainRoad == true)
            {
                return ComparisonResult.More;
            }
            else
            {
                if (hindranceAtCrossing == HindranceAtCrossing.LeftHindrance)
                    return ComparisonResult.Less;
                else if (hindranceAtCrossing == HindranceAtCrossing.RightHindrance)
                    return ComparisonResult.More;
                else
                    return ComparisonResult.Equally;
            }
        }
    }

    private HindranceAtCrossing TestCrossingPaths(Car carA, Car carB)
    {
        Rotate(carA, carB, out Path aPath, out Path bPath);

        return _templateCrossings.First(crossing => crossing.APath.Direction == aPath.Direction &&
               crossing.BPath.Side == bPath.Side && crossing.BPath.Direction == bPath.Direction).AHindranceAtCrossing;
    }

    private void Rotate(Car carA, Car carB, out Path aPath, out Path bPath)
    {
        int bPathSide = carB.Path.Side - carA.Path.Side;
        bPathSide = bPathSide < 0 ? Enum.GetValues(typeof(CrossroadSide)).Length + bPathSide : bPathSide;
        aPath = new Path(CrossroadSide.South, carA.Path.Direction);
        bPath = new Path((CrossroadSide)bPathSide, carB.Path.Direction);
    }
}

public enum ComparisonResult { Less, Equally, More }
