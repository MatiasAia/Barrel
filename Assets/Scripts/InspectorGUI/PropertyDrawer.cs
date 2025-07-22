#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIf = attribute as ShowIfAttribute;
        SerializedProperty condicionProp = property.serializedObject.FindProperty(showIf.condicion);

        if (condicionProp != null && condicionProp.propertyType == SerializedPropertyType.Boolean)
        {
            if (condicionProp.boolValue)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }
        else
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIf = attribute as ShowIfAttribute;
        SerializedProperty condicionProp = property.serializedObject.FindProperty(showIf.condicion);

        if (condicionProp != null && condicionProp.propertyType == SerializedPropertyType.Boolean)
        {
            return condicionProp.boolValue ? EditorGUI.GetPropertyHeight(property, label, true) : 0;
        }

        return EditorGUI.GetPropertyHeight(property, label, true);
    }
}
#endif