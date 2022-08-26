using UnityEngine;
using UnityEngine.UI;

public class GuessedCardState : BaseState
{
    private Sprite _tempSprite;
    public GuessedCardState(Image cardView, ICardStateSwitcher stateCardSwitcher, Sprite backSprite)
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
        throw new System.NotImplementedException();
    }

    public override void Open()
    {
        throw new System.NotImplementedException();
    }

    public override bool TryOpen()
    {
        return false;
    }
}
