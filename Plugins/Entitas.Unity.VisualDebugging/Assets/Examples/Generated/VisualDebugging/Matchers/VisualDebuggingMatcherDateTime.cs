//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public sealed partial class VisualDebuggingMatcher {

    static IMatcher<VisualDebuggingEntity> _matcherDateTime;

    public static IMatcher<VisualDebuggingEntity> DateTime {
        get {
            if(_matcherDateTime == null) {
                var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(VisualDebuggingComponentsLookup.DateTime);
                matcher.componentNames = VisualDebuggingComponentsLookup.componentNames;
                _matcherDateTime = matcher;
            }

            return _matcherDateTime;
        }
    }
}
