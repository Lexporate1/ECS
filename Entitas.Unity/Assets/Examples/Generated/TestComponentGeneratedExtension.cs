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

    public partial class Entity {

        static readonly TestComponent testComponent = new TestComponent();

        public bool isTest {
            get { return HasComponent(VisualDebuggingComponentIds.Test); }
            set {
                if(value != isTest) {
                    if(value) {
                        AddComponent(VisualDebuggingComponentIds.Test, testComponent);
                    } else {
                        RemoveComponent(VisualDebuggingComponentIds.Test);
                    }
                }
            }
        }

        public Entity IsTest(bool value) {
            isTest = value;
            return this;
        }
    }
}

    public partial class VisualDebuggingMatcher {

        static IMatcher _matcherTest;

        public static IMatcher Test {
            get {
                if(_matcherTest == null) {
                    var matcher = (Matcher)Matcher.AllOf(VisualDebuggingComponentIds.Test);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherTest = matcher;
                }

                return _matcherTest;
            }
        }
    }
