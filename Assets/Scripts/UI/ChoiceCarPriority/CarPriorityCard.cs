using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class CarPriorityCard : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private Button _button;
        private ChoiceCarPriority _choiceCarPriority;
        private int _priority;

        public void Init(ChoiceCarPriority choiceCarPriority, int priority)
        {
            _choiceCarPriority = choiceCarPriority;
            _priority = priority;
            _text.text = priority.ToString();
        }

        public void Init(ResultsCheckingPriorities resultsCheckingPriorities, Car car)
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => OnCardClick(resultsCheckingPriorities, car));
        }

        private void OnCardClick(ResultsCheckingPriorities resultsCheckingPriorities, Car car)
        {
            car.SetUserPriority(_priority);
            resultsCheckingPriorities.SetUserPriorityForCar(car);
            _choiceCarPriority.gameObject.SetActive(false);
        }
    }
}
