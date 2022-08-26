using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private CardChecker _cardChecker;
    [SerializeField] private float _timeCache = 60f;
    
    public static float TimeValue => _time;
    private static float _time;

    public static int TempLVL => _tempLvl;
    private static int _tempLvl;

    private void Start()
    {
        _tempLvl = 1;
        _cardChecker.OnUpdateGame += LevelUp;
    }

    private void Update()
    {
        if (!_cardChecker.IsStartGame)
        {            
            _time = _timeCache / _tempLvl;
            
            if (_time < 10)
            {
                _time = 10;
            }
            return;
        }                
        
        if(_time <= 0)
        {
            SceneLoader.LoadMain();
        }    

        _time -= Time.deltaTime;        
    }

    private void OnDestroy()
    {
        _cardChecker.OnUpdateGame -= LevelUp;
    }

    private void LevelUp()
    {
        _tempLvl++;
    }
}
