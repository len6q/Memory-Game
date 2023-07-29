using TMPro;
using UnityEngine;

public class DefenderHud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _scoreField;
       
    public void SetStartupInfo()
    {
        _nameField.text = "MEMORY GAME";
        _scoreField.text = $"BEST SCORE: {PlayerOptions.BestScore}";
    }

    public void SetInGameText(int currentLevel, float timeValue)
    {
        _nameField.text = $"LEVEL {currentLevel}";
        _scoreField.text = timeValue.ToString("0.0");
    }    

    public void SetTimerText(float timeValue) => 
        _scoreField.text = timeValue.ToString("0.0");
}
