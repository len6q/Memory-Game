using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Card : MonoBehaviour, ICardStateSwitcher
{
    [SerializeField] private Image _cardView;
    [SerializeField] private Animator _animator;

    public int Id => _id;
    private int _id;
    
    private Sprite _frontSprite;
    private Sprite _backSprite;

    private BaseState _currentState;
    private List<BaseState> _allStates;

    public void Init(int id, Sprite frontSprite, Sprite backSprite)
    {
        _id = id;
        _frontSprite = frontSprite;
        _backSprite = backSprite;

        _allStates = new List<BaseState>()
        {
            new ClosedCardState(_cardView, this, _frontSprite),
            new OpenedCardState(_cardView, this, _backSprite),
            new GuessedCardState(_cardView, this, _backSprite)
        };
        _currentState = _allStates[0];
        _cardView.sprite = _backSprite;
    }

    public void Open()
    {
        _currentState.Open();
    }

    public void Close()
    {
        _currentState.Close();
    }

    public void Guess()
    {
        _currentState.Guess();
    }

    public bool TryOpen()
    {
        return _currentState.TryOpen();
    }

    public void SwitchState<T>() where T : BaseState
    {
        var state = _allStates.FirstOrDefault(s => s is T);        
        _currentState = state;
    }
}
