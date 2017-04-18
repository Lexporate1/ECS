//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Test2Entity {

    public Test2ContextComponent test2Context { get { return (Test2ContextComponent)GetComponent(Test2ComponentsLookup.Test2Context); } }
    public bool hasTest2Context { get { return HasComponent(Test2ComponentsLookup.Test2Context); } }

    public void AddTest2Context(string newValue) {
        var index = Test2ComponentsLookup.Test2Context;
        var component = CreateComponent<Test2ContextComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTest2Context(string newValue) {
        var index = Test2ComponentsLookup.Test2Context;
        var component = CreateComponent<Test2ContextComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTest2Context() {
        RemoveComponent(Test2ComponentsLookup.Test2Context);
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
public sealed partial class Test2Matcher {

    static Entitas.IMatcher<Test2Entity> _matcherTest2Context;

    public static Entitas.IMatcher<Test2Entity> Test2Context {
        get {
            if(_matcherTest2Context == null) {
                var matcher = (Entitas.Matcher<Test2Entity>)Entitas.Matcher<Test2Entity>.AllOf(Test2ComponentsLookup.Test2Context);
                matcher.componentNames = Test2ComponentsLookup.componentNames;
                _matcherTest2Context = matcher;
            }

            return _matcherTest2Context;
        }
    }
}
