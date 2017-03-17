//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SimpleObjectComponent simpleObject { get { return (SimpleObjectComponent)GetComponent(GameComponentsLookup.SimpleObject); } }
    public bool hasSimpleObject { get { return HasComponent(GameComponentsLookup.SimpleObject); } }

    public void AddSimpleObject(SimpleObject newSimpleObject) {
        var index = GameComponentsLookup.SimpleObject;
        var component = CreateComponent<SimpleObjectComponent>(index);
        component.simpleObject = newSimpleObject;
        AddComponent(index, component);
    }

    public void ReplaceSimpleObject(SimpleObject newSimpleObject) {
        var index = GameComponentsLookup.SimpleObject;
        var component = CreateComponent<SimpleObjectComponent>(index);
        component.simpleObject = newSimpleObject;
        ReplaceComponent(index, component);
    }

    public void RemoveSimpleObject() {
        RemoveComponent(GameComponentsLookup.SimpleObject);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSimpleObject;

    public static Entitas.IMatcher<GameEntity> SimpleObject {
        get {
            if(_matcherSimpleObject == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SimpleObject);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSimpleObject = matcher;
            }

            return _matcherSimpleObject;
        }
    }
}
