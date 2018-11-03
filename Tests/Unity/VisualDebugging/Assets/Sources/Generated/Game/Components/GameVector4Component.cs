//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Vector4Component vector4 { get { return (Vector4Component)GetComponent(GameComponentsLookup.Vector4); } }
    public bool hasVector4 { get { return HasComponent(GameComponentsLookup.Vector4); } }

    public void AddVector4(UnityEngine.Vector4 newVector4) {
        var index = GameComponentsLookup.Vector4;
        var component = (Vector4Component)CreateComponent(index, typeof(Vector4Component));
        component.vector4 = newVector4;
        AddComponent(index, component);
    }

    public void ReplaceVector4(UnityEngine.Vector4 newVector4) {
        var index = GameComponentsLookup.Vector4;
        var component = (Vector4Component)CreateComponent(index, typeof(Vector4Component));
        component.vector4 = newVector4;
        ReplaceComponent(index, component);
    }

    public void RemoveVector4() {
        RemoveComponent(GameComponentsLookup.Vector4);
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

    static Entitas.IMatcher<GameEntity> _matcherVector4;

    public static Entitas.IMatcher<GameEntity> Vector4 {
        get {
            if (_matcherVector4 == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Vector4);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVector4 = matcher;
            }

            return _matcherVector4;
        }
    }
}
