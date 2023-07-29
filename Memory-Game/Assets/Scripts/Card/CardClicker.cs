using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardClicker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Card _card;

    public static event Action<Card> OnCardClick;

    public static bool IsFirstClick { get; set; } = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(IsFirstClick == false) IsFirstClick = true;
        OnCardClick?.Invoke(_card);
    }
}
