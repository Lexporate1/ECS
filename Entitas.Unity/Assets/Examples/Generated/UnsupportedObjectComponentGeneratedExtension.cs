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

        public UnsupportedObjectComponent unsupportedObject { get { return (UnsupportedObjectComponent)GetComponent(VisualDebuggingComponentIds.UnsupportedObject); } }
        public bool hasUnsupportedObject { get { return HasComponent(VisualDebuggingComponentIds.UnsupportedObject); } }

        public void AddUnsupportedObject(UnsupportedObject newUnsupportedObject) {
            var component = CreateComponent<UnsupportedObjectComponent>(VisualDebuggingComponentIds.UnsupportedObject);
            component.unsupportedObject = newUnsupportedObject;
            AddComponent(VisualDebuggingComponentIds.UnsupportedObject, component);
        }

        public void ReplaceUnsupportedObject(UnsupportedObject newUnsupportedObject) {
            var component = CreateComponent<UnsupportedObjectComponent>(VisualDebuggingComponentIds.UnsupportedObject);
            component.unsupportedObject = newUnsupportedObject;
            ReplaceComponent(VisualDebuggingComponentIds.UnsupportedObject, component);
        }

        public void RemoveUnsupportedObject() {
            RemoveComponent(VisualDebuggingComponentIds.UnsupportedObject);
        }
    }
}

    public partial class VisualDebuggingMatcher {

        static IMatcher<VisualDebuggingEntity> _matcherUnsupportedObject;

        public static IMatcher<VisualDebuggingEntity> UnsupportedObject {
            get {
                if(_matcherUnsupportedObject == null) {
                    var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(VisualDebuggingComponentIds.UnsupportedObject);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherUnsupportedObject = matcher;
                }

                return _matcherUnsupportedObject;
            }
        }
    }
