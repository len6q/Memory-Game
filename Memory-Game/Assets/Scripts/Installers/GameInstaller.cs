using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{    
    [SerializeField] private GameScenario _gameScenario;

    public override void InstallBindings()
    {        
        LocalisationSystem.Load();

        Container.BindInstance(_gameScenario);
        Container.BindInterfacesAndSelfTo<Level>().AsSingle();
        Container.BindInterfacesAndSelfTo<Game>().AsSingle();
    }
}
