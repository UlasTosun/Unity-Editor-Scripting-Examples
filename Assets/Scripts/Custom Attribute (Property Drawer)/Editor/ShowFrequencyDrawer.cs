using UnityEngine;
using UnityEditor;



[CustomPropertyDrawer(typeof(ShowFrequencyAttribute))]
public class ShowFrequencyDrawer : PropertyDrawer {

    private ShowFrequencyAttribute ShowFrequencyAttribute => attribute as ShowFrequencyAttribute;



    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        float frequencyWidth = 60f;
        Rect propertyRect = new(position.x, position.y, position.width - frequencyWidth, position.height);
        Rect frequencyRect = new(position.x + position.width - frequencyWidth, position.y, frequencyWidth, position.height);

        // Begin property
        EditorGUI.BeginProperty(position, label, property);

        // Long is also considered as integer by Unity Editor
        if (property.propertyType == SerializedPropertyType.Integer) {
            property.intValue = EditorGUI.IntField(propertyRect, label.text, property.intValue);
            DrawFrequency(frequencyRect, property);


        // Double is also considered as float by Unity Editor
        } else if (property.propertyType == SerializedPropertyType.Float) {
            property.floatValue = EditorGUI.FloatField(propertyRect, label.text, property.floatValue);
            DrawFrequency(frequencyRect, property);

        } else {
            GUIStyle style = new(EditorStyles.label);
            style.normal.textColor = Color.red;
            EditorGUI.LabelField(position, label.text, "Use ShowFrequency only with numeric fields.", style);
        }

        // End property
        EditorGUI.EndProperty();

    }



    private void DrawFrequency(Rect position, SerializedProperty property) {
        LimitTime(property);
        float time = property.propertyType == SerializedPropertyType.Integer ? property.intValue : property.floatValue;
        float frequency = 1f / time;
        string frequencyText = $"{frequency:0.###}" + (ShowFrequencyAttribute.ShowUnit ? " Hz" : "");

        GUIStyle style = new(EditorStyles.label);
        style.alignment = TextAnchor.MiddleRight;
        EditorGUI.LabelField(position, frequencyText, style);
    }



    private void LimitTime(SerializedProperty property) {
        if (property.propertyType == SerializedPropertyType.Integer)
            property.intValue = Mathf.Max(0, property.intValue);
        else
            property.floatValue = Mathf.Max(0f, property.floatValue);
    }



}
