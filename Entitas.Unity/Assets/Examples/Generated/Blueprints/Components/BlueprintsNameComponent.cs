//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BlueprintsEntity {

    public NameComponent name { get { return (NameComponent)GetComponent(BlueprintsComponentsLookup.Name); } }
    public bool hasName { get { return HasComponent(BlueprintsComponentsLookup.Name); } }

    public void AddName(string newValue) {
        var component = CreateComponent<NameComponent>(BlueprintsComponentsLookup.Name);
        component.value = newValue;
        AddComponent(BlueprintsComponentsLookup.Name, component);
    }

    public void ReplaceName(string newValue) {
        var component = CreateComponent<NameComponent>(BlueprintsComponentsLookup.Name);
        component.value = newValue;
        ReplaceComponent(BlueprintsComponentsLookup.Name, component);
    }

    public void RemoveName() {
        RemoveComponent(BlueprintsComponentsLookup.Name);
    }
}
