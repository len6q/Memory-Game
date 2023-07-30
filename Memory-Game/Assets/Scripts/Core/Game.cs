using System.Collections.Generic;
using System.Linq;
using Zenject;

public class Game : IInitializable, ITickable, IGameStateSwitcher
{
    private readonly MainHud _mainHud;
    private readonly StartupHud _startupHud;
    private readonly Level _level;

    private List<BaseGameState> _allStates;
    private BaseGameState _currentState;
    
    public Game(MainHud mainHud, StartupHud startupHud, Level level)
    {
        _mainHud = mainHud;
        _startupHud = startupHud;
        _level = level;
    }

    public void Initialize()
    {
        _allStates = new List<BaseGameState>
        {
            new StartupState(this, _level, _startupHud),
            new PreparationState(this, _level, _mainHud),
            new PlayingState(this, _level, _mainHud)            
        };
        _currentState = _allStates[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : BaseGameState
    {        
        _currentState.Exit();
        var state = _allStates.FirstOrDefault(state => state is T);
        _currentState = state;
        _currentState.Enter();
    }

    public void Tick() => _currentState.Tick();   
}