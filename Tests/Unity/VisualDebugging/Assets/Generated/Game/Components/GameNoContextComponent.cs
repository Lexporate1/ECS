//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly NoContextComponent noContextComponent = new NoContextComponent();

    public bool isNoContext {
        get { return HasComponent(GameComponentsLookup.NoContext); }
        set {
            if(value != isNoContext) {
                if(value) {
                    AddComponent(GameComponentsLookup.NoContext, noContextComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.NoContext);
                }
            }
        }
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

    static Entitas.Core.IMatcher<GameEntity> _matcherNoContext;

    public static Entitas.Core.IMatcher<GameEntity> NoContext {
        get {
            if(_matcherNoContext == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NoContext);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNoContext = matcher;
            }

            return _matcherNoContext;
        }
    }
}
