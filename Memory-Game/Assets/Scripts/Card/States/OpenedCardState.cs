using UnityEngine;
using UnityEngine.UI;

public class OpenedCardState : BaseCardState
{
    private readonly Sprite _tempSprite;

    public OpenedCardState(Image cardView, ICardStateSwitcher stateCardSwitcher, Sprite backSprite)
        : base(cardView, stateCardSwitcher)
    {
        _tempSprite = backSprite;
    }

    public override void Close()
    {
        _cardView.sprite = _tempSprite;

        _stateCardSwitcher.SwitchState<ClosedCardState>();
    }

    public override void Guess()
    {
        _stateCardSwitcher.SwitchState<GuessedCardState>();
    }

    public override void Open()
    {
        
    }

    public override bool TryOpen()
    {
        return false;
    }
}
