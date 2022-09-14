using UnityEngine;

public class PlayerOptions
{
    public static int BestScore
    {
        get => PlayerPrefs.GetInt("BestScore");        
        set
        {
            if (!PlayerPrefs.HasKey("BestScore"))            
                PlayerPrefs.SetInt("BestScore", 0);
            
            if (value > BestScore)
                PlayerPrefs.SetInt("BestScore", value);
        }
    }
}
