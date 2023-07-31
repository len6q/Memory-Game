public class LevelUpState : BaseGameState
{
    private readonly LevelUpHud _levelUpHud;

    public LevelUpState(IGameStateSwitcher gameStateSwitcher, Level level, LevelUpHud levelUpHud)
        : base(gameStateSwitcher, level)
    {
        _levelUpHud = levelUpHud;
    }

    public override void Enter()
    {        
        _levelUpHud.Open();
        _levelUpHud.LoadNextLevelButton.onClick.AddListener(LevelUp);
    }

    public override void Exit()
    {     
        _levelUpHud.Close();
        _levelUpHud.LoadNextLevelButton.onClick.RemoveListener(LevelUp);
    }

    public override void Tick() { }

    private void LevelUp() => _gameStateSwitcher.SwitchState<PreparationState>();    
}
