using UnityEngine;

[CreateAssetMenu(menuName = "Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _currentLevel;
    [SerializeField] private float _maxTimeValue;
    [SerializeField] private int _cardsCount;

    public int CurrentLevel => _currentLevel;
    public float TimeValue => _maxTimeValue;    
    public int CardsCount => _cardsCount;    
}