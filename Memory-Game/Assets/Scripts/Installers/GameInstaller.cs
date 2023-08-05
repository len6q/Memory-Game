using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{    
    [SerializeField] private LevelConfig[] _levelConfigs;    

    public override void InstallBindings()
    {        
        LocalisationSystem.Load();

        Container.BindInstance(_levelConfigs);        
        Container.BindInterfacesAndSelfTo<Level>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameScenario>().AsSingle();
        Container.BindInterfacesAndSelfTo<Game>().AsSingle();        
    }
}
