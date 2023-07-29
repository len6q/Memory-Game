using UnityEngine;

public class PlayerOptions
{
    private const string BEST_SCORE = "BestScore";

    public static int BestScore
    {
        get => PlayerPrefs.GetInt(BEST_SCORE);        
        set
        {
            if (!PlayerPrefs.HasKey(BEST_SCORE))            
                PlayerPrefs.SetInt(BEST_SCORE, 0);
            
            if (value > BestScore)
                PlayerPrefs.SetInt(BEST_SCORE, value);
        }
    }
}
