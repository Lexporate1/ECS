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

        public JaggedArrayComponent jaggedArray { get { return (JaggedArrayComponent)GetComponent(VisualDebuggingComponentIds.JaggedArray); } }
        public bool hasJaggedArray { get { return HasComponent(VisualDebuggingComponentIds.JaggedArray); } }

        public void AddJaggedArray(string[][] newJaggedArray) {
            var component = CreateComponent<JaggedArrayComponent>(VisualDebuggingComponentIds.JaggedArray);
            component.jaggedArray = newJaggedArray;
            AddComponent(VisualDebuggingComponentIds.JaggedArray, component);
        }

        public void ReplaceJaggedArray(string[][] newJaggedArray) {
            var component = CreateComponent<JaggedArrayComponent>(VisualDebuggingComponentIds.JaggedArray);
            component.jaggedArray = newJaggedArray;
            ReplaceComponent(VisualDebuggingComponentIds.JaggedArray, component);
        }

        public void RemoveJaggedArray() {
            RemoveComponent(VisualDebuggingComponentIds.JaggedArray);
        }
    }
}

    public partial class VisualDebuggingMatcher {

        static IMatcher<VisualDebuggingEntity> _matcherJaggedArray;

        public static IMatcher<VisualDebuggingEntity> JaggedArray {
            get {
                if(_matcherJaggedArray == null) {
                    var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(VisualDebuggingComponentIds.JaggedArray);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherJaggedArray = matcher;
                }

                return _matcherJaggedArray;
            }
        }
    }
