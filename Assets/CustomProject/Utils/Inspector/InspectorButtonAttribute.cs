
using UnityEngine;

namespace CustomProject.Utils.Inspector
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class InspectorButtonAttribute : PropertyAttribute
    {
        public readonly string MethodName;

        public InspectorButtonAttribute(string MethodName)
        {
            this.MethodName = MethodName;
        }
    }
}