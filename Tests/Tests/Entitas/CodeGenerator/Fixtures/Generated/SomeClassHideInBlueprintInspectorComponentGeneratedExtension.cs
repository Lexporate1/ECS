//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

[Entitas.Serialization.Blueprints.HideInBlueprintInspectorAttribute]
public class SomeClassHideInBlueprintInspectorComponent : IComponent {

    public SomeClassHideInBlueprintInspector value;
}

public sealed partial class TestEntity : Entity {

    public SomeClassHideInBlueprintInspectorComponent someClassHideInBlueprintInspector { get { return (SomeClassHideInBlueprintInspectorComponent)GetComponent(TestComponentIds.SomeClassHideInBlueprintInspector); } }
    public bool hasSomeClassHideInBlueprintInspector { get { return HasComponent(TestComponentIds.SomeClassHideInBlueprintInspector); } }

    public void AddSomeClassHideInBlueprintInspector(SomeClassHideInBlueprintInspector newValue) {
        var component = CreateComponent<SomeClassHideInBlueprintInspectorComponent>(TestComponentIds.SomeClassHideInBlueprintInspector);
        component.value = newValue;
        AddComponent(TestComponentIds.SomeClassHideInBlueprintInspector, component);
    }

    public void ReplaceSomeClassHideInBlueprintInspector(SomeClassHideInBlueprintInspector newValue) {
        var component = CreateComponent<SomeClassHideInBlueprintInspectorComponent>(TestComponentIds.SomeClassHideInBlueprintInspector);
        component.value = newValue;
        ReplaceComponent(TestComponentIds.SomeClassHideInBlueprintInspector, component);
    }

    public void RemoveSomeClassHideInBlueprintInspector() {
        RemoveComponent(TestComponentIds.SomeClassHideInBlueprintInspector);
    }
}

public partial class Matcher {

    static IMatcher<TestEntity> _matcherSomeClassHideInBlueprintInspector;

    public static IMatcher<TestEntity> SomeClassHideInBlueprintInspector {
        get {
            if(_matcherSomeClassHideInBlueprintInspector == null) {
                var matcher = (Matcher<TestEntity>)Matcher<TestEntity>.AllOf(TestComponentIds.SomeClassHideInBlueprintInspector);
                matcher.componentNames = TestComponentIds.componentNames;
                _matcherSomeClassHideInBlueprintInspector = matcher;
            }

            return _matcherSomeClassHideInBlueprintInspector;
        }
    }
}
