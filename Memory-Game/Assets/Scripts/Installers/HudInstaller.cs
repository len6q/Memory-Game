using UnityEngine;
using Zenject;

public class HudInstaller : MonoInstaller
{
    [SerializeField] private DefenderHud _defenderHud;

    public override void InstallBindings()
    {
        Container.BindInstance(_defenderHud);
    }
}
