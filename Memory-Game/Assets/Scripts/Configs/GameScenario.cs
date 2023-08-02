using UnityEngine;

[CreateAssetMenu(menuName = "Game Scenario")]
public class GameScenario : ScriptableObject
{
    [SerializeField] private LevelConfig[] _levelConfigs;
    [SerializeField] private int _firstLevelIndex = 0;

    public LevelConfig CurrentLevel => _levelConfigs[_firstLevelIndex]; 
    public LevelConfig NextLevel => _levelConfigs[_firstLevelIndex++];
}