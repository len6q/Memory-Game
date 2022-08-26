using UnityEngine;
using UnityEngine.UI;

public class ClosedCardState : BaseState
{
    private Sprite _tempSprite;
    public ClosedCardState(Image cardView, ICardStateSwitcher stateCardSwitcher, Sprite frontSprite)
        : base(cardView, stateCardSwitcher)
    {
        _tempSprite = frontSprite;
    }

    public override void Close()
    {
        throw new System.NotImplementedException();
    }

    public override void Guess()
    {
        throw new System.NotImplementedException();
    }

    public override void Open()
    {
        _cardView.sprite = _tempSprite;

        _stateCardSwitcher.SwitchState<OpenedCardState>();
    }

    public override bool TryOpen()
    {
        return true;
    }
}
