public class StartupState : BaseGameState
{
    private readonly StartupHud _startupHud;
    private readonly CardsCollection _cardsCollection;
    private readonly GameScenario _gameScenario;

    public StartupState(IGameStateSwitcher gameStateSwitcher, Level level, StartupHud startupHud, CardsCollection cardsCollection, GameScenario gameScenario)
        : base(gameStateSwitcher, level)
    {
        _startupHud = startupHud;
        _cardsCollection = cardsCollection;
        _gameScenario = gameScenario;
    }

    public override void Enter()
    {
        _level.LoadStartupValues(_gameScenario.CurrentLevel);
        _startupHud.Open();        
        _startupHud.OnClick += StartGame;
    }

    public override void Exit()
    {
        _startupHud.Close();
        _startupHud.OnClick -= StartGame;
        _cardsCollection.Init(_gameScenario.CurrentConfig);
    }

    public override void Tick() { }
    
    private void StartGame() => _gameStateSwitcher.SwitchState<PreparationState>();    
}
