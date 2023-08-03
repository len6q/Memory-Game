using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainHud : MonoBehaviour, IHud
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _scoreField;
    [SerializeField] private Image _tutorialHand;
    [SerializeField] private GridLayoutGroup _layoutGroup;
   
    public void SetInGameText(GameScenario gameScenario)
    {
        _nameField.text = $"{Words.Level} {gameScenario.CurrentLevel}";
        _scoreField.text = gameScenario.CurrentConfig.StartSeconds.ToString("0.0");
        _layoutGroup.constraintCount = gameScenario.CurrentConfig.ConstraintCount;
    }    

    public void SetTimerText(float timeValue) => _scoreField.text = timeValue.ToString("0.0");

    private void ShowTutorial() => _tutorialHand.gameObject.SetActive(PlayerOptions.IsShowTutorial);

    public void Open() 
    {
        ShowTutorial();
        _canvasGroup.Open();
    }
    
    public void Close() => _canvasGroup.Close();

    public void Inactive() => _canvasGroup.Inactive();    
}
