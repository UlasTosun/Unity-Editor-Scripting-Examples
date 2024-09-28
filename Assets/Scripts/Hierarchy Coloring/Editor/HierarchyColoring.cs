using UnityEngine;
using UnityEditor;



[InitializeOnLoad]
public static class HierarchyColoring {



    // Static constructor of the class. It will be called when Unity Editor is loaded or scripts are compiled because of [InitializeOnLoad] attribute.
    static HierarchyColoring() {
        // Every time scripts are compiled, HierarchyColoring constructor will be called.
        // So, we need to remove the previous delegate to avoid multiple calls.
        EditorApplication.hierarchyWindowItemOnGUI -= HierarchyWindowItemOnGUI;

        // Then, we add the delegate to the EditorApplication.hierarchyWindowItemOnGUI event.
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }



    private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect) {
        // Get the GameObject by its instance ID.
        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        // If the GameObject is not null, change its background color in the Hierarchy window.
        if (gameObject != null && gameObject.name.Equals("Painted Object"))
            ChangeBackgroundColor(gameObject, selectionRect);
    }



    private static void ChangeBackgroundColor(GameObject gameObject, Rect selectionRect) {
        // Move the rectangle to the right to avoid overlapping with the GameObject's icon.
        selectionRect.x += 18;
        selectionRect.y += 1;

        // Set the background color of the GameObject in the Hierarchy window.
        EditorGUI.DrawRect(selectionRect, Color.red);

        // Set the label and text color of the GameObject in the Hierarchy window.
        GUIStyle style = new (EditorStyles.label);
        style.normal.textColor = Color.yellow;
        style.fontStyle = FontStyle.Bold;
        EditorGUI.LabelField(selectionRect, gameObject.name, style);
    }



}
