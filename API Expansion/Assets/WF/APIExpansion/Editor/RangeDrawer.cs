using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(FloatRange))]
[CustomPropertyDrawer(typeof(IntRange))]
public class RangeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        SerializedProperty minProperty = property.FindPropertyRelative("Min");
        SerializedProperty maxProperty = property.FindPropertyRelative("Max");

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        const float labelWidth = 30f;
        const float spacing = 4f;
        float fieldWidth = (position.width - 2 * labelWidth - spacing) / 2f;

        Rect minLabelRect = new(position.x, position.y, labelWidth, position.height);
        Rect minFieldRect = new(minLabelRect.xMax, position.y, fieldWidth, position.height);
        Rect maxLabelRect = new(minFieldRect.xMax + spacing, position.y, labelWidth, position.height);
        Rect maxFieldRect = new(maxLabelRect.xMax, position.y, fieldWidth, position.height);

        EditorGUI.LabelField(minLabelRect, "Min");
        EditorGUI.PropertyField(minFieldRect, minProperty, GUIContent.none);

        EditorGUI.LabelField(maxLabelRect, "Max");
        EditorGUI.PropertyField(maxFieldRect, maxProperty, GUIContent.none);

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
