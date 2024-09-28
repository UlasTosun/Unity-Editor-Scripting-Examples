using UnityEngine;
using UnityEditor;



/// <summary>
/// Customizable header drawer.
/// </summary>
[CustomPropertyDrawer(typeof(HeaderAttribute))]
public class HeaderDrawer : DecoratorDrawer {

    private HeaderAttribute HeaderAttribute => attribute as HeaderAttribute;



    public override void OnGUI(Rect position) {

        GUIStyle style = new();
        style.fontSize = HeaderAttribute.FontSize;
        style.fontStyle = HeaderAttribute.FontStyle;
        style.normal.textColor = HeaderAttribute.Color;
        style.alignment = HeaderAttribute.TextAnchor;

        Rect rect = new(position.x, position.y + 15f, position.width, HeaderAttribute.FontSize * 1.3f);
        EditorGUI.DrawRect(rect, HeaderAttribute.BackgroundColor);

        if (HeaderAttribute.BackgroundColor != Color.clear)
            position.x += 2;
        
        EditorGUI.LabelField(rect, HeaderAttribute.Header, style);
    }



    public override float GetHeight()  {
        return HeaderAttribute.FontSize * 1.3f + 18f;
    }



}
