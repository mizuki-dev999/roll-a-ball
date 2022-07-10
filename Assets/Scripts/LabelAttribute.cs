using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LabelAttribute : PropertyAttribute
{
    public readonly string Label;
    public LabelAttribute(string label)
    {
        Label = label;
    }
}
[CustomPropertyDrawer(typeof(LabelAttribute))]
public class LabelAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var newLabel = attribute as LabelAttribute;
        EditorGUI.PropertyField(position, property, new GUIContent(newLabel.Label), true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, true);
    }
}
