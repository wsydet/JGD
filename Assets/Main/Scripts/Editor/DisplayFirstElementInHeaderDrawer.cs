#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Utilities
{
    public class DisplayFirstElementInHeaderAttribute : PropertyAttribute
    {
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(DisplayFirstElementInHeaderAttribute))]
    public class DisplayFirstElementInHeaderDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            if (property.propertyType == SerializedPropertyType.Generic)
            {
                SerializedProperty firstChildProperty = property.Copy();
                bool hasNext = firstChildProperty.NextVisible(true); // Move to the first child
                if (hasNext)
                {
                    string header = GetPropertyValueAsString(firstChildProperty);
                    //Debug.Log("绘制 " + header);
                    label.text = header;
                }
            }

            EditorGUI.PropertyField(position, property, label, true);
        }

        private string GetPropertyValueAsString(SerializedProperty prop)
        {
            switch (prop.propertyType)
            {
                case SerializedPropertyType.Integer:
                    return prop.intValue.ToString();
                case SerializedPropertyType.Boolean:
                    return prop.boolValue.ToString();
                case SerializedPropertyType.Float:
                    return prop.floatValue.ToString("F2");
                case SerializedPropertyType.String:
                    return prop.stringValue;
                case SerializedPropertyType.Enum:
                    return prop.enumNames[prop.enumValueIndex];
                case SerializedPropertyType.ObjectReference:
                    return prop.objectReferenceValue != null ? prop.objectReferenceValue.name : "Null";
                case SerializedPropertyType.Vector2:
                    return prop.vector2Value.ToString();
                case SerializedPropertyType.Vector3:
                    return prop.vector3Value.ToString();
                // 你可以继续添加更多类型的处理方式
                default:
                    return prop.type + ": Unsupported type";
            }
        }
    }
#endif
}
