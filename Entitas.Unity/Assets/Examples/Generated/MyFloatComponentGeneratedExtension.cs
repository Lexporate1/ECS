//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

namespace Entitas {

    public sealed partial class VisualDebuggingEntity : Entity {

        public MyFloatComponent myFloat { get { return (MyFloatComponent)GetComponent(VisualDebuggingComponentIds.MyFloat); } }
        public bool hasMyFloat { get { return HasComponent(VisualDebuggingComponentIds.MyFloat); } }

        public void AddMyFloat(float newMyFloat) {
            var component = CreateComponent<MyFloatComponent>(VisualDebuggingComponentIds.MyFloat);
            component.myFloat = newMyFloat;
            AddComponent(VisualDebuggingComponentIds.MyFloat, component);
        }

        public void ReplaceMyFloat(float newMyFloat) {
            var component = CreateComponent<MyFloatComponent>(VisualDebuggingComponentIds.MyFloat);
            component.myFloat = newMyFloat;
            ReplaceComponent(VisualDebuggingComponentIds.MyFloat, component);
        }

        public void RemoveMyFloat() {
            RemoveComponent(VisualDebuggingComponentIds.MyFloat);
        }
    }
}

    public partial class VisualDebuggingMatcher {

        static IMatcher<VisualDebuggingEntity> _matcherMyFloat;

        public static IMatcher<VisualDebuggingEntity> MyFloat {
            get {
                if(_matcherMyFloat == null) {
                    var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(VisualDebuggingComponentIds.MyFloat);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherMyFloat = matcher;
                }

                return _matcherMyFloat;
            }
        }
    }
