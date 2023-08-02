public class PreparationState : BaseGameState
{
    private readonly MainHud _mainHud;    

    public PreparationState(IGameStateSwitcher gameStateSwitcher, Level level, MainHud mainHud)
        : base(gameStateSwitcher, level)
    { 
        _mainHud = mainHud;
    }

    public override void Enter()
    {
        CardClicker.OnCardClick += CardClick;
        _level.Load();        

        _mainHud.Open();
        _mainHud.SetInGameText(_level.Current, _level.Time);
    }

    public override void Exit()
    {
        _level.Unload();
        _mainHud.Close();
        CardClicker.OnCardClick -= CardClick;
    }

    public override void Tick() { }

    private void CardClick(Card card) => _gameStateSwitcher.SwitchState<PlayingState>();            
}