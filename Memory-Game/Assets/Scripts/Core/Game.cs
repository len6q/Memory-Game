using System.Collections.Generic;
using System.Linq;
using Zenject;

public class Game : IInitializable, ITickable, IGameStateSwitcher
{
    private readonly DefenderHud _defenderHud;
    private readonly Level _level;

    private List<BaseGameState> _allStates;
    private BaseGameState _currentState;
    
    public Game(DefenderHud defenderHud, Level level)
    {
        _defenderHud = defenderHud;
        _level = level;
    }

    public void Initialize()
    {
        _allStates = new List<BaseGameState>
        {
            new StartupState(this, _defenderHud, _level),
            new PreparationState(this, _defenderHud, _level),
            new PlayingState(this, _defenderHud, _level)            
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