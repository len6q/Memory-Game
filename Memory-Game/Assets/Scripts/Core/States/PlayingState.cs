public class PlayingState : BaseGameState
{
    private readonly MainHud _mainHud;

    public PlayingState(IGameStateSwitcher gameStateSwitcher, Level level, MainHud mainHud)
        : base(gameStateSwitcher, level)
    {
        _mainHud = mainHud;
    }

    public override void Enter()
    {
        _level.Load();
        _level.OnLevelUp += LevelUp;
        _level.OnLostGame += Lose;
        
        _mainHud.Open();
        _mainHud.SetInGameText(_level.Current, _level.Time);
    }

    public override void Exit()
    {      
        _level.Unload();
        _level.OnLevelUp -= LevelUp;
        _level.OnLostGame -= Lose;                
    }

    public override void Tick()
    {
        _mainHud.SetTimerText(_level.Time);
        _level.UpdateTime();
    }

    private void LevelUp() => _gameStateSwitcher.SwitchState<PreparationState>();
    
    private void Lose() => _gameStateSwitcher.SwitchState<GameOverState>();    
}
