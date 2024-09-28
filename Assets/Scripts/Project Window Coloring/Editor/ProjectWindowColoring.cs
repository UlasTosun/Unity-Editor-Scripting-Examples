using UnityEngine;
using UnityEditor;
using UnityEngine.UI;



[InitializeOnLoad]
public static class ProjectWindowColoring {



    // Static constructor of the class. It will be called when Unity Editor is loaded or scripts are compiled because of [InitializeOnLoad] attribute.
    static ProjectWindowColoring() {
        // Every time scripts are compiled, HierarchyColoring constructor will be called.
        // So, we need to remove the previous delegate to avoid multiple calls.
        EditorApplication.projectWindowItemOnGUI -= ProjectWindowItemOnGUI;

        // Then, we add the delegate to the EditorApplication.hierarchyWindowItemOnGUI event.
        EditorApplication.projectWindowItemOnGUI += ProjectWindowItemOnGUI;
    }



    private static void ProjectWindowItemOnGUI(string guid, Rect selectionRect) {
        string assetPath = AssetDatabase.GUIDToAssetPath(guid); // Get the asset path by its GUID.

        // If the asset path is a folder, return.
        if (AssetDatabase.IsValidFolder(assetPath))
            return;

        Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath); // Load the asset by its path.

        // If the asset is null, return.
        if (asset == null)
            return;

        // If the asset is a C# script, change its background color in the Project window.
        if (assetPath.EndsWith(".cs"))
            ChangeBackgroundColor(asset, selectionRect);

    }



    private static void ChangeBackgroundColor(Object asset, Rect selectionRect) {
        
        // Move the rectangle to the right to avoid overlapping with the GameObject's icon.
        selectionRect.x -= 3;
        selectionRect.y += 71;
        selectionRect.height = 13;

        // Set the background color of the GameObject in the Hierarchy window.
        EditorGUI.DrawRect(selectionRect, Color.red);

        // Set the label and text color of the GameObject in the Hierarchy window.
        GUIStyle style = new(EditorStyles.label);
        style.normal.textColor = Color.yellow;
        style.fontSize = 10;
        EditorGUI.LabelField(selectionRect, asset.name, style);

    }


}
