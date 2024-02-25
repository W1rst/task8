
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace CustomProject.Utils.Inspector
{
    [CustomPropertyDrawer(typeof(InspectorButtonAttribute))]
    public class InspectorButtonPropertyDrawer : PropertyDrawer
    {
        private const float Border = 0.1f;

        private MethodInfo _eventMethodInfo = null;

        public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
        {
            InspectorButtonAttribute inspectorButtonAttribute = (InspectorButtonAttribute)attribute;
            float border = (position.width * Border);
            Rect buttonRect = new Rect(
                position.x + border,
                position.y, 
                position.width - 2*border, 
                position.height);
            
            if (GUI.Button(buttonRect, label.text))
            {
                System.Type eventOwnerType = prop.serializedObject.targetObject.GetType();
                string eventName = inspectorButtonAttribute.MethodName;

                if (_eventMethodInfo == null)
                {
                    _eventMethodInfo = eventOwnerType.GetMethod(eventName,
                        BindingFlags.Instance |
                        BindingFlags.Static |
                        BindingFlags.Public |
                        BindingFlags.NonPublic);
                }

                if (_eventMethodInfo != null)
                    _eventMethodInfo.Invoke(prop.serializedObject.targetObject, null);
                else
                    Debug.LogWarning($"InspectorButton: Unable to find method {eventName} in {eventOwnerType}");
            }
        }
    }
}