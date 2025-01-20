using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(Path))]
[CanEditMultipleObjects]
public class PathDrawer : Editor {

    Path Path => target as Path;



    public override void OnInspectorGUI() {
        serializedObject.Update(); // Update the serialized object to get the latest values from the script
        SerializedProperty points = serializedObject.FindProperty("Points");
        
        DrawDefaultInspector(); // Draw default inspector to be able to see the points list

        DrawTotalDistance(points);
        DrawMode();
        EditorGUILayout.Space(20);
        DrawClearButton();

        serializedObject.ApplyModifiedProperties(); // Apply the changes to the serialized object
    }



    public void OnSceneGUI() {

        // Draw the path as a series of lines
        for (int i = 0; i < Path.Points.Count - 1; i++) {
            Vector3 p1 = Path.Points[i];
            Vector3 p2 = Path.Points[i + 1];
            Handles.DrawLine(p1, p2); // Draw a line between sequential points
        }

        // Draw the points as handles and allow them to be moved
        for (int i = 0; i < Path.Points.Count; i++) {
            Vector3 point = Path.Points[i];
            EditorGUI.BeginChangeCheck(); // Start checking for changes
            Vector3 newPoint = Handles.PositionHandle(point, Quaternion.identity); // Draw a handle to move the point

            // Check if the point has changed
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(Path, "Move Point"); // Record the change for undo
                Path.Points[i] = newPoint; // Update the point in the list
            }
        }

    }



    private void DrawClearButton() {
        GUIStyle style = new (GUI.skin.button);
        style.fontSize = 24;
        style.fontStyle = FontStyle.Bold;
        Color originalColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.red; // Change the background color of GUI to the color of the button

        if (GUILayout.Button("Clear All", style))
            Path.ClearAll();

        GUI.backgroundColor = originalColor; // Reset the background color
    }



    private void DrawTotalDistance(SerializedProperty points) {
        float totalDistance = 0;

        for (int i = 0; i < points.arraySize - 1; i++) {
            SerializedProperty point1 = points.GetArrayElementAtIndex(i);
            SerializedProperty point2 = points.GetArrayElementAtIndex(i + 1);
            Vector3 p1 = point1.vector3Value;
            Vector3 p2 = point2.vector3Value;
            totalDistance += Vector3.Distance(p1, p2);
        }

        EditorGUILayout.LabelField("Total Distance", totalDistance.ToString());
    }



    private void DrawMode() {
        SerializedProperty pathType = serializedObject.FindProperty("_pathType");
        SerializedProperty repeatCount = serializedObject.FindProperty("_repeatCount");

        pathType.enumValueIndex = EditorGUILayout.Popup("Path Type", pathType.enumValueIndex, pathType.enumDisplayNames);

        if (pathType.enumValueIndex == (int)Path.PathType.Linear)
            repeatCount.intValue = EditorGUILayout.IntField("Repeat Count", repeatCount.intValue);

    }



}
