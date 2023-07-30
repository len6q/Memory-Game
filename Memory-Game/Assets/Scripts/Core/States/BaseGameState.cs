public abstract class BaseGameState
{
    protected readonly IGameStateSwitcher _gameStateSwitcher;    
    protected readonly Level _level;

    protected BaseGameState(IGameStateSwitcher gameStateSwitcher, Level level)
    {
        _gameStateSwitcher = gameStateSwitcher;        
        _level = level;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Tick();
}