using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public class UIPointerListener : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private UI _ui;

        public void SetUI(UI ui)
        {
            _ui = ui;
        }

        private void OnDisable()
        {
            _ui.PointerExit();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _ui.PointerEnter();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _ui.PointerExit();
        }
    }
}
