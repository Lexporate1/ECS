//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public sealed partial class ContextAEntity : Entity {

    static readonly CComponent cComponent = new CComponent();

    public bool isC {
        get { return HasComponent(ContextAComponentIds.C); }
        set {
            if(value != isC) {
                if(value) {
                    AddComponent(ContextAComponentIds.C, cComponent);
                } else {
                    RemoveComponent(ContextAComponentIds.C);
                }
            }
        }
    }
}

public sealed partial class ContextAMatcher {

    static IMatcher<ContextAEntity> _matcherC;

    public static IMatcher<ContextAEntity> C {
        get {
            if(_matcherC == null) {
                var matcher = (Matcher<ContextAEntity>)Matcher<ContextAEntity>.AllOf(ContextAComponentIds.C);
                matcher.componentNames = ContextAComponentIds.componentNames;
                _matcherC = matcher;
            }

            return _matcherC;
        }
    }
}

public sealed partial class ContextBMatcher {

    static IMatcher<ContextAEntity> _matcherC;

    public static IMatcher<ContextAEntity> C {
        get {
            if(_matcherC == null) {
                var matcher = (Matcher<ContextAEntity>)Matcher<ContextAEntity>.AllOf(ContextBComponentIds.C);
                matcher.componentNames = ContextBComponentIds.componentNames;
                _matcherC = matcher;
            }

            return _matcherC;
        }
    }
}

public sealed partial class ContextCMatcher {

    static IMatcher<ContextAEntity> _matcherC;

    public static IMatcher<ContextAEntity> C {
        get {
            if(_matcherC == null) {
                var matcher = (Matcher<ContextAEntity>)Matcher<ContextAEntity>.AllOf(ContextCComponentIds.C);
                matcher.componentNames = ContextCComponentIds.componentNames;
                _matcherC = matcher;
            }

            return _matcherC;
        }
    }
}
