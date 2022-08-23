using System.Collections;
using UnityEngine;

public class CardChecker : MonoBehaviour
{
    private Card _anotherCard;
    private bool _isCardInProcess;
    private int _countGuesses;

    private void Start()
    {
        CardClicker.OnCardClick.AddListener(CardCheck);        
    }

    private void CardCheck(Card card)
    {
        if (_isCardInProcess || card.State is GuessedCardState || card.State is OpenedCardState)
        { 
            return;
        }

        card.Open();

        if (_anotherCard == null)
        {
            _anotherCard = card;
            return;
        }

        StartCoroutine(CardComparison(card));
    }

    private IEnumerator CardComparison(Card card)
    {
        _isCardInProcess = true;

        if (_anotherCard.Id == card.Id)
        {
            _countGuesses += 2;

            _anotherCard.Guess();
            card.Guess();

            if(_countGuesses == 12)
            {
                CardClicker.IsStartGame = false;
                _countGuesses = 0;

                PlayerOptions.BestScore = Score.TimeScore;
                
                yield return new WaitForSeconds(.3f);
                GlobalEventSystem.OnUpdateGame.Invoke();                
            }
        }
        else
        {
            yield return new WaitForSeconds(.3f);
            _anotherCard.Close();
            card.Close();
        }

        _anotherCard = null;
        _isCardInProcess = false;
    }
}
