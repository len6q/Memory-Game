using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
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

        GlobalEventSystem.OnUpdateGame.AddListener(UpdateCards);
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

        card.State = new ClosedCardState();
        card.Id = cardData.Id;

        card.BackSprite = cardData.BackSprite;
        card.FrontSprite = cardData.FrontSprite;

        _allCards.Add(card);
        card.Close();
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

        for(int i=0; i < _allCardsData.Count; i++)
        {
            _allCards[i].State = new ClosedCardState();
            _allCards[i].Id = _allCardsData[i].Id;

            _allCards[i].BackSprite = _allCardsData[i].BackSprite;
            _allCards[i].FrontSprite = _allCardsData[i].FrontSprite;

            _allCards[i].Close();
        }
    }
}
