using UnityEngine;
using Zenject;

public class HudInstaller : MonoInstaller
{
    [SerializeField] private MainHud _mainHud;
    [SerializeField] private StartupHud _startupHud;

    public override void InstallBindings()
    {
        Container.BindInstance(_startupHud);
        Container.BindInstance(_mainHud);
    }
}
