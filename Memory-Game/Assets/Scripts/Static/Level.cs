using System;

public class Level
{
    public event Action OnLevelUp;
    public event Action OnRestart;

    private readonly CardChecker _cardChecker;
    private readonly LevelConfig _config;    

    public Level(CardChecker cardChecker, LevelConfig config)
    {
        _cardChecker = cardChecker;
        _config = config;        
    }

    public float Time { get; private set; }
    public int Current { get; private set; }
    
    public void UpdateTime()
    {
        if (Time <= 0) OnRestart?.Invoke();        
        Time -= UnityEngine.Time.deltaTime;
    }

    public void Unload() => _cardChecker.OnUpdateGame -= LevelUp;

    public void Load()
    {        
        Time = _config.TimeValue / Current;
        if (Time < 10) Time = 10;

        _cardChecker.OnUpdateGame += LevelUp;
    }

    private void LevelUp()
    {        
        PlayerOptions.BestScore = Current;
        Current++;
        OnLevelUp?.Invoke();
    }

    public void LoadStartupValues()
    {
        Current = _config.CurrentLevel;
    }
}
