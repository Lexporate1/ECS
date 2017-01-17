//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public class SomeOtherClassComponent : IComponent {

    public SomeNamespace.SomeOtherClass value;
}

namespace Entitas {

    public sealed partial class VisualDebuggingEntity : XXXEntity {

        public SomeOtherClassComponent someOtherClass { get { return (SomeOtherClassComponent)GetComponent(VisualDebuggingComponentIds.SomeOtherClass); } }
        public bool hasSomeOtherClass { get { return HasComponent(VisualDebuggingComponentIds.SomeOtherClass); } }

        public void AddSomeOtherClass(SomeNamespace.SomeOtherClass newValue) {
            var component = CreateComponent<SomeOtherClassComponent>(VisualDebuggingComponentIds.SomeOtherClass);
            component.value = newValue;
            AddComponent(VisualDebuggingComponentIds.SomeOtherClass, component);
        }

        public void ReplaceSomeOtherClass(SomeNamespace.SomeOtherClass newValue) {
            var component = CreateComponent<SomeOtherClassComponent>(VisualDebuggingComponentIds.SomeOtherClass);
            component.value = newValue;
            ReplaceComponent(VisualDebuggingComponentIds.SomeOtherClass, component);
        }

        public void RemoveSomeOtherClass() {
            RemoveComponent(VisualDebuggingComponentIds.SomeOtherClass);
        }
    }
}

    public partial class VisualDebuggingMatcher {

        static IMatcher<VisualDebuggingEntity> _matcherSomeOtherClass;

        public static IMatcher<VisualDebuggingEntity> SomeOtherClass {
            get {
                if(_matcherSomeOtherClass == null) {
                    var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(VisualDebuggingComponentIds.SomeOtherClass);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherSomeOtherClass = matcher;
                }

                return _matcherSomeOtherClass;
            }
        }
    }
