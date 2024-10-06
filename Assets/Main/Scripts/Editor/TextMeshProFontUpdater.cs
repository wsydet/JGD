using UnityEngine;
using UnityEditor;
using TMPro;

[ExecuteInEditMode]
public class TextMeshProFontUpdater : EditorWindow
{
    private TMP_FontAsset newFont;

    [MenuItem("Tools/Update TextMeshPro Fonts")]
    public static void ShowWindow()
    {
        GetWindow<TextMeshProFontUpdater>("Update TextMeshPro Fonts");
    }

    private void OnGUI()
    {
        GUILayout.Label("Update TextMeshPro Fonts", EditorStyles.boldLabel);
        newFont = (TMP_FontAsset)EditorGUILayout.ObjectField("New Font", newFont, typeof(TMP_FontAsset), false);

        if (GUILayout.Button("Update Fonts"))
        {
            UpdateFonts();
        }
    }

    private void UpdateFonts()
    {
        if (newFont == null)
        {
            Debug.LogWarning("Please assign a new font before updating.");
            return;
        }

        // �������г����е� TextMeshPro ���
        TextMeshProUGUI[] textMeshPros = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI textMeshPro in textMeshPros)
        {
            // ��������
            textMeshPro.font = newFont;
            EditorUtility.SetDirty(textMeshPro);
        }

        Debug.Log($"Updated {textMeshPros.Length} TextMeshProUGUI components with new font.");
    }
}