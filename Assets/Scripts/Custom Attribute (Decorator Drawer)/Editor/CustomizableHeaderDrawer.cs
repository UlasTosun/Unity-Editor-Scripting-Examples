using UnityEngine;
using UnityEditor;



[CustomPropertyDrawer(typeof(HeaderAttribute))]
public class HeaderDrawer : DecoratorDrawer {

    private HeaderAttribute HeaderAttribute => attribute as HeaderAttribute;



    public override void OnGUI(Rect position) {

        GUIStyle style = new();
        style.fontSize = HeaderAttribute.FontSize;
        style.fontStyle = HeaderAttribute.FontStyle;
        style.normal.textColor = HeaderAttribute.Color;
        style.alignment = HeaderAttribute.TextAnchor;

        // Create a rect for the header which is a bit taller than the default height
        Rect rect = new(position.x, position.y + 15f, position.width, HeaderAttribute.FontSize * 1.3f);
        EditorGUI.DrawRect(rect, HeaderAttribute.BackgroundColor);

        if (HeaderAttribute.BackgroundColor != Color.clear)
            position.x += 2;
        
        EditorGUI.LabelField(rect, HeaderAttribute.Header, style);
    }



    public override float GetHeight()  {
        // Increase the height of the header to fit bigger font sizes
        return HeaderAttribute.FontSize * 1.3f + 18f;
    }



}
