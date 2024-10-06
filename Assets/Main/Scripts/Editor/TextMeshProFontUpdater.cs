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

        // 查找所有场景中的 TextMeshPro 组件
        TextMeshProUGUI[] textMeshPros = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI textMeshPro in textMeshPros)
        {
            // 更新字体
            textMeshPro.font = newFont;
            EditorUtility.SetDirty(textMeshPro);
        }

        Debug.Log($"Updated {textMeshPros.Length} TextMeshProUGUI components with new font.");
    }
}