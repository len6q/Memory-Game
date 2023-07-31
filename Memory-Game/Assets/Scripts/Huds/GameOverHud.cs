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
        _nameField.text = "Время истекло";
        _secondField.text = "Получить второй шанс?";
        _showAdsButtonText.text = "Да";
    }

    public void Close() => _canvasGroup.Close();

    public void Open() 
    {
        Show();
        _canvasGroup.Open();
    }    
}