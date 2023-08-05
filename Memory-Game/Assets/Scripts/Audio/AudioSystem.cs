using System.Linq;
using UnityEngine;
using Zenject;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundSource;
    [SerializeField] private AudioSource _soundsSource;

    private static AudioSystem _instance;
    private AudioConfig _config;

    [Inject]
    private void Construct(AudioConfig audioConfig)
    {
        _config = audioConfig;
    }

    private void Start()
    {
        if(_instance == null) _instance = this;
        
        _backgroundSource.clip = _config.Music;
        if(PlayerOptions.IsPlayMusic) _backgroundSource.Play();
        
        DontDestroyOnLoad(gameObject);
    }

    public static void PlaySound(string objectName)
    {
        if (PlayerOptions.IsPlaySounds == false) return;

        var clipConfig = _instance._config.AudioClips
            .FirstOrDefault(clip => clip.Name.Equals(objectName));
        if(clipConfig == null) return;

        _instance._soundsSource.PlayOneShot(clipConfig.Clip);        
    }

    public static void PlayMusic(bool isShowAds = false)
    {
        if (isShowAds)
        {
            _instance._backgroundSource.Stop();
        }
        else
        {
            if (PlayerOptions.IsPlayMusic) _instance._backgroundSource.Play();
            else _instance._backgroundSource.Stop();
        }
    }
}