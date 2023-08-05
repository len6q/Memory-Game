using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const string START_TRIGGER = "Start";
    
    [SerializeField] private Animator _transition;
    [SerializeField] private float _transitionTime = 1f;

    private static SceneLoader _instance;

    private void Start()
    {
        if (_instance == null) _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void LoadMain() => _instance.StartCoroutine(_instance.LoadLevel("Main"));       
    
    private IEnumerator LoadLevel(string nameScene)
    {
        _transition.SetTrigger(START_TRIGGER);
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(nameScene);
    }
}
