using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerOptions _playerOptionsPrefab;

    public override void InstallBindings()
    {
        Container.InstantiatePrefabForComponent<PlayerOptions>(_playerOptionsPrefab);
    }
}