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

public sealed partial class VisualDebuggingMatcher {

    static IMatcher<VisualDebuggingEntity> _matcherMonoBehaviourSubClass;

    public static IMatcher<VisualDebuggingEntity> MonoBehaviourSubClass {
        get {
            if(_matcherMonoBehaviourSubClass == null) {
                var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(VisualDebuggingComponentsLookup.MonoBehaviourSubClass);
                matcher.componentNames = VisualDebuggingComponentsLookup.componentNames;
                _matcherMonoBehaviourSubClass = matcher;
            }

            return _matcherMonoBehaviourSubClass;
        }
    }
}
