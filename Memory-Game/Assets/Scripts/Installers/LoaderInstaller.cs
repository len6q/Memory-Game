using UnityEngine;
using Zenject;

public class LoaderInstaller : MonoInstaller
{
    [SerializeField] private SceneLoader _sceneLoaderPrebab;

    public override void InstallBindings()
    {
        Container.InstantiatePrefabForComponent<SceneLoader>(_sceneLoaderPrebab);
    }
}
