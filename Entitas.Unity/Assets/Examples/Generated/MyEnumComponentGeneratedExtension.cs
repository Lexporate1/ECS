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
        public MyEnumComponent myEnum { get { return (MyEnumComponent)GetComponent(ComponentIds.MyEnum); } }

        public bool hasMyEnum { get { return HasComponent(ComponentIds.MyEnum); } }

        public Entity AddMyEnum(MyEnumComponent.MyEnum newMyEnum) {
            var component = CreateComponent<MyEnumComponent>(ComponentIds.MyEnum);
            component.myEnum = newMyEnum;
            return AddComponent(ComponentIds.MyEnum, component);
        }

        public Entity ReplaceMyEnum(MyEnumComponent.MyEnum newMyEnum) {
            var component = CreateComponent<MyEnumComponent>(ComponentIds.MyEnum);
            component.myEnum = newMyEnum;
            ReplaceComponent(ComponentIds.MyEnum, component);
            return this;
        }

        public Entity RemoveMyEnum() {
            return RemoveComponent(ComponentIds.MyEnum);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherMyEnum;

        public static IMatcher MyEnum {
            get {
                if (_matcherMyEnum == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.MyEnum);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherMyEnum = matcher;
                }

                return _matcherMyEnum;
            }
        }
    }
}
