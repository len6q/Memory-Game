using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHud : MonoBehaviour, IHud
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _secondField;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private Button _showAdsButton;
    [SerializeField] private TextMeshProUGUI _showAdsButtonText;

    public Button CancelButton => _cancelButton;
    public Button ShowAdsButton => _showAdsButton;

    private void Show()
    {
        _nameField.text = Words.Time;
        _secondField.text = Words.Chance;        
    }

    public void Close() => _canvasGroup.Close();

    public void Open() 
    {
        Show();
        _canvasGroup.Open();
    }

    public void SetAdsText(float time) => _showAdsButtonText.text = $"{Words.Yes} (+{time} sec)";
    
    public void Inactive() => _canvasGroup.Inactive();    
}