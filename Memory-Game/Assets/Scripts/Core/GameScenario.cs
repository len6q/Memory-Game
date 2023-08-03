public class GameScenario 
{
    private readonly LevelConfig[] _levelConfigs;
    
    private int _currentConfig = 0;

    public GameScenario(LevelConfig[] levelConfigs)
    {
        _levelConfigs = levelConfigs;
        CurrentLevel = 1;
    }

    public int CurrentLevel { get; private set; }
    public LevelConfig CurrentConfig => _levelConfigs[_currentConfig];

    public void UpdateLevel()
    {
        CurrentLevel++;
        if (_currentConfig < _levelConfigs.Length - 1) _currentConfig++;        
        else _currentConfig = _levelConfigs.Length - 1;
    }
}