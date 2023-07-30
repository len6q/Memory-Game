using UnityEngine;

public class PlayerOptions
{
    private const string BEST_SCORE = "BestScore";
    private const string SHOW_TUTOR = "Tutorial";

    public static int BestScore
    {
        get => PlayerPrefs.GetInt(BEST_SCORE);
        set
        {
            if (PlayerPrefs.HasKey(BEST_SCORE) == false)
                PlayerPrefs.SetInt(BEST_SCORE, 0);

            if (value > BestScore)
                PlayerPrefs.SetInt(BEST_SCORE, value);
        }
    }

    public static bool IsShowTutorial
    {
        get
        {
            if (PlayerPrefs.HasKey(SHOW_TUTOR) == false)
            {
                PlayerPrefs.SetInt(SHOW_TUTOR, 0);
                return true;
            }
            return false;
        }
    }
}
