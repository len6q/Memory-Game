public class StartupState : BaseGameState
{
    private readonly StartupHud _startupHud;

    public StartupState(IGameStateSwitcher gameStateSwitcher, Level level, StartupHud startupHud) 
        : base(gameStateSwitcher, level)
    {
        _startupHud = startupHud;
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
    }

    public override void Tick() { }
    
    private void StartGame() => _gameStateSwitcher.SwitchState<PreparationState>();    
}
