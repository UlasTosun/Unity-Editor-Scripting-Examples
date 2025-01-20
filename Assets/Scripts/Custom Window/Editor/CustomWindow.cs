using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class CustomWindow : EditorWindow {

    [SerializeField] private GUISkin _skin; // Use a GUISkin for the window to be able to edit the style in the inspector

    private string _name = "John Doe";
    [SerializeField] private List<string> _nameList = new(); // Lists should be serialized to be displayed in the inspector
    private Material _material;
    private bool _groupEnabled;



    [MenuItem("Window/Custom Window")]
    public static void ShowWindow() {
        GetWindow<CustomWindow>("Custom Window");
    }



    private void OnGUI() {
        GUI.skin = _skin; // Apply the GUISkin to the window

        GUILayout.BeginVertical();

        // Display label
        GUILayout.Label("This is a custom window", EditorStyles.boldLabel);

        GUILayout.Space(10);

        // Display text field
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name: ");
        GUILayout.Space(10);
        _name = GUILayout.TextField(_name, 20);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        // Display list
        SerializedProperty targets = new SerializedObject(this).FindProperty(nameof(_nameList));
        GUIContent labelField = new("Name List");
        EditorGUILayout.PropertyField(targets, labelField, true);
        targets.serializedObject.ApplyModifiedProperties();

        GUILayout.Space(10);

        // Display object field
        _material = (Material)EditorGUILayout.ObjectField("Material: " ,_material, typeof(Material), false);

        GUILayout.Space(10);

        // Display toggle group
        // Optional settings (visible only when the toggle is enabled)
        _groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", _groupEnabled);
        GUILayout.Label("This is visible only when the toggle is enabled.");
        GUILayout.Toggle(true, "My toggle");
        EditorGUILayout.Toggle("Another toggle", true);
        EditorGUILayout.Slider(0.5f, 0, 1);
        EditorGUILayout.EndToggleGroup();

        GUILayout.Space(10);

        // Display button
        if (GUILayout.Button("Press me"))
            Debug.Log("Button pressed!");

        GUILayout.EndVertical();
    }



}
