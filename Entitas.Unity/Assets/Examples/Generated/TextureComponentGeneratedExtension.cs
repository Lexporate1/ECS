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

        public TextureComponent texture { get { return (TextureComponent)GetComponent(VisualDebuggingComponentIds.Texture); } }
        public bool hasTexture { get { return HasComponent(VisualDebuggingComponentIds.Texture); } }

        public Entity AddTexture(UnityEngine.Texture newTexture) {
            var component = CreateComponent<TextureComponent>(VisualDebuggingComponentIds.Texture);
            component.texture = newTexture;
            return AddComponent(VisualDebuggingComponentIds.Texture, component);
        }

        public Entity ReplaceTexture(UnityEngine.Texture newTexture) {
            var component = CreateComponent<TextureComponent>(VisualDebuggingComponentIds.Texture);
            component.texture = newTexture;
            ReplaceComponent(VisualDebuggingComponentIds.Texture, component);
            return this;
        }

        public Entity RemoveTexture() {
            return RemoveComponent(VisualDebuggingComponentIds.Texture);
        }
    }
}

    public partial class VisualDebuggingMatcher {

        static IMatcher _matcherTexture;

        public static IMatcher Texture {
            get {
                if(_matcherTexture == null) {
                    var matcher = (Matcher)Matcher.AllOf(VisualDebuggingComponentIds.Texture);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherTexture = matcher;
                }

                return _matcherTexture;
            }
        }
    }
