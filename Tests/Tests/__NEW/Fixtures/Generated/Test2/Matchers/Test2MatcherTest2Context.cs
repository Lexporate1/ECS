//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;
using Entitas.Api;

public sealed partial class Test2Matcher {

    static IMatcher<Test2Entity> _matcherTest2Context;

    public static IMatcher<Test2Entity> Test2Context {
        get {
            if(_matcherTest2Context == null) {
                var matcher = (Matcher<Test2Entity>)Matcher<Test2Entity>.AllOf(Test2ComponentsLookup.Test2Context);
                matcher.componentNames = Test2ComponentsLookup.componentNames;
                _matcherTest2Context = matcher;
            }

            return _matcherTest2Context;
        }
    }
}
