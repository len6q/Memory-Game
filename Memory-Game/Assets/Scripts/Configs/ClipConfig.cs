using UnityEngine;

[CreateAssetMenu(menuName = nameof(ClipConfig))]
public class ClipConfig : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private AudioClip _clip;

    public string Name => _name;
    public AudioClip Clip => _clip;
}