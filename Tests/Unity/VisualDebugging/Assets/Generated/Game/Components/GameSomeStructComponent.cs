//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SomeStructComponent someStruct { get { return (SomeStructComponent)GetComponent(GameComponentsLookup.SomeStruct); } }
    public bool hasSomeStruct { get { return HasComponent(GameComponentsLookup.SomeStruct); } }

    public void AddSomeStruct(SomeStruct newValue) {
        var index = GameComponentsLookup.SomeStruct;
        var component = CreateComponent<SomeStructComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSomeStruct(SomeStruct newValue) {
        var index = GameComponentsLookup.SomeStruct;
        var component = CreateComponent<SomeStructComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSomeStruct() {
        RemoveComponent(GameComponentsLookup.SomeStruct);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSomeStruct;

    public static Entitas.IMatcher<GameEntity> SomeStruct {
        get {
            if (_matcherSomeStruct == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SomeStruct);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSomeStruct = matcher;
            }

            return _matcherSomeStruct;
        }
    }
}
