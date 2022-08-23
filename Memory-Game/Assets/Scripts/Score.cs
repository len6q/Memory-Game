using UnityEngine;

public class Score : MonoBehaviour
{
    public static float TimeScore { get { return _score; } }
    
    private static float _score;

    private void Update()
    {
        if (!CardClicker.IsStartGame)
        {
            _score = 0f;
            return;
        }                
        
        _score += Time.deltaTime;      
    }
}
