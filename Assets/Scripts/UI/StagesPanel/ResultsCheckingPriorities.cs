using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ResultsCheckingPriorities : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Color _backgroundDefaultColor;
        [SerializeField] private Color _backgroundRightColor;
        [SerializeField] private Color _backgroundWrongColor;
        [SerializeField] private RectTransform _prioritiesResultsContent;
        [SerializeField] private PriorityResult _priorityResultTemplate;
        private List<PriorityResult> _prioritiesResults = new List<PriorityResult>();

        public void Init(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                PriorityResult priorityResult = Instantiate(_priorityResultTemplate, _prioritiesResultsContent);
                priorityResult.Init(car);
                _prioritiesResults.Add(priorityResult);
            }
        }

        public void ClearResults()
        {
            _prioritiesResults.ForEach(priorityResult => Destroy(priorityResult.gameObject));
            _prioritiesResults = new List<PriorityResult>();
            _backgroundImage.color = _backgroundDefaultColor;
        }

        public void SetUserPriorityForCar(Car car)
        {
            _prioritiesResults.First(priorityResult => priorityResult.Car == car).SetUserPriority();
        }

        public bool CheckPriorities()
        {
            bool allPrioritiesRight = true;

            foreach (var priorityResult in _prioritiesResults)
            {
                if (priorityResult.CheckPriority() == false)
                    allPrioritiesRight = false;
            }

            _backgroundImage.color = allPrioritiesRight ? _backgroundRightColor : _backgroundWrongColor;
            return allPrioritiesRight;
        }
    }
}
