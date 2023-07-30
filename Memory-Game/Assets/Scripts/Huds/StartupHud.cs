using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartupHud : MonoBehaviour, IHud, IPointerClickHandler
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _scoreField;

    public event Action OnClick;

    private void SetText()
    {
        _nameField.text = "MEMORY GAME";
        _scoreField.text = $"BEST SCORE: {PlayerOptions.BestScore}";
    }

    public void Close() => _canvasGroup.Close();

    public void Open()
    {
        _canvasGroup.Open();
        SetText();
    }

    public void OnPointerClick(PointerEventData eventData) => OnClick?.Invoke();    
}