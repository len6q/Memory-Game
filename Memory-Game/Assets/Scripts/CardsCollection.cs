using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CardsCollection: IInitializable, IDisposable
{
    private readonly List<CardData> _allCardsData = new();
    private readonly List<Card> _allCards = new();    
    private readonly Card _cardPrefab;
    private readonly CardData[] _partCardsData;
    private readonly CardChecker _cardChecker;
    private readonly Transform _parentTransform;

    public CardsCollection(
        Card cardPrefab, CardData[] partCardsData,
        CardChecker cardChecker, Transform parentTransform)
    {
        _cardPrefab = cardPrefab;
        _partCardsData = partCardsData;
        _cardChecker = cardChecker;
        _parentTransform = parentTransform;
    }

    public void Initialize()
    {
        InitCardData();
        _allCardsData.ForEach(card => InitCard(card));

        _cardChecker.OnCardsGuessed += IsCardsGuessed;
        _cardChecker.OnUpdateGame += Refresh;
    }

    public void Dispose()
    {
        _cardChecker.OnCardsGuessed -= IsCardsGuessed;
        _cardChecker.OnUpdateGame -= Refresh;
    }

    private void RandomSort(List<CardData> allCardsData)
    {
        for (int i = 0; i < allCardsData.Count; i++)
        {
            int tempIndex = UnityEngine.Random.Range(0, allCardsData.Count);
            (allCardsData[tempIndex], allCardsData[i]) = (allCardsData[i], allCardsData[tempIndex]);
        }
    }

    private void InitCardData()
    {
        foreach (CardData cardData in _partCardsData)
        {
            _allCardsData.Add(cardData);
            _allCardsData.Add(cardData);
        }
        RandomSort(_allCardsData);
    }

    private void InitCard(CardData cardData)
    {
        Card card = GameObject.Instantiate(_cardPrefab, _parentTransform);
        card.Init(cardData.Id, cardData.FrontSprite, cardData.BackSprite);

        _allCards.Add(card);
    }

    private void Refresh()
    {
        RandomSort(_allCardsData);
        
        for (int i = 0; i < _allCardsData.Count; i++)
        {            
            _allCards[i].Init(_allCardsData[i].Id, _allCardsData[i].FrontSprite, _allCardsData[i].BackSprite);
        }
    }

    private bool IsCardsGuessed()
    {
        foreach(Card card in _allCards)
        {
            if (card.TryOpen()) return false;            
        }
        return true;
    }    
}
