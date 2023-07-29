public abstract class BaseGameState
{
    protected readonly IGameStateSwitcher _gameStateSwitcher;
    protected readonly DefenderHud _defenderHud;
    protected readonly Level _level;

    protected BaseGameState(IGameStateSwitcher gameStateSwitcher, DefenderHud defenderHud, Level level)
    {
        _gameStateSwitcher = gameStateSwitcher;
        _defenderHud = defenderHud;
        _level = level;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Tick();
}