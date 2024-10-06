using UnityEditor;
using UnityEngine;

public class ClearPlayerPrefsWindow : EditorWindow
{
    [MenuItem("Tools/Clear PlayerPrefs")]
    public static void ShowWindow()
    {
        GetWindow<ClearPlayerPrefsWindow>("Clear PlayerPrefs");
    }

    private void OnGUI()
    {
        GUILayout.Label("Clear PlayerPrefs", EditorStyles.boldLabel);

        if (GUILayout.Button("Clear All PlayerPrefs"))
        {
            ClearPlayerPrefs();
        }
    }

    private void ClearPlayerPrefs()
    {
        if (EditorUtility.DisplayDialog("Confirm Clear", "Are you sure you want to clear all PlayerPrefs data?", "Yes", "No"))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("All PlayerPrefs data has been cleared.");
        }
    }
}