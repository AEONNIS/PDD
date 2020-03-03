using Game.UI;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private Roadbed _roadbed;
    [SerializeField] private Transform _pathStartPoint;
    [SerializeField] private ChoiceCarPriority _choiceCarPriority;
    [SerializeField] private GameState _gameState;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private UI _ui;

    public Roadbed Roadbed => _roadbed;
    public Transform PathStartPoint => _pathStartPoint;

    public Car CreateCar(Car carTemplate, Path path)
    {
        Car car = Instantiate(carTemplate, transform);
        car.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        car.Init(this, path, _choiceCarPriority, _gameState, _mainCamera, _ui);
        _roadbed.SetCar(car);
        return car;
    }
}
