public class PlayingState : BaseGameState
{
    public PlayingState(IGameStateSwitcher gameStateSwitcher, DefenderHud defenderHud, Level level)
        : base(gameStateSwitcher, defenderHud, level)
    { }

    public override void Enter()
    {
        _level.Load();
        _level.OnLevelUp += LevelUp;
        _level.OnRestart += Restart;
        
        _defenderHud.SetInGameText(_level.Current, _level.Time);
    }

    public override void Exit()
    {      
        _level.Unload();
        _level.OnLevelUp -= LevelUp;
        _level.OnRestart -= Restart;
    }

    public override void Tick()
    {
        _defenderHud.SetTimerText(_level.Time);
        _level.UpdateTime();
    }

    private void LevelUp() => _gameStateSwitcher.SwitchState<PreparationState>();
    
    private void Restart() => SceneLoader.LoadMain();    
}
