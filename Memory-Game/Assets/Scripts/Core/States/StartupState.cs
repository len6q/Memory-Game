public class StartupState : BaseGameState
{
    public StartupState(IGameStateSwitcher gameStateSwitcher, DefenderHud defenderHud, Level level) 
        : base(gameStateSwitcher, defenderHud, level)
    { }

    public override void Enter()
    {
        _defenderHud.SetStartupInfo();
        CardClicker.OnCardClick += CardClick;
    }

    public override void Exit()
    {
        CardClicker.OnCardClick -= CardClick;
    }

    public override void Tick() { }
    
    private void CardClick(Card card)
    {
        _gameStateSwitcher.SwitchState<PlayingState>();
    }
}
