public class PlayingState : BaseGameState
{
    private readonly MainHud _mainHud;
    private readonly CardsCollection _cardsCollection;
    private readonly GameScenario _gameScenario;

    private bool _isShowGameOverHud = false;

    public PlayingState(IGameStateSwitcher gameStateSwitcher, Level level, MainHud mainHud, CardsCollection cardsCollection, GameScenario gameScenario)
        : base(gameStateSwitcher, level)
    {
        _mainHud = mainHud;
        _cardsCollection = cardsCollection;
        _gameScenario = gameScenario;
    }

    public override void Enter()
    {        
        _level.OnLevelUp += LevelUp;
        _level.OnLostGame += Lose;
        
        _mainHud.Open();
        _mainHud.SetInGameText(_gameScenario);
    }

    public override void Exit()
    {      
        _level.Unload();        
        _level.OnLevelUp -= LevelUp;
        _level.OnLostGame -= Lose;
        _cardsCollection.CloseOpeningCards();
    }

    public override void Tick()
    {
        _mainHud.SetTimerText(_level.Time);
        _level.UpdateTime();
    }

    private void LevelUp()
    {
        _gameScenario.UpdateLevel();
        _cardsCollection.Destroy();
        _cardsCollection.Init(_gameScenario.CurrentConfig);
        _gameStateSwitcher.SwitchState<PreparationState>();
    }

    private void Lose() 
    {
        if(_isShowGameOverHud == false)
        {
            _mainHud.Inactive();
            _gameStateSwitcher.SwitchState<GameOverState>(); 
            _isShowGameOverHud = true;
        }
        else
        {            
            SceneLoader.LoadMain();
        }
    }
}
