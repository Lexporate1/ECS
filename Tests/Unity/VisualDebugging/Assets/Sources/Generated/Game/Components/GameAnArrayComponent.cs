//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnArrayComponent anArray { get { return (AnArrayComponent)GetComponent(GameComponentsLookup.AnArray); } }
    public bool hasAnArray { get { return HasComponent(GameComponentsLookup.AnArray); } }

    public void AddAnArray(string[] newArray) {
        var index = GameComponentsLookup.AnArray;
        var component = CreateComponent<AnArrayComponent>(index);
        component.array = newArray;
        AddComponent(index, component);
    }

    public void ReplaceAnArray(string[] newArray) {
        var index = GameComponentsLookup.AnArray;
        var component = CreateComponent<AnArrayComponent>(index);
        component.array = newArray;
        ReplaceComponent(index, component);
    }

    public void RemoveAnArray() {
        RemoveComponent(GameComponentsLookup.AnArray);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnArray;

    public static Entitas.IMatcher<GameEntity> AnArray {
        get {
            if (_matcherAnArray == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnArray);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnArray = matcher;
            }

            return _matcherAnArray;
        }
    }
}
