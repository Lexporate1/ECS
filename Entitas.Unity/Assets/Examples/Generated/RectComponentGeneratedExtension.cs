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
        public RectComponent rect { get { return (RectComponent)GetComponent(VisualDebuggingComponentIds.Rect); } }

        public bool hasRect { get { return HasComponent(VisualDebuggingComponentIds.Rect); } }

        public Entity AddRect(UnityEngine.Rect newRect) {
            var component = CreateComponent<RectComponent>(VisualDebuggingComponentIds.Rect);
            component.rect = newRect;
            return AddComponent(VisualDebuggingComponentIds.Rect, component);
        }

        public Entity ReplaceRect(UnityEngine.Rect newRect) {
            var component = CreateComponent<RectComponent>(VisualDebuggingComponentIds.Rect);
            component.rect = newRect;
            ReplaceComponent(VisualDebuggingComponentIds.Rect, component);
            return this;
        }

        public Entity RemoveRect() {
            return RemoveComponent(VisualDebuggingComponentIds.Rect);
        }
    }
}

    public partial class VisualDebuggingMatcher {
        static IMatcher _matcherRect;

        public static IMatcher Rect {
            get {
                if (_matcherRect == null) {
                    var matcher = (Matcher)Matcher.AllOf(VisualDebuggingComponentIds.Rect);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherRect = matcher;
                }

                return _matcherRect;
            }
        }
    }
