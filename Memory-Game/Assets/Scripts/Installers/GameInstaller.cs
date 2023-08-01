using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{    
    [SerializeField] private LevelConfig _levelConfig;

    public override void InstallBindings()
    {        
        LocalisationSystem.Load();

        Container.BindInstance(_levelConfig);
        Container.BindInterfacesAndSelfTo<Level>().AsSingle();
        Container.BindInterfacesAndSelfTo<Game>().AsSingle();
    }
}
