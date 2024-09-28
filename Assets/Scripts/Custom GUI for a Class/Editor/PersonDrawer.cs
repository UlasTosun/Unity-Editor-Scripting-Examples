using UnityEngine;
using UnityEditor;



[CustomPropertyDrawer(typeof(Person))]
public class PersonDrawer : PropertyDrawer {



    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

        // Begin property
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        label.text += " (Name | Surname | Age)";
        label.tooltip = "Name | Surname | Age";
        Rect labelRect = new (position.x, position.y, EditorGUIUtility.currentViewWidth, EditorGUIUtility.singleLineHeight);
        EditorGUI.LabelField(labelRect, label); // Use PrefixLabel instead of LabelField to show the label if it is shorter

        // Get properties
        SerializedProperty name = property.FindPropertyRelative("Name");
        SerializedProperty surname = property.FindPropertyRelative("Surname");
        SerializedProperty age = property.FindPropertyRelative("Age");

        // Calculate rects
        float width = EditorGUIUtility.currentViewWidth * 0.3f;
        float height = EditorGUIUtility.singleLineHeight;
        float step = EditorGUIUtility.currentViewWidth * 0.333f;
        Rect nameRect = new (position.x, position.y + EditorGUIUtility.singleLineHeight, width, height);
        Rect surnameRect = new (position.x + step, position.y + EditorGUIUtility.singleLineHeight, width, height);
        Rect ageRect = new (position.x + step * 2f, position.y + EditorGUIUtility.singleLineHeight, width, height);

        // Change text color
        GUIStyle style = new(EditorStyles.textField); // Initialize a new GUIStyle with the default text field style
        style.normal.textColor = Color.red; // Change the text color to red
        style.focused.textColor = Color.red; // Change the text color to red when the text field is focused
        style.hover.textColor = Color.red; // Change the text color to red when the mouse is over the text field

        // Draw properties
        name.stringValue = EditorGUI.TextField(nameRect, name.stringValue, style);
        surname.stringValue = EditorGUI.TextField(surnameRect, surname.stringValue, style);
        age.intValue = EditorGUI.IntField(ageRect, age.intValue, style);

        // Validate age
        if (age.intValue < 0) {
            age.intValue = 0;
        }

        // End property
        EditorGUI.EndProperty();

    }



    // Override the height of the property
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return EditorGUIUtility.singleLineHeight * 2;
    }




}
