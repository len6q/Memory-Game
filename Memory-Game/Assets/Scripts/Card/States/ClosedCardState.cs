using UnityEngine;
using UnityEngine.UI;

public class ClosedCardState : BaseCardState
{
    private readonly Sprite _tempSprite;
   
    public ClosedCardState(Image cardView, ICardStateSwitcher stateCardSwitcher, Sprite frontSprite)
        : base(cardView, stateCardSwitcher)
    {
        _tempSprite = frontSprite;
    }

    public override void Close() { }

    public override void Guess() { }

    public override void Open()
    {
        _cardView.sprite = _tempSprite;
        AudioSystem.PlaySound(nameof(Card));
        _stateCardSwitcher.SwitchState<OpenedCardState>();
    }

    public override bool TryOpen()
    {
        return true;
    }
}
