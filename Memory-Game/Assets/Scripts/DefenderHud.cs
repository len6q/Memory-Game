using TMPro;
using UnityEngine;
using Zenject;

public class DefenderHud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _scoreField;
    
    private Level _level;

    [Inject]
    private void Construct(Level level)
    {
        _level = level;
    }
    
    public void Start()
    {
        _nameField.text = "MEMORY GAME";
        _scoreField.text = "BEST SCORE: " + PlayerOptions.BestScore;
    }

    public void Update()
    {
        if (CardClicker.IsFirstClick == false && _level.Current == 1) return;
        
        SetInGameText();
    }

    private void SetInGameText()
    {
        _nameField.text = "LEVEL " + _level.Current;
        _scoreField.text = _level.Time.ToString("0.0");
    }    
}
