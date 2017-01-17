//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public class SomeStructComponent : IComponent {

    public SomeStruct value;
}

namespace Entitas {

    public sealed partial class TestEntity : XXXEntity {

        public SomeStructComponent someStruct { get { return (SomeStructComponent)GetComponent(ComponentIds.SomeStruct); } }
        public bool hasSomeStruct { get { return HasComponent(ComponentIds.SomeStruct); } }

        public void AddSomeStruct(SomeStruct newValue) {
            var component = CreateComponent<SomeStructComponent>(ComponentIds.SomeStruct);
            component.value = newValue;
            AddComponent(ComponentIds.SomeStruct, component);
        }

        public void ReplaceSomeStruct(SomeStruct newValue) {
            var component = CreateComponent<SomeStructComponent>(ComponentIds.SomeStruct);
            component.value = newValue;
            ReplaceComponent(ComponentIds.SomeStruct, component);
        }

        public void RemoveSomeStruct() {
            RemoveComponent(ComponentIds.SomeStruct);
        }
    }

    public partial class Matcher {

        static IMatcher<TestEntity> _matcherSomeStruct;

        public static IMatcher<TestEntity> SomeStruct {
            get {
                if(_matcherSomeStruct == null) {
                    var matcher = (Matcher<TestEntity>)Matcher<TestEntity>.AllOf(ComponentIds.SomeStruct);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSomeStruct = matcher;
                }

                return _matcherSomeStruct;
            }
        }
    }
}
