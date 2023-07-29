using System;
using System.Collections;
using UnityEngine;

public class CardChecker : MonoBehaviour
{
    public event Func<bool> OnCardsGuessed;
    public event Action OnUpdateGame;

    private Card _anotherCard;
    private bool _isCardsInProcessComparison;
  
    private void Start()
    {
        CardClicker.OnCardClick += CheckCard;    
    }

    private void OnDestroy()
    {
        CardClicker.OnCardClick -= CheckCard;
    }

    private void CheckCard(Card card)
    {  
        if (card.TryOpen() == false || _isCardsInProcessComparison) return;
        
        card.Open();

        if (_anotherCard == null)
        {
            _anotherCard = card;
            return;
        }

        StartCoroutine(CardsComparison(card));
    }

    private IEnumerator CardsComparison(Card card)
    {
        _isCardsInProcessComparison = true;

        if (_anotherCard.Id == card.Id)
        {
            _anotherCard.Guess();
            card.Guess();

            if(OnCardsGuessed.Invoke())
            {                
                yield return new WaitForSeconds(.3f);                
                OnUpdateGame?.Invoke();                
            }
        }
        else
        {
            yield return new WaitForSeconds(.3f);
            _anotherCard.Close();
            card.Close();
        }

        _anotherCard = null;
        _isCardsInProcessComparison = false;
    }
}
