public interface ICardStateSwitcher
{
    public void SwitchState<T>() where T : BaseCardState;
}
