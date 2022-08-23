public interface ICardState
{
    public void Open(Card card);
    public void Close(Card card);
    public void Guess(Card card);
}
