//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TestEntity {

    public TestMultipleContextStandardEventListenerComponent testMultipleContextStandardEventListener { get { return (TestMultipleContextStandardEventListenerComponent)GetComponent(TestComponentsLookup.TestMultipleContextStandardEventListener); } }
    public bool hasTestMultipleContextStandardEventListener { get { return HasComponent(TestComponentsLookup.TestMultipleContextStandardEventListener); } }

    public void AddTestMultipleContextStandardEventListener(System.Collections.Generic.List<ITestMultipleContextStandardEventListener> newValue) {
        var index = TestComponentsLookup.TestMultipleContextStandardEventListener;
        var component = CreateComponent<TestMultipleContextStandardEventListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTestMultipleContextStandardEventListener(System.Collections.Generic.List<ITestMultipleContextStandardEventListener> newValue) {
        var index = TestComponentsLookup.TestMultipleContextStandardEventListener;
        var component = CreateComponent<TestMultipleContextStandardEventListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTestMultipleContextStandardEventListener() {
        RemoveComponent(TestComponentsLookup.TestMultipleContextStandardEventListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class TestMatcher {

    static Entitas.IMatcher<TestEntity> _matcherTestMultipleContextStandardEventListener;

    public static Entitas.IMatcher<TestEntity> TestMultipleContextStandardEventListener {
        get {
            if (_matcherTestMultipleContextStandardEventListener == null) {
                var matcher = (Entitas.Matcher<TestEntity>)Entitas.Matcher<TestEntity>.AllOf(TestComponentsLookup.TestMultipleContextStandardEventListener);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherTestMultipleContextStandardEventListener = matcher;
            }

            return _matcherTestMultipleContextStandardEventListener;
        }
    }
}
