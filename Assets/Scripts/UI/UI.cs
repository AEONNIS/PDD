using UnityEngine;

namespace Game.UI
{
    public class UI : MonoBehaviour
    {
        private bool _hoveringPointer;

        public bool HoveringPointer => _hoveringPointer;

        public void PointerEnter()
        {
            _hoveringPointer = true;
        }

        public void PointerExit()
        {
            _hoveringPointer = false;
        }
    }
}
