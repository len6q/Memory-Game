using UnityEngine;

public class PlayerOptions : MonoBehaviour
{    
    public PlayerData PlayerData;
    
    private static PlayerOptions _instance;

    public static int BestScore
    {
        get => _instance.PlayerData.BestScore;
        set
        {
            if(value > _instance.PlayerData.BestScore)
            {
                _instance.PlayerData.BestScore = value;
                Dll.SetToLeaderboard(value);
            }
        }
    }

    public static bool IsShowTutorial
    {
        get 
        {
            bool isShow = _instance.PlayerData.IsShowTutorial;
            if (isShow) _instance.PlayerData.IsShowTutorial = false;            
            return isShow;
        }
    }

    public static bool IsPlaySounds
    {
        get => _instance.PlayerData.IsPlaySounds;
        set => _instance.PlayerData.IsPlaySounds = value;
    }

    public static bool IsPlayMusic
    {
        get => _instance.PlayerData.IsPlayMusic;
        set => _instance.PlayerData.IsPlayMusic = value;
    }

    private void Awake() 
    {
        if(_instance == null) _instance = this;
        Dll.Load();
    }
    
    public static void Save()
    {
        string jsonString = JsonUtility.ToJson(_instance.PlayerData);
        Dll.Save(jsonString);
    }

    public void Load(string date) => _instance.PlayerData = JsonUtility.FromJson<PlayerData>(date);

    public void OpenAds() => AudioSystem.PlayMusic(true);

    public void CloseAds() => AudioSystem.PlayMusic();
}
