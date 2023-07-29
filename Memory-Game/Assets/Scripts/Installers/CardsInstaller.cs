using UnityEngine;
using Zenject;

public class CardsInstaller : MonoInstaller
{    
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private CardData[] _partCardsData;
    [SerializeField] private CardChecker _checker;
    [SerializeField] private Transform _parentTransform;

    public override void InstallBindings()
    {
        Container.BindInstance(_cardPrefab);
        Container.BindInstance(_partCardsData);        
        Container.BindInstance(_checker);
        Container.BindInstance(_parentTransform);
        
        Container.BindInterfacesAndSelfTo<CardsCollection>().AsSingle();
    }    
}