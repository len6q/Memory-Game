using System;
using System.Collections;
using UnityEngine;

public class CardChecker : MonoBehaviour
{
    public event Func<bool> OnCardsGuessed;
    public event Action OnUpdateGame;

    public bool IsStartGame => _isStartGame;
    private bool _isStartGame;

    private Card _anotherCard;
    private bool _isCardsInProcessComparison;

    private void Start()
    {
        CardClicker.OnCardClick += CardCheck;    
    }

    private void OnDestroy()
    {
        CardClicker.OnCardClick -= CardCheck;
    }

    private void CardCheck(Card card)
    {
        if (!_isStartGame)
        {
            _isStartGame = true;
        }

        if (!card.TryOpen() || _isCardsInProcessComparison)
        { 
            return;
        }        

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

                PlayerOptions.BestScore = Score.TempLVL;
                _isStartGame = false;

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
