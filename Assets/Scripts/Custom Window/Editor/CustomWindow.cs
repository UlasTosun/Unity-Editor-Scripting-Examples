using UnityEngine;
using UnityEditor;



public class CustomWindow : EditorWindow {

    [SerializeField] private GUISkin _skin;

    private string _name = "John Doe";
    private Material _material;
    private bool _groupEnabled;



    [MenuItem("Window/Custom Window")]
    public static void ShowWindow() {
        GetWindow<CustomWindow>("Custom Window");
    }



    private void OnGUI() {
        GUI.skin = _skin;

        
        GUILayout.Label("This is a custom window", EditorStyles.boldLabel);
        GUILayout.Space(10);

        // Get string input
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name: ");
        GUILayout.Space(10);
        _name = GUILayout.TextField(_name, 20);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        // Get object input
        GUILayout.BeginHorizontal();
        _material = (Material)EditorGUILayout.ObjectField("Material: " ,_material, typeof(Material), false);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        // Optional settings (visible only when the toggle is enabled)
        _groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", _groupEnabled);
        GUILayout.Label("This is visible only when the toggle is enabled.");
        GUILayout.Toggle(true, "My toggle");
        EditorGUILayout.Toggle("Another toggle", true);
        EditorGUILayout.Slider(0.5f, 0, 1);
        EditorGUILayout.EndToggleGroup();

        if (GUILayout.Button("Press me")) {
            Debug.Log("Button pressed");
        }
    }



}
