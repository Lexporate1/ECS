//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {

    public partial class Entity {

        public ComponentWithFieldsAndProperties componentWithFieldsAndProperties { get { return (ComponentWithFieldsAndProperties)GetComponent(ComponentIds.ComponentWithFieldsAndProperties); } }
        public bool hasComponentWithFieldsAndProperties { get { return HasComponent(ComponentIds.ComponentWithFieldsAndProperties); } }

        public void AddComponentWithFieldsAndProperties(string newPublicField, string newPublicProperty) {
            var component = CreateComponent<ComponentWithFieldsAndProperties>(ComponentIds.ComponentWithFieldsAndProperties);
            component.publicField = newPublicField;
            component.publicProperty = newPublicProperty;
            AddComponent(ComponentIds.ComponentWithFieldsAndProperties, component);
        }

        public void ReplaceComponentWithFieldsAndProperties(string newPublicField, string newPublicProperty) {
            var component = CreateComponent<ComponentWithFieldsAndProperties>(ComponentIds.ComponentWithFieldsAndProperties);
            component.publicField = newPublicField;
            component.publicProperty = newPublicProperty;
            ReplaceComponent(ComponentIds.ComponentWithFieldsAndProperties, component);
        }

        public void RemoveComponentWithFieldsAndProperties() {
            RemoveComponent(ComponentIds.ComponentWithFieldsAndProperties);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherComponentWithFieldsAndProperties;

        public static IMatcher ComponentWithFieldsAndProperties {
            get {
                if(_matcherComponentWithFieldsAndProperties == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.ComponentWithFieldsAndProperties);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherComponentWithFieldsAndProperties = matcher;
                }

                return _matcherComponentWithFieldsAndProperties;
            }
        }
    }
}
