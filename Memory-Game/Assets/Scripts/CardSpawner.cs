using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private CardChecker _cardChecker;

    [SerializeField] private Card _card;
    [SerializeField] private CardData[] _cardData;
    
    private List<CardData> _allCardsData;
    private List<Card> _allCards;

    private void Start()
    {        
        InitCardData();
        
        foreach(CardData card in _allCardsData)
        {
            InitCard(card);
        }
        
        _cardChecker.OnCardsGuessed += CheckCardsGuessed;
        _cardChecker.OnUpdateGame += UpdateCards;
    }

    private void OnDestroy()
    {
        _cardChecker.OnCardsGuessed -= CheckCardsGuessed;
        _cardChecker.OnUpdateGame -= UpdateCards;
    }

    private void InitCardData()
    {
        _allCardsData = new List<CardData>();
        _allCards = new List<Card>();

        foreach (CardData cardData in _cardData)
        {
            _allCardsData.Add(cardData);
            _allCardsData.Add(cardData);
        }

        Sort(_allCardsData);
    }

    private void InitCard(CardData cardData)
    {
        Card card = Instantiate(_card, transform);
        card.Init(cardData.Id, cardData.FrontSprite, cardData.BackSprite);

        _allCards.Add(card);        
    }

    private void Sort(List<CardData> allCardsData)
    {
        for(int i = 0; i < allCardsData.Count; i++)
        {
            int tempIndex = Random.Range(0, allCardsData.Count);
            CardData temp = allCardsData[i];
            allCardsData[i] = allCardsData[tempIndex];
            allCardsData[tempIndex] = temp;
        }
    }

    private void UpdateCards()
    {
        Sort(_allCardsData);

        for (int i = 0; i < _allCardsData.Count; i++)
        {            
            _allCards[i].Init(_allCardsData[i].Id, _allCardsData[i].FrontSprite, _allCardsData[i].BackSprite);
        }
    }

    private bool CheckCardsGuessed()
    {
        foreach(Card card in _allCards)
        {
            if (card.TryOpen())
            {
                return false;
            }
        }
        return true;
    }
}
