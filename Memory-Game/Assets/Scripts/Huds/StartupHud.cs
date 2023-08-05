using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartupHud : MonoBehaviour, IHud, IPointerClickHandler
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _scoreField;
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _musicButton;

    public event Action OnClick;
    
    public void Open()
    {
        _canvasGroup.Open();
        SetText();
        _soundButton.onClick.AddListener(ChangeSound);
        _musicButton.onClick.AddListener(ChangeMusic);
    }

    public void Close()
    {
        _canvasGroup.Close();
        _soundButton.onClick.RemoveListener(ChangeSound);
        _musicButton.onClick.RemoveListener(ChangeMusic);
    }

    public void OnPointerClick(PointerEventData eventData) => OnClick?.Invoke();

    public void Inactive() => _canvasGroup.Inactive();

    private void SetText()
    {
        _nameField.text = Words.GameName;
        _scoreField.text = $"{Words.BestScore} {PlayerOptions.BestScore}";

        _soundButton.SetImage(PlayerOptions.IsPlaySounds);
        _musicButton.SetImage(PlayerOptions.IsPlayMusic);
    }

    private void ChangeSound()
    {
        PlayerOptions.IsPlaySounds = !PlayerOptions.IsPlaySounds;
        _soundButton.SetImage(PlayerOptions.IsPlaySounds);
    }

    private void ChangeMusic()
    {
        PlayerOptions.IsPlayMusic = !PlayerOptions.IsPlayMusic;
        _musicButton.SetImage(PlayerOptions.IsPlayMusic);
        AudioSystem.PlayMusic();
    }
}