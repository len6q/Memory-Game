public class PlayingState : BaseGameState
{
    private readonly MainHud _mainHud;
    private readonly CardsCollection _cardsCollection;

    public PlayingState(IGameStateSwitcher gameStateSwitcher, Level level, MainHud mainHud, CardsCollection cardsCollection)
        : base(gameStateSwitcher, level)
    {
        _mainHud = mainHud;
        _cardsCollection = cardsCollection;
    }

    public override void Enter()
    {
        _level.Load();
        _level.OnLevelUp += LevelUp;
        _level.OnLostGame += Lose;
        
        _mainHud.Open();
        _mainHud.SetInGameText(_level.Current, _level.Time);
    }

    public override void Exit()
    {      
        _level.Unload();        
        _level.OnLevelUp -= LevelUp;
        _level.OnLostGame -= Lose;                
    }

    public override void Tick()
    {
        _mainHud.SetTimerText(_level.Time);
        _level.UpdateTime();
    }

    private void LevelUp()
    {
        _cardsCollection.Destroy();
        _cardsCollection.Init();
        _gameStateSwitcher.SwitchState<PreparationState>();
    }

    private void Lose() 
    {
        _mainHud.Inactive();
        _gameStateSwitcher.SwitchState<GameOverState>(); 
    }
}
