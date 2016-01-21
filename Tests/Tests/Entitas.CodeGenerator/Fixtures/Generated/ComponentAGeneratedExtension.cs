namespace Entitas {
    public partial class Entity {
        static readonly ComponentA componentAComponent = new ComponentA();

        public bool isComponentA {
            get { return HasComponent(ComponentIds.ComponentA); }
            set {
                if (value != isComponentA) {
                    if (value) {
                        AddComponent(ComponentIds.ComponentA, componentAComponent);
                    } else {
                        RemoveComponent(ComponentIds.ComponentA);
                    }
                }
            }
        }

        public Entity IsComponentA(bool value) {
            isComponentA = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherComponentA;

        public static IMatcher ComponentA {
            get {
                if (_matcherComponentA == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.ComponentA);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherComponentA = matcher;
                }

                return _matcherComponentA;
            }
        }
    }
}
