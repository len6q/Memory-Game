using UnityEngine.UI;

public abstract class BaseState
{
    protected readonly ICardStateSwitcher _stateCardSwitcher;   
    protected readonly Image _cardView;
    
    protected BaseState(Image cardView, ICardStateSwitcher stateCardSwitcher)
    {        
        _cardView = cardView;
        _stateCardSwitcher = stateCardSwitcher;
    }

    public abstract void Open();
   
    public abstract void Close();
    
    public abstract void Guess();
    
    public abstract bool TryOpen();

}
