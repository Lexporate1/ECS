//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class VisualDebuggingEntity {

    public DictArrayComponent dictArray { get { return (DictArrayComponent)GetComponent(VisualDebuggingComponentsLookup.DictArray); } }
    public bool hasDictArray { get { return HasComponent(VisualDebuggingComponentsLookup.DictArray); } }

    public void AddDictArray(System.Collections.Generic.Dictionary<int, string[]> newDict, System.Collections.Generic.Dictionary<int, string[]>[] newDictArray) {
        var component = CreateComponent<DictArrayComponent>(VisualDebuggingComponentsLookup.DictArray);
        component.dict = newDict;
        component.dictArray = newDictArray;
        AddComponent(VisualDebuggingComponentsLookup.DictArray, component);
    }

    public void ReplaceDictArray(System.Collections.Generic.Dictionary<int, string[]> newDict, System.Collections.Generic.Dictionary<int, string[]>[] newDictArray) {
        var component = CreateComponent<DictArrayComponent>(VisualDebuggingComponentsLookup.DictArray);
        component.dict = newDict;
        component.dictArray = newDictArray;
        ReplaceComponent(VisualDebuggingComponentsLookup.DictArray, component);
    }

    public void RemoveDictArray() {
        RemoveComponent(VisualDebuggingComponentsLookup.DictArray);
    }
}
