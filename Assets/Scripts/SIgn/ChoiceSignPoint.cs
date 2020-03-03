using Game.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoiceSignPoint : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ChoiceSignPanel _choiceSignPanel;
    [SerializeField] private Roadbed _roadbed;
    private bool _locking;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_locking == false)
            _choiceSignPanel.Init(_roadbed);
    }

    public void SetLockState(bool locking)
    {
        _locking = locking;
    }
}
