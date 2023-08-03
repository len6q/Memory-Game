public class PreparationState : BaseGameState
{
    private readonly MainHud _mainHud; 
    private readonly GameScenario _gameScenario;

    public PreparationState(IGameStateSwitcher gameStateSwitcher, Level level, MainHud mainHud, GameScenario gameScenario)
        : base(gameStateSwitcher, level)
    {
        _mainHud = mainHud;
        _gameScenario = gameScenario;
    }

    public override void Enter()
    {
        CardClicker.OnCardClick += CardClick;
        _level.Load(_gameScenario.CurrentLevel);

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