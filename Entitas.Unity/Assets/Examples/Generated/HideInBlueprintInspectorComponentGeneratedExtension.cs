//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

namespace Entitas {

    public sealed partial class BlueprintsEntity : XXXEntity {

        static readonly HideInBlueprintInspectorComponent hideInBlueprintInspectorComponent = new HideInBlueprintInspectorComponent();

        public bool isHideInBlueprintInspector {
            get { return HasComponent(BlueprintsComponentIds.HideInBlueprintInspector); }
            set {
                if(value != isHideInBlueprintInspector) {
                    if(value) {
                        AddComponent(BlueprintsComponentIds.HideInBlueprintInspector, hideInBlueprintInspectorComponent);
                    } else {
                        RemoveComponent(BlueprintsComponentIds.HideInBlueprintInspector);
                    }
                }
            }
        }
    }
}

    public partial class BlueprintsMatcher {

        static IMatcher<BlueprintsEntity> _matcherHideInBlueprintInspector;

        public static IMatcher<BlueprintsEntity> HideInBlueprintInspector {
            get {
                if(_matcherHideInBlueprintInspector == null) {
                    var matcher = (Matcher<BlueprintsEntity>)Matcher<BlueprintsEntity>.AllOf(BlueprintsComponentIds.HideInBlueprintInspector);
                    matcher.componentNames = BlueprintsComponentIds.componentNames;
                    _matcherHideInBlueprintInspector = matcher;
                }

                return _matcherHideInBlueprintInspector;
            }
        }
    }
