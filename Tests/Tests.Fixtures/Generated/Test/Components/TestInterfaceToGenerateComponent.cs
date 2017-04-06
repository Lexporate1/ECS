//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TestEntity {

    public InterfaceToGenerateComponent interfaceToGenerate { get { return (InterfaceToGenerateComponent)GetComponent(TestComponentsLookup.InterfaceToGenerate); } }
    public bool hasInterfaceToGenerate { get { return HasComponent(TestComponentsLookup.InterfaceToGenerate); } }

    public void AddInterfaceToGenerate(My.Namespace.InterfaceToGenerate newValue) {
        var index = TestComponentsLookup.InterfaceToGenerate;
        var component = CreateComponent<InterfaceToGenerateComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInterfaceToGenerate(My.Namespace.InterfaceToGenerate newValue) {
        var index = TestComponentsLookup.InterfaceToGenerate;
        var component = CreateComponent<InterfaceToGenerateComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInterfaceToGenerate() {
        RemoveComponent(TestComponentsLookup.InterfaceToGenerate);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class TestMatcher {

    static Entitas.Core.IMatcher<TestEntity> _matcherInterfaceToGenerate;

    public static Entitas.Core.IMatcher<TestEntity> InterfaceToGenerate {
        get {
            if(_matcherInterfaceToGenerate == null) {
                var matcher = (Entitas.Matcher<TestEntity>)Entitas.Matcher<TestEntity>.AllOf(TestComponentsLookup.InterfaceToGenerate);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherInterfaceToGenerate = matcher;
            }

            return _matcherInterfaceToGenerate;
        }
    }
}
