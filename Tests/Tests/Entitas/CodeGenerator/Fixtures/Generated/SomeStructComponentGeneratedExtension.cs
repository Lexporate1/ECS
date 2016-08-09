﻿using Entitas;

public class SomeStructComponent : IComponent {
    public SomeStruct value;
}

namespace Entitas {
    public partial class Entity {
        public SomeStructComponent someStruct { get { return (SomeStructComponent)GetComponent(ComponentIds.SomeStruct); } }

        public bool hasSomeStruct { get { return HasComponent(ComponentIds.SomeStruct); } }

        public Entity AddSomeStruct(SomeStruct newValue) {
            var component = CreateComponent<SomeStructComponent>(ComponentIds.SomeStruct);
            component.value = newValue;
            return AddComponent(ComponentIds.SomeStruct, component);
        }

        public Entity ReplaceSomeStruct(SomeStruct newValue) {
            var component = CreateComponent<SomeStructComponent>(ComponentIds.SomeStruct);
            component.value = newValue;
            ReplaceComponent(ComponentIds.SomeStruct, component);
            return this;
        }

        public Entity RemoveSomeStruct() {
            return RemoveComponent(ComponentIds.SomeStruct);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherSomeStruct;

        public static IMatcher SomeStruct {
            get {
                if (_matcherSomeStruct == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.SomeStruct);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSomeStruct = matcher;
                }

                return _matcherSomeStruct;
            }
        }
    }
}
