using UnityEditor;
using UnityEngine;

public class ToolsMenu
{ 
    [MenuItem("Tools/Clear player prefs")]
    private static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clear player prefs");
    }

    [MenuItem("Tools/Set player prefs")]
    private static void SetPlayerScore()
    {
        PlayerOptions.BestScore = 3;
        Debug.Log("Set best score in player prefs");
    }
}
