using UnityEngine;

public class PlayerOptions
{
    public static float BestScore
    {
        get
        {
            return PlayerPrefs.GetFloat("BestScore");
        }
        set
        {
            if (!PlayerPrefs.HasKey("BestScore"))            
                PlayerPrefs.SetFloat("BestScore", 0);
            
            if (value > PlayerPrefs.GetFloat("BestScore"))
                PlayerPrefs.SetFloat("BestScore", value);
        }
    }
}
