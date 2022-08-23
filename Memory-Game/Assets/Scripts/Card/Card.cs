using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _cardView;
    [SerializeField] private Animator _animator;
    
    public Image CardView { get { return _cardView; } } 
    public Animator Animator { get { return _animator; } }
    
    public ICardState State { get; set; }
    public int Id { get; set; }
    public Sprite FrontSprite { get; set; }
    public Sprite BackSprite { get; set; }
    
    public void Open()
    {
        State.Open(this);
    }

    public void Close()
    {
        State.Close(this);
    }

    public void Guess()
    {
        State.Guess(this);
    }

}
