using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ConfirmationPanel : MonoBehaviour
    {
        [SerializeField] private Text _message;
        [SerializeField] private Button _confirmationButton;
        [SerializeField] private Button _failureButton;

        public void Init(string message, Action onConfirmationButtonClick, GameObject callingGameObject = null)
        {
            _message.text = message;
            gameObject.SetActive(true);
            InitButtons(onConfirmationButtonClick, callingGameObject);
        }

        private void InitButtons(Action onConfirmationButtonClick, GameObject callingGameObject)
        {
            _confirmationButton.onClick.RemoveAllListeners();
            _failureButton.onClick.RemoveAllListeners();

            _confirmationButton.onClick.AddListener(() =>
            {
                DIsableThisEnableCallingGameObject(callingGameObject);
                onConfirmationButtonClick?.Invoke();
            });
            _failureButton.onClick.AddListener(() => DIsableThisEnableCallingGameObject(callingGameObject));
        }

        private void DIsableThisEnableCallingGameObject(GameObject callingGameObject)
        {
            gameObject.SetActive(false);

            if (callingGameObject != null)
                callingGameObject.SetActive(true);
        }
    }
}
