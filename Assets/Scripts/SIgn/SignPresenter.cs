using UnityEngine;

public class SignPresenter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _top;
    [SerializeField] private SpriteRenderer _down;
    [SerializeField] private Sprite _empty;

    public void Present(Sign sign)
    {
        _top.sprite = sign == null ? _empty : sign.IconTop;
        _down.sprite = sign == null ? _empty : sign.IconDown;
    }
}
