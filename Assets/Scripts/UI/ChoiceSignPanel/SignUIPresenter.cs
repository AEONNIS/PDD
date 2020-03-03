using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class SignUIPresenter : MonoBehaviour
    {
        [SerializeField] private Image _imageTop;
        [SerializeField] private Image _imageDown;
        [SerializeField] private Text _name;
        [SerializeField] private Button _button;
        private ChoiceSignPanel _choiceSignPanel;
        private Sign _sign;

        public void Present(ChoiceSignPanel choiceSignPanel, Sign sign)
        {
            _imageTop.sprite = sign.IconTop;
            _imageDown.sprite = sign.IconDown;
            _name.text = sign.Name;
            _choiceSignPanel = choiceSignPanel;
            _sign = sign;
        }

        public void InitButton(Roadbed roadbed)
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => OnClick(roadbed));
        }

        private void OnClick(Roadbed roadbed)
        {
            roadbed.SetSign(_sign);
            _choiceSignPanel.gameObject.SetActive(false);
        }
    }
}
