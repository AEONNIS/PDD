using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class ChoiceCarPriority : MonoBehaviour
    {
        [SerializeField] private ResultsCheckingPriorities _resultsCheckingPriorities;
        [SerializeField] private CarPriorityCard _priorityCardTemplate;
        [SerializeField] private RectTransform _rectTransformContent;
        private List<CarPriorityCard> _priorityCards;

        public void Init(int countPriorityCards)
        {
            _priorityCards = new List<CarPriorityCard>();

            foreach (Transform child in _rectTransformContent)
                Destroy(child.gameObject);

            for (int i = 0; i < countPriorityCards; i++)
            {
                _priorityCards.Add(Instantiate(_priorityCardTemplate, _rectTransformContent));
                _priorityCards[i].Init(this, i + 1);
            }
        }

        public void Show(Car car, Vector3 priorityPresenterPosition)
        {
            foreach (var card in _priorityCards)
                card.Init(_resultsCheckingPriorities, car);

            transform.position = priorityPresenterPosition;
            gameObject.SetActive(true);
        }
    }
}
