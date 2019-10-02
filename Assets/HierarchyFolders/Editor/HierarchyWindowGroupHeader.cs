using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class HierarchyWindowGroupHeader
{
    static HierarchyWindowGroupHeader()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }

    static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        if (gameObject != null && gameObject.name.StartsWith("111", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(235, 136, 157,255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("1", "").ToUpperInvariant());
        }
        else
        if (gameObject != null && gameObject.name.StartsWith("222", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(229, 241, 37, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("2", "").ToUpperInvariant());
        }
        else
        if (gameObject != null && gameObject.name.StartsWith("333", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(254, 192, 0, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("3", "").ToUpperInvariant());
        }
        else
        if (gameObject != null && gameObject.name.StartsWith("444", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(144, 239, 0, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("4", "").ToUpperInvariant());
        }
        else
        if (gameObject != null && gameObject.name.StartsWith("555", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(211, 53, 64,255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("5", "").ToUpperInvariant());
        }
        else
        if (gameObject != null && gameObject.name.StartsWith("666", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(163, 117, 182,255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("6", "").ToUpperInvariant());
        }
        else
        if (gameObject != null && gameObject.name.StartsWith("777", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(1, 138, 212, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("7", "").ToUpperInvariant());
        }
        else
        if (gameObject != null && gameObject.name.StartsWith("888", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(0, 149, 49, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("8", "").ToUpperInvariant());
        }
        else
        if (gameObject != null && gameObject.name.StartsWith("999", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(158, 152, 156, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("9", "").ToUpperInvariant());
        }
    }
}