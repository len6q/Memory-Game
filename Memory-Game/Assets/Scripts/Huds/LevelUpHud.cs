using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpHud : MonoBehaviour, IHud
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _secondField;    
    [SerializeField] private Button _loadNextLevelButton;
    [SerializeField] private TextMeshProUGUI _loadNextLevelText;
    
    public Button LoadNextLevelButton => _loadNextLevelButton;

    private void Show()
    {
        _nameField.text = "�� �������!";
        _secondField.text = "� ���� ������� ������!";
        _loadNextLevelText.text = "������";
    }

    public void Close() => _canvasGroup.Close();

    public void Open()
    {
        Show();
        _canvasGroup.Open();
    }
}