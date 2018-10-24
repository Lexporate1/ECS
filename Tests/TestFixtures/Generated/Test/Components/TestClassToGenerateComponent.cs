//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TestEntity {

    public ClassToGenerateComponent classToGenerate { get { return (ClassToGenerateComponent)GetComponent(TestComponentsLookup.ClassToGenerate); } }
    public bool hasClassToGenerate { get { return HasComponent(TestComponentsLookup.ClassToGenerate); } }

    public void AddClassToGenerate(My.Namespace.ClassToGenerate newValue) {
        var index = TestComponentsLookup.ClassToGenerate;
        var component = (ClassToGenerateComponent)CreateComponent(index, typeof(ClassToGenerateComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceClassToGenerate(My.Namespace.ClassToGenerate newValue) {
        var index = TestComponentsLookup.ClassToGenerate;
        var component = (ClassToGenerateComponent)CreateComponent(index, typeof(ClassToGenerateComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveClassToGenerate() {
        RemoveComponent(TestComponentsLookup.ClassToGenerate);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TestEntity : IClassToGenerateEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class TestMatcher {

    static Entitas.IMatcher<TestEntity> _matcherClassToGenerate;

    public static Entitas.IMatcher<TestEntity> ClassToGenerate {
        get {
            if (_matcherClassToGenerate == null) {
                var matcher = (Entitas.Matcher<TestEntity>)Entitas.Matcher<TestEntity>.AllOf(TestComponentsLookup.ClassToGenerate);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherClassToGenerate = matcher;
            }

            return _matcherClassToGenerate;
        }
    }
}
