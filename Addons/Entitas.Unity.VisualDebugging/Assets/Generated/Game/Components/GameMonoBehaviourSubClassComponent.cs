//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MonoBehaviourSubClassComponent monoBehaviourSubClass { get { return (MonoBehaviourSubClassComponent)GetComponent(GameComponentsLookup.MonoBehaviourSubClass); } }
    public bool hasMonoBehaviourSubClass { get { return HasComponent(GameComponentsLookup.MonoBehaviourSubClass); } }

    public void AddMonoBehaviourSubClass(MonoBehaviourSubClass newMonoBehaviour) {
        var component = CreateComponent<MonoBehaviourSubClassComponent>(GameComponentsLookup.MonoBehaviourSubClass);
        component.monoBehaviour = newMonoBehaviour;
        AddComponent(GameComponentsLookup.MonoBehaviourSubClass, component);
    }

    public void ReplaceMonoBehaviourSubClass(MonoBehaviourSubClass newMonoBehaviour) {
        var component = CreateComponent<MonoBehaviourSubClassComponent>(GameComponentsLookup.MonoBehaviourSubClass);
        component.monoBehaviour = newMonoBehaviour;
        ReplaceComponent(GameComponentsLookup.MonoBehaviourSubClass, component);
    }

    public void RemoveMonoBehaviourSubClass() {
        RemoveComponent(GameComponentsLookup.MonoBehaviourSubClass);
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

    static Entitas.IMatcher<GameEntity> _matcherMonoBehaviourSubClass;

    public static Entitas.IMatcher<GameEntity> MonoBehaviourSubClass {
        get {
            if(_matcherMonoBehaviourSubClass == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MonoBehaviourSubClass);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMonoBehaviourSubClass = matcher;
            }

            return _matcherMonoBehaviourSubClass;
        }
    }
}
