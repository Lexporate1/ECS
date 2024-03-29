using System;
using UnityEditor;
using UnityEngine;

namespace Entitas.Unity.Editor
{
    public class AnimationCurveTypeDrawer : ITypeDrawer
    {
        public bool HandlesType(Type type) => type == typeof(AnimationCurve);

        public object DrawAndGetNewValue(Type memberType, string memberName, object value, object target) =>
            EditorGUILayout.CurveField(memberName, (AnimationCurve)value);
    }
}
