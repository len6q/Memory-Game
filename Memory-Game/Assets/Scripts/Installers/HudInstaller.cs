using UnityEngine;
using Zenject;

public class HudInstaller : MonoInstaller
{
    [SerializeField] private MainHud _mainHud;
    [SerializeField] private StartupHud _startupHud;
    [SerializeField] private GameOverHud _gameOverHud;
    [SerializeField] private LevelUpHud _levelUpHud;

    public override void InstallBindings()
    {
        Container.BindInstance(_startupHud);
        Container.BindInstance(_mainHud);
        Container.BindInstance(_gameOverHud);
        Container.BindInstance(_levelUpHud);
    }
}
