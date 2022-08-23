public class ClosedCardState : ICardState
{
    public void Close(Card card)
    {
        card.CardView.sprite = card.BackSprite;
    }

    public void Guess(Card card)
    {
        return;
    }

    public void Open(Card card)
    {
        card.State = new OpenedCardState();
        card.CardView.sprite = card.FrontSprite;
    }
}
