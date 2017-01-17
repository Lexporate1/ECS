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

    public sealed partial class VisualDebuggingEntity : XXXEntity {

        public MyIntComponent myInt { get { return (MyIntComponent)GetComponent(VisualDebuggingComponentIds.MyInt); } }
        public bool hasMyInt { get { return HasComponent(VisualDebuggingComponentIds.MyInt); } }

        public void AddMyInt(int newMyInt) {
            var component = CreateComponent<MyIntComponent>(VisualDebuggingComponentIds.MyInt);
            component.myInt = newMyInt;
            AddComponent(VisualDebuggingComponentIds.MyInt, component);
        }

        public void ReplaceMyInt(int newMyInt) {
            var component = CreateComponent<MyIntComponent>(VisualDebuggingComponentIds.MyInt);
            component.myInt = newMyInt;
            ReplaceComponent(VisualDebuggingComponentIds.MyInt, component);
        }

        public void RemoveMyInt() {
            RemoveComponent(VisualDebuggingComponentIds.MyInt);
        }
    }
}

    public partial class VisualDebuggingMatcher {

        static IMatcher<VisualDebuggingEntity> _matcherMyInt;

        public static IMatcher<VisualDebuggingEntity> MyInt {
            get {
                if(_matcherMyInt == null) {
                    var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(VisualDebuggingComponentIds.MyInt);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherMyInt = matcher;
                }

                return _matcherMyInt;
            }
        }
    }
