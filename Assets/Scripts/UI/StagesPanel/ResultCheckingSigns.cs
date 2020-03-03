using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ResultCheckingSigns : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _text;
        [SerializeField] private Color _backgroundDefaultColor;
        [SerializeField] private Color _backgroundRightColor;
        [SerializeField] private Color _backgroundWrongColor;

        public void ClearResult()
        {
            SetResult(_backgroundDefaultColor, "");
        }

        public void SetRightResult()
        {
            SetResult(_backgroundRightColor, "ПРАВИЛЬНО!");
        }

        public void SetWrongResult()
        {
            SetResult(_backgroundWrongColor, "НЕ ПРАВИЛЬНО!");
        }

        private void SetResult(Color backgroundColor, string resultText)
        {
            _image.color = backgroundColor;
            _text.text = resultText;
        }
    }
}
