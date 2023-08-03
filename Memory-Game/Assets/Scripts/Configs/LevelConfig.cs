using UnityEngine;

[CreateAssetMenu(menuName = "Level Config")]
public class LevelConfig : ScriptableObject
{    
    [SerializeField] private float _startSeconds;
    [SerializeField] private int _cardsCount;
    [SerializeField] private int _constraintCount;
 
    public float StartSeconds => _startSeconds;    
    public int CardsCount => _cardsCount;    
    public int ConstraintCount => _constraintCount;    
}