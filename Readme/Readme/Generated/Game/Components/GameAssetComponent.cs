﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AssetComponent asset { get { return (AssetComponent)GetComponent(GameComponentsLookup.Asset); } }
    public bool hasAsset { get { return HasComponent(GameComponentsLookup.Asset); } }

    public void AddAsset(string newName) {
        var index = GameComponentsLookup.Asset;
        var component = CreateComponent<AssetComponent>(index);
        component.name = newName;
        AddComponent(index, component);
    }

    public void ReplaceAsset(string newName) {
        var index = GameComponentsLookup.Asset;
        var component = CreateComponent<AssetComponent>(index);
        component.name = newName;
        ReplaceComponent(index, component);
    }

    public void RemoveAsset() {
        RemoveComponent(GameComponentsLookup.Asset);
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

    static Entitas.IMatcher<GameEntity> _matcherAsset;

    public static Entitas.IMatcher<GameEntity> Asset {
        get {
            if(_matcherAsset == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Asset);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAsset = matcher;
            }

            return _matcherAsset;
        }
    }
}
