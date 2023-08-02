public class StartupState : BaseGameState
{
    private readonly StartupHud _startupHud;
    private readonly CardsCollection _cardsCollection;

    public StartupState(IGameStateSwitcher gameStateSwitcher, Level level, StartupHud startupHud, CardsCollection cardsCollection) 
        : base(gameStateSwitcher, level)
    {
        _startupHud = startupHud;
        _cardsCollection = cardsCollection;
    }

    public override void Enter()
    {
        _level.LoadStartupValues();
        _startupHud.Open();        
        _startupHud.OnClick += StartGame;
    }

    public override void Exit()
    {
        _startupHud.Close();
        _startupHud.OnClick -= StartGame;
        _cardsCollection.Init();
    }

    public override void Tick() { }
    
    private void StartGame() => _gameStateSwitcher.SwitchState<PreparationState>();    
}
