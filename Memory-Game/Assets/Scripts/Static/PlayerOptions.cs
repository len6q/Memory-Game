using UnityEngine;

public class PlayerOptions
{
    private const string BEST_SCORE = "BestScore";
    private const string SHOW_TUTOR = "Tutorial";
    private const string PLAY_SOUNDS = "PlaySounds";
    private const string PLAY_MUSIC = "PlayMusic";

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

    public static bool IsPlaySounds
    {
        get => PlayerPrefs.GetInt(PLAY_SOUNDS) == 0;
        set
        {
            if(value) PlayerPrefs.SetInt(PLAY_SOUNDS, 0);                
            else PlayerPrefs.SetInt(PLAY_SOUNDS, -1);            
        }
    }

    public static bool IsPlayMusic
    {
        get => PlayerPrefs.GetInt(PLAY_MUSIC) == 0;
        set
        {
            if (value) PlayerPrefs.SetInt(PLAY_MUSIC, 0);
            else PlayerPrefs.SetInt(PLAY_MUSIC, -1);
        }
    }
}
