using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class PriorityResult : MonoBehaviour
    {
        [SerializeField] private Image _userPriorityImage;
        [SerializeField] private Text _userPriorityText;
        [SerializeField] private Color _userPriorityDefaultColor;
        [SerializeField] private Color _userPriorityWrongColor;
        [SerializeField] private Text _priorityText;
        private Car _car;

        public Car Car => _car;

        public void Init(Car car)
        {
            _car = car;
        }

        public void SetUserPriority()
        {
            SetPriority(_userPriorityDefaultColor, _car.UserPriority.ToString(), "-");
        }

        public bool CheckPriority()
        {
            if (Car.UserPriorityEqualsPriority)
            {
                SetPriority(_userPriorityDefaultColor, _car.UserPriority.ToString(), _car.Priority.ToString());
                return true;
            }
            else
            {
                SetPriority(_userPriorityWrongColor, _car.UserPriority.ToString(), _car.Priority.ToString());
                return false;
            }
        }

        private void SetPriority(Color userPriorityColor, string userPriority, string priority)
        {
            _userPriorityImage.color = userPriorityColor;
            _userPriorityText.text = userPriority;
            _priorityText.text = priority;
        }
    }
}
