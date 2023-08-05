using UnityEngine;

[CreateAssetMenu(menuName = nameof(AudioConfig))]
public class AudioConfig : ScriptableObject
{
    [SerializeField] private ClipConfig[] _audioClips;
    [SerializeField] private AudioClip _music;

    public ClipConfig[] AudioClips => _audioClips;
    public AudioClip Music => _music;
}