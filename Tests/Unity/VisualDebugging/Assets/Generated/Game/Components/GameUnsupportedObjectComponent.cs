//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UnsupportedObjectComponent unsupportedObject { get { return (UnsupportedObjectComponent)GetComponent(GameComponentsLookup.UnsupportedObject); } }
    public bool hasUnsupportedObject { get { return HasComponent(GameComponentsLookup.UnsupportedObject); } }

    public void AddUnsupportedObject(UnsupportedObject newUnsupportedObject) {
        var index = GameComponentsLookup.UnsupportedObject;
        var component = CreateComponent<UnsupportedObjectComponent>(index);
        component.unsupportedObject = newUnsupportedObject;
        AddComponent(index, component);
    }

    public void ReplaceUnsupportedObject(UnsupportedObject newUnsupportedObject) {
        var index = GameComponentsLookup.UnsupportedObject;
        var component = CreateComponent<UnsupportedObjectComponent>(index);
        component.unsupportedObject = newUnsupportedObject;
        ReplaceComponent(index, component);
    }

    public void RemoveUnsupportedObject() {
        RemoveComponent(GameComponentsLookup.UnsupportedObject);
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
public sealed partial class GameMatcher {

    static Entitas.Core.IMatcher<GameEntity> _matcherUnsupportedObject;

    public static Entitas.Core.IMatcher<GameEntity> UnsupportedObject {
        get {
            if(_matcherUnsupportedObject == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UnsupportedObject);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUnsupportedObject = matcher;
            }

            return _matcherUnsupportedObject;
        }
    }
}
