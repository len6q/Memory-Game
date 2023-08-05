using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private AudioConfig _audioConfig;
    [SerializeField] private AudioSystem _audioSystemPrefab;

    public override void InstallBindings()
    {
        Container.BindInstance(_audioConfig);
        Container.InstantiatePrefabForComponent<AudioSystem>(_audioSystemPrefab);
    }
}