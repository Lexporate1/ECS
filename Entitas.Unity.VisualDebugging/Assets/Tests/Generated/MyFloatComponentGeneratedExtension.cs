using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public MyFloatComponent myFloat { get { return (MyFloatComponent)GetComponent(ComponentIds.MyFloat); } }

        public bool hasMyFloat { get { return HasComponent(ComponentIds.MyFloat); } }

        static readonly Stack<MyFloatComponent> _myFloatComponentPool = new Stack<MyFloatComponent>();

        public static void ClearMyFloatComponentPool() {
            _myFloatComponentPool.Clear();
        }

        public Entity AddMyFloat(float newMyFloat) {
            var component = _myFloatComponentPool.Count > 0 ? _myFloatComponentPool.Pop() : new MyFloatComponent();
            component.myFloat = newMyFloat;
            return AddComponent(ComponentIds.MyFloat, component);
        }

        public Entity ReplaceMyFloat(float newMyFloat) {
            var previousComponent = myFloat;
            var component = _myFloatComponentPool.Count > 0 ? _myFloatComponentPool.Pop() : new MyFloatComponent();
            component.myFloat = newMyFloat;
            ReplaceComponent(ComponentIds.MyFloat, component);
            if (previousComponent != null) {
                _myFloatComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveMyFloat() {
            var component = myFloat;
            RemoveComponent(ComponentIds.MyFloat);
            _myFloatComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherMyFloat;

        public static AllOfMatcher MyFloat {
            get {
                if (_matcherMyFloat == null) {
                    _matcherMyFloat = new Matcher(ComponentIds.MyFloat);
                }

                return _matcherMyFloat;
            }
        }
    }
}
