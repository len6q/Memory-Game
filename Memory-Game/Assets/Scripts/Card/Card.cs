using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Card : MonoBehaviour, ICardStateSwitcher
{
    [SerializeField] private Image _cardView;
    
    private Sprite _frontSprite;
    private Sprite _backSprite;

    private BaseCardState _currentState;
    private List<BaseCardState> _allStates;
    
    public int Id { get; private set; }

    public void Init(int id, Sprite frontSprite, Sprite backSprite)
    {
        Id = id;
        _frontSprite = frontSprite;
        _backSprite = backSprite;

        _allStates = new List<BaseCardState>()
        {
            new ClosedCardState(_cardView, this, _frontSprite),
            new OpenedCardState(_cardView, this, _backSprite),
            new GuessedCardState(_cardView, this, _backSprite)
        };
        _currentState = _allStates[0];
        _cardView.sprite = _backSprite;
    }

    public void Open() => _currentState.Open();    

    public void Close() => _currentState.Close();
    
    public void Guess() => _currentState.Guess();
    
    public bool TryOpen() => _currentState.TryOpen();
    
    public void SwitchState<T>() where T : BaseCardState
    {
        var state = _allStates.FirstOrDefault(s => s is T);        
        _currentState = state;
    }
}
