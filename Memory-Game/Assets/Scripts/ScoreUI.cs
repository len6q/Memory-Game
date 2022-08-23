using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour
{    
    private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        
        SetBestScoreText();
        
        GlobalEventSystem.OnUpdateGame.AddListener(SetBestScoreText);
    }

    private void Update()
    {
        if (!CardClicker.IsStartGame)        
            return;        

        _scoreText.text = Score.TimeScore.ToString("0.0");
    }

    private void SetBestScoreText()
    {
        _scoreText.text = "BEST SCORE: " + PlayerOptions.BestScore.ToString("0.0");
    }

}
