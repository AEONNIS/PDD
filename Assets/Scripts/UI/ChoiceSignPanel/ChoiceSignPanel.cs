using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.UI
{
    public class ChoiceSignPanel : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private SignUIPresenter _signUITemplate;
        private List<Sign> _signs;
        private List<SignUIPresenter> _signPresenters;

        private void Awake()
        {
            _signs = Resources.LoadAll<Sign>("Signs").ToList();
            _signPresenters = _signs.Select(sign => SetSign(sign)).ToList();
            gameObject.SetActive(false);
        }

        private SignUIPresenter SetSign(Sign sign)
        {
            SignUIPresenter signPresenter = Instantiate(_signUITemplate, _content);
            signPresenter.Present(this, sign);
            return signPresenter;
        }

        public void Init(Roadbed roadbed)
        {
            _signPresenters.ForEach(sign => sign.InitButton(roadbed));
            gameObject.SetActive(true);
        }
    }
}
