using Zenject;

public class GameInstaller : MonoInstaller
{    
    public override void InstallBindings()
    {        
        Container.BindInterfacesAndSelfTo<Level>().AsSingle();
        Container.BindInterfacesAndSelfTo<Game>().AsSingle();
    }
}
