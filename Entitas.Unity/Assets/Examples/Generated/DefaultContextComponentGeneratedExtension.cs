//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {

    public sealed partial class VisualDebuggingEntity : XXXEntity {

        static readonly DefaultContextComponent defaultContextComponent = new DefaultContextComponent();

        public bool isDefaultContext {
            get { return HasComponent(ComponentIds.DefaultContext); }
            set {
                if(value != isDefaultContext) {
                    if(value) {
                        AddComponent(ComponentIds.DefaultContext, defaultContextComponent);
                    } else {
                        RemoveComponent(ComponentIds.DefaultContext);
                    }
                }
            }
        }
    }

    public partial class Matcher {

        static IMatcher<VisualDebuggingEntity> _matcherDefaultContext;

        public static IMatcher<VisualDebuggingEntity> DefaultContext {
            get {
                if(_matcherDefaultContext == null) {
                    var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(ComponentIds.DefaultContext);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherDefaultContext = matcher;
                }

                return _matcherDefaultContext;
            }
        }
    }
}
