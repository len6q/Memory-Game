using UnityEngine;
using TMPro;

public class GameView : MonoBehaviour
{
    [SerializeField] private CardChecker _cardChecker;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _nameText.text = "MEMORY GAME";
        _scoreText.text = "BEST SCORE: " + PlayerOptions.BestScore;        
    }

    private void Update()
    {
        if(!_cardChecker.IsStartGame && Score.TempLVL == 1)
        {
            return;
        }        
            
        SetInGameText();        
    }

    private void SetInGameText()
    {
        _nameText.text = "LEVEL " + Score.TempLVL;
        _scoreText.text = Score.TimeValue.ToString("0.0");
    }
}
