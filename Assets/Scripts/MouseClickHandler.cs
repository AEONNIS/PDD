using Game.UI;
using UnityEngine;

public class MouseClickHandler : MonoBehaviour
{
    [SerializeField] private UI _ui;
    [SerializeField] private Crossroad _crossroad;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _ui.HoveringPointer == false)
            _crossroad.Cars.ForEach(car => car.DisableBacklightIfPointerIsNoteHovering());
    }
}
