//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TestEntity {

    public ComponentWithProperties componentWithProperties { get { return (ComponentWithProperties)GetComponent(TestComponentsLookup.ComponentWithProperties); } }
    public bool hasComponentWithProperties { get { return HasComponent(TestComponentsLookup.ComponentWithProperties); } }

    public void AddComponentWithProperties(string newPublicProperty) {
        var index = TestComponentsLookup.ComponentWithProperties;
        var component = CreateComponent<ComponentWithProperties>(index);
        component.publicProperty = newPublicProperty;
        AddComponent(index, component);
    }

    public void ReplaceComponentWithProperties(string newPublicProperty) {
        var index = TestComponentsLookup.ComponentWithProperties;
        var component = CreateComponent<ComponentWithProperties>(index);
        component.publicProperty = newPublicProperty;
        ReplaceComponent(index, component);
    }

    public void RemoveComponentWithProperties() {
        RemoveComponent(TestComponentsLookup.ComponentWithProperties);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class TestMatcher {

    static Entitas.IMatcher<TestEntity> _matcherComponentWithProperties;

    public static Entitas.IMatcher<TestEntity> ComponentWithProperties {
        get {
            if(_matcherComponentWithProperties == null) {
                var matcher = (Entitas.Matcher<TestEntity>)Entitas.Matcher<TestEntity>.AllOf(TestComponentsLookup.ComponentWithProperties);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherComponentWithProperties = matcher;
            }

            return _matcherComponentWithProperties;
        }
    }
}
