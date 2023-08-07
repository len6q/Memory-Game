public class GameOverState : BaseGameState
{
    private readonly GameOverHud _gameOverHud;
    private readonly GameScenario _scenario;

    public GameOverState(IGameStateSwitcher gameStateSwitcher, Level level, GameOverHud gameOverHud, GameScenario scenario)
        : base(gameStateSwitcher, level)
    {
        _gameOverHud = gameOverHud;
        _scenario = scenario;
    }

    public override void Enter()
    {
        _gameOverHud.Open();
        _gameOverHud.SetAdsText(_scenario.CurrentConfig.StartSeconds);

        _gameOverHud.ShowAdsButton.onClick.AddListener(Restart);
        _gameOverHud.CancelButton.onClick.AddListener(Quit);
    }

    public override void Exit()
    {
        _gameOverHud.Close();
        _gameOverHud.ShowAdsButton.onClick.RemoveListener(Restart);
        _gameOverHud.CancelButton.onClick.RemoveListener(Quit);
    }

    public override void Tick() { }

    private void Restart()
    {
        Dll.ShowAdsRewarded();
        _gameStateSwitcher.SwitchState<PreparationState>();
    }

    private void Quit() => SceneLoader.LoadMain();    
}
