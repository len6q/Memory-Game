using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardClicker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Card _card;

    public static event Action<Card> OnCardClick;

    public void OnPointerClick(PointerEventData eventData) =>
        OnCardClick?.Invoke(_card);    
}
