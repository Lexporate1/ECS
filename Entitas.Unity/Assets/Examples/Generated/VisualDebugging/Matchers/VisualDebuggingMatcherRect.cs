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

    static IMatcher<VisualDebuggingEntity> _matcherRect;

    public static IMatcher<VisualDebuggingEntity> Rect {
        get {
            if(_matcherRect == null) {
                var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(VisualDebuggingComponentsLookup.Rect);
                matcher.componentNames = VisualDebuggingComponentsLookup.componentNames;
                _matcherRect = matcher;
            }

            return _matcherRect;
        }
    }
}
