
# Unity Editor Scripting Examples

This repository contains basic examples for editor scripting in Unity. Example cases are from basic to intermediate levels and don't cover advanced topics.

If you are looking for advanced examples, I have two assets in my [Unity Asset Store publisher account](https://assetstore.unity.com/publishers/115934): [Hierarchy Focused Debug Console](https://u3d.as/3wJE) and [Easy Handles Attributes](https://u3d.as/3y9X). Both are free and have source code available.

## Example Cases

**Custom Attribute with Decorator Drawer:** An example which demonstrates the usage of decorator drawer for custom attributes. It provides a customizable header attribute.

**Custom Attribute with Property Drawer:** An example which demonstrates the usage of property drawer for custom attributes. It provides an automatic frequency calculator attribute.

**Custom GUI for Classes:** An example which demonstrates the usage of property drawer for serializable classes to be able to customize their GUI in the inspector.

**Custom GUI and Scene View for Mono Behaviors:** An example which demonstrates the customization of the GUI of a Mono Behavior in the inspector and its view in the scene. It provides a path behavior whose points can be edited directly in the scene and whose total length is displayed in the inspector. 

**Custom Editor Window:** An example which demonstrates the creation of a custom editor window. It provides an example window with numerous fields such as property fields, list view with serialized objects, object field and toggle groups.

**Custom Hierarchy:** An example which demonstrates the customization of the hierarchy window. It provides an example to colorize specific items in the hierarchy.

**Custom Project Window:** An example which demonstrates the customization of the project window. It provides an example to colorize specific items in the project window. 

## Notes

1)	To open example editor window: Window -> Custom Window
2)	Custom editor window case uses [GUI Skin](https://docs.unity3d.com/Manual/class-GUISkin.html) as an example. GUI Skin allows customization of the skin in the inspector. However, you don’t have to use it, it’s just an example.
3)	Example editor window doesn’t save the fields, so fields will be reset when it is reopened. [Scriptable Objects](https://docs.unity3d.com/Manual/class-ScriptableObject.html) can be used to be able to save fields, just like Unity does.
