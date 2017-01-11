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

        public DictArrayComponent dictArray { get { return (DictArrayComponent)GetComponent(VisualDebuggingComponentIds.DictArray); } }
        public bool hasDictArray { get { return HasComponent(VisualDebuggingComponentIds.DictArray); } }

        public void AddDictArray(System.Collections.Generic.Dictionary<int, string[]> newDict, System.Collections.Generic.Dictionary<int, string[]>[] newDictArray) {
            var component = CreateComponent<DictArrayComponent>(VisualDebuggingComponentIds.DictArray);
            component.dict = newDict;
            component.dictArray = newDictArray;
            AddComponent(VisualDebuggingComponentIds.DictArray, component);
        }

        public void ReplaceDictArray(System.Collections.Generic.Dictionary<int, string[]> newDict, System.Collections.Generic.Dictionary<int, string[]>[] newDictArray) {
            var component = CreateComponent<DictArrayComponent>(VisualDebuggingComponentIds.DictArray);
            component.dict = newDict;
            component.dictArray = newDictArray;
            ReplaceComponent(VisualDebuggingComponentIds.DictArray, component);
        }

        public void RemoveDictArray() {
            RemoveComponent(VisualDebuggingComponentIds.DictArray);
        }
    }
}

    public partial class VisualDebuggingMatcher {

        static IMatcher _matcherDictArray;

        public static IMatcher DictArray {
            get {
                if(_matcherDictArray == null) {
                    var matcher = (Matcher)Matcher.AllOf(VisualDebuggingComponentIds.DictArray);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherDictArray = matcher;
                }

                return _matcherDictArray;
            }
        }
    }
