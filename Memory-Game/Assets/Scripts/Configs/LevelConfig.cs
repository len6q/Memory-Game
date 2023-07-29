using UnityEngine;

[CreateAssetMenu(menuName = "Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _currentLevel;
    [SerializeField] private float _maxTimeValue;

    public int CurrentLevel => _currentLevel;
    public float TimeValue => _maxTimeValue;    
}