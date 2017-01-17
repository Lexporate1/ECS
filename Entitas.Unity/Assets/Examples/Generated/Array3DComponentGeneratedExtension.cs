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

        public Array3DComponent array3D { get { return (Array3DComponent)GetComponent(VisualDebuggingComponentIds.Array3D); } }
        public bool hasArray3D { get { return HasComponent(VisualDebuggingComponentIds.Array3D); } }

        public void AddArray3D(string[,,] newArray3d) {
            var component = CreateComponent<Array3DComponent>(VisualDebuggingComponentIds.Array3D);
            component.array3d = newArray3d;
            AddComponent(VisualDebuggingComponentIds.Array3D, component);
        }

        public void ReplaceArray3D(string[,,] newArray3d) {
            var component = CreateComponent<Array3DComponent>(VisualDebuggingComponentIds.Array3D);
            component.array3d = newArray3d;
            ReplaceComponent(VisualDebuggingComponentIds.Array3D, component);
        }

        public void RemoveArray3D() {
            RemoveComponent(VisualDebuggingComponentIds.Array3D);
        }
    }
}

    public partial class VisualDebuggingMatcher {

        static IMatcher<VisualDebuggingEntity> _matcherArray3D;

        public static IMatcher<VisualDebuggingEntity> Array3D {
            get {
                if(_matcherArray3D == null) {
                    var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(VisualDebuggingComponentIds.Array3D);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherArray3D = matcher;
                }

                return _matcherArray3D;
            }
        }
    }
