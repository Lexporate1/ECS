﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class TestMatcher {

    static Entitas.IMatcher<TestEntity> _matcherDontGenerateMethods;

    public static Entitas.IMatcher<TestEntity> DontGenerateMethods {
        get {
            if(_matcherDontGenerateMethods == null) {
                var matcher = (Entitas.Matcher<TestEntity>)Entitas.Matcher<TestEntity>.AllOf(TestComponentsLookup.DontGenerateMethods);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherDontGenerateMethods = matcher;
            }

            return _matcherDontGenerateMethods;
        }
    }
}
