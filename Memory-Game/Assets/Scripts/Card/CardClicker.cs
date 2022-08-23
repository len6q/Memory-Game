using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CardClicker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Card _card;

    public static UnityEvent<Card> OnCardClick = new UnityEvent<Card>();
    public static bool IsStartGame { get; set; }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        IsStartGame = true;

        OnCardClick.Invoke(_card);
    }

}
