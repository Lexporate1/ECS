//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public sealed partial class TestMatcher {

    static IMatcher<TestEntity> _matcherMyNamespaceUniqueMyNamespaceFlag;

    public static IMatcher<TestEntity> MyNamespaceUniqueMyNamespaceFlag {
        get {
            if(_matcherMyNamespaceUniqueMyNamespaceFlag == null) {
                var matcher = (Matcher<TestEntity>)Matcher<TestEntity>.AllOf(TestComponentsLookup.MyNamespaceUniqueMyNamespaceFlag);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherMyNamespaceUniqueMyNamespaceFlag = matcher;
            }

            return _matcherMyNamespaceUniqueMyNamespaceFlag;
        }
    }
}
