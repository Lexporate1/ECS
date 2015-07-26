using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Array3DComponent array3D { get { return (Array3DComponent)GetComponent(ComponentIds.Array3D); } }

        public bool hasArray3D { get { return HasComponent(ComponentIds.Array3D); } }

        static readonly Stack<Array3DComponent> _array3DComponentPool = new Stack<Array3DComponent>();

        public static void ClearArray3DComponentPool() {
            _array3DComponentPool.Clear();
        }

        public Entity AddArray3D(int[,,] newArray3d) {
            var component = _array3DComponentPool.Count > 0 ? _array3DComponentPool.Pop() : new Array3DComponent();
            component.array3d = newArray3d;
            return AddComponent(ComponentIds.Array3D, component);
        }

        public Entity ReplaceArray3D(int[,,] newArray3d) {
            var previousComponent = array3D;
            var component = _array3DComponentPool.Count > 0 ? _array3DComponentPool.Pop() : new Array3DComponent();
            component.array3d = newArray3d;
            ReplaceComponent(ComponentIds.Array3D, component);
            if (previousComponent != null) {
                _array3DComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveArray3D() {
            var component = array3D;
            RemoveComponent(ComponentIds.Array3D);
            _array3DComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherArray3D;

        public static AllOfMatcher Array3D {
            get {
                if (_matcherArray3D == null) {
                    _matcherArray3D = new Matcher(ComponentIds.Array3D);
                }

                return _matcherArray3D;
            }
        }
    }
}
