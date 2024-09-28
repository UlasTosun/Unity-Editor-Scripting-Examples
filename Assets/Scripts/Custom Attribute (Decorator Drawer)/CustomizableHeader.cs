using System;
using UnityEngine;




/// <summary>
/// Customizable header attribute.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
public class HeaderAttribute : PropertyAttribute {

    /// <summary>
    /// Header text.
    /// </summary>
    public readonly string Header;

    /// <summary>
    /// Font size.
    /// </summary>
    public readonly int FontSize;

    /// <summary>
    /// Color. For all available colors see:
    /// <para>https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html#ColorNames</para>
    /// </summary>
    public readonly Color Color;

    /// <summary>
    /// Background color. For all available colors see:
    /// <para>https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html#ColorNames</para>
    /// </summary>
    public readonly Color BackgroundColor;

    /// <summary>
    /// Text anchor.
    /// </summary>
    public readonly TextAnchor TextAnchor;

    /// <summary>
    /// Font style.
    /// </summary>
    public readonly FontStyle FontStyle;



    public HeaderAttribute(string header, string color = "LightBlue", string backgroundColor = "Transparent", int fontSize = 13,
        TextAnchor textAnchor = TextAnchor.MiddleLeft, FontStyle fontStyle = FontStyle.Bold) {

        Header = header;
        FontSize = fontSize;
        TextAnchor = textAnchor;
        FontStyle = fontStyle;

        if (ColorUtility.TryParseHtmlString(color, out Color c)) {
            Color = c;
        } else {
            Color = Color.black;
            Debug.LogWarning("Color " + color + " not found. Using black color.");
        }

        if (ColorUtility.TryParseHtmlString(backgroundColor, out Color bg)) {
            BackgroundColor = bg;
        } else {
            BackgroundColor = Color.clear;
            Debug.LogWarning("Background color " + backgroundColor + " not found. Using transparent background.");
        }
    }

}
