using System;
using Zenject;

public class Level : IInitializable, ITickable, IDisposable
{
    private readonly CardChecker _cardChecker;
    private readonly float _timeCache = 60f;

    public Level(CardChecker cardChecker)
    {
        _cardChecker = cardChecker;
    }

    public float Time { get; private set; }
    public int Current { get; private set; } = 1;
    
    public void Tick()
    {
        if (CardClicker.IsFirstClick == false)
        {
            Time = _timeCache / Current;

            if (Time < 10) Time = 10;
            
            return;
        }

        if (Time <= 0) SceneLoader.LoadMain();
        
        Time -= UnityEngine.Time.deltaTime;
    }

    public void Dispose() => _cardChecker.OnUpdateGame -= LevelUp;
    
    public void Initialize() => _cardChecker.OnUpdateGame += LevelUp;

    private void LevelUp()
    {
        CardClicker.IsFirstClick = false;
        PlayerOptions.BestScore = Current;
        Current++;
    }
}
