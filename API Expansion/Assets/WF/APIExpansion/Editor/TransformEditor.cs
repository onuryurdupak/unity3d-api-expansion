using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Transform))]
[CanEditMultipleObjects]
public class TransformEditor : Editor
{
    const float ResetButtonWidth = 20f;

    static readonly Vector3 DefaultPosition = Vector3.zero;
    static readonly Quaternion DefaultRotation = Quaternion.identity;
    static readonly Vector3 DefaultScale = Vector3.one;

    Editor defaultEditor;

    void OnEnable()
    {
        Type transformInspectorType = Type.GetType("UnityEditor.TransformInspector,UnityEditor");
        defaultEditor = CreateEditor(targets, transformInspectorType);
    }

    void OnDisable()
    {
        if (defaultEditor != null)
            DestroyImmediate(defaultEditor);
    }

    public override void OnInspectorGUI()
    {
        if (defaultEditor == null)
        {
            DrawDefaultInspector();
            return;
        }

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical();
        defaultEditor.OnInspectorGUI();
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical(GUILayout.Width(ResetButtonWidth));
        DrawResetButton("m_LocalPosition", DefaultPosition);
        DrawResetButton("m_LocalRotation", DefaultRotation);
        DrawResetButton("m_LocalScale", DefaultScale);
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
    }

    void DrawResetButton(string propertyName, Vector3 defaultValue)
    {
        SerializedProperty property = serializedObject.FindProperty(propertyName);
        bool isDefault = property.vector3Value == defaultValue;

        EditorGUI.BeginDisabledGroup(isDefault);
        if (GUILayout.Button(new GUIContent("R", "Reset to default value"), GUILayout.Width(ResetButtonWidth), GUILayout.Height(EditorGUIUtility.singleLineHeight)))
        {
            property.vector3Value = defaultValue;
            serializedObject.ApplyModifiedProperties();
        }
        EditorGUI.EndDisabledGroup();

        GUILayout.Space(EditorGUIUtility.standardVerticalSpacing);
    }

    void DrawResetButton(string propertyName, Quaternion defaultValue)
    {
        SerializedProperty property = serializedObject.FindProperty(propertyName);
        bool isDefault = property.quaternionValue == defaultValue;

        EditorGUI.BeginDisabledGroup(isDefault);
        if (GUILayout.Button(new GUIContent("R", "Reset to default value"), GUILayout.Width(ResetButtonWidth), GUILayout.Height(EditorGUIUtility.singleLineHeight)))
        {
            property.quaternionValue = defaultValue;
            serializedObject.ApplyModifiedProperties();
        }
        EditorGUI.EndDisabledGroup();

        GUILayout.Space(EditorGUIUtility.standardVerticalSpacing);
    }
}
