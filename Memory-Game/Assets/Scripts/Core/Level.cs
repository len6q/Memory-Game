using System;

public class Level
{
    public event Action OnLevelUp;
    public event Action OnLostGame;

    private readonly CardChecker _cardChecker;    

    public Level(CardChecker cardChecker)
    {
        _cardChecker = cardChecker;        
    }

    public float Time { get; private set; }
    public int Current { get; private set; }
    
    public void UpdateTime()
    {
        if (Time <= 0) OnLostGame?.Invoke();        
        Time -= UnityEngine.Time.deltaTime;
    }

    public void Unload() => _cardChecker.OnUpdateGame -= LevelUp;

    public void Load(GameScenario gameScenario)
    {
        Time = gameScenario.CurrentConfig.StartSeconds;
        Current = gameScenario.CurrentLevel;        

        _cardChecker.OnUpdateGame += LevelUp;
    }

    private void LevelUp()
    {        
        PlayerOptions.BestScore = Current;        
        OnLevelUp?.Invoke();
    }

    public void LoadStartupValues(int currentLevel) => Current = currentLevel;    
}
