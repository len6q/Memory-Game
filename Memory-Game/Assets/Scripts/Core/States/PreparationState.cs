public class PreparationState : BaseGameState
{
    public PreparationState(IGameStateSwitcher gameStateSwitcher, DefenderHud defenderHud, Level level)
        : base(gameStateSwitcher, defenderHud, level)
    { }

    public override void Enter()
    {
        CardClicker.OnCardClick += CardClick;
        _level.Load();

        _defenderHud.SetInGameText(_level.Current, _level.Time);
    }

    public override void Exit()
    {
        _level.Unload();
        CardClicker.OnCardClick -= CardClick;
    }

    public override void Tick() { }

    private void CardClick(Card card)
    {
        _gameStateSwitcher.SwitchState<PlayingState>();
    }
}