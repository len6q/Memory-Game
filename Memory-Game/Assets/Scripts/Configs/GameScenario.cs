public class GameScenario 
{
    private readonly LevelConfig[] _levelConfigs;
    
    private int _currentLevel = 0;

    public GameScenario(LevelConfig[] levelConfigs)
    {
        _levelConfigs = levelConfigs;
    }

    public LevelConfig CurrentLevel => _levelConfigs[_currentLevel];

    public void UpdateLevel() => _currentLevel++;
}