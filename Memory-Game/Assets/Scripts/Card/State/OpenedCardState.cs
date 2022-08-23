public class OpenedCardState : ICardState
{
    public void Close(Card card)
    {
        card.State = new ClosedCardState();
        card.CardView.sprite = card.BackSprite;
    }

    public void Guess(Card card)
    {
        card.State = new GuessedCardState();
    }

    public void Open(Card card)
    {
        card.CardView.sprite = card.FrontSprite;
    }
}
