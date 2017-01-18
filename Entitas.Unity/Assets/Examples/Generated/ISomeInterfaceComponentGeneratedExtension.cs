//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public class ISomeInterfaceComponent : IComponent {

    public ISomeInterface value;
}

namespace Entitas {

    public sealed partial class VisualDebuggingEntity : Entity {

        public ISomeInterfaceComponent iSomeInterface { get { return (ISomeInterfaceComponent)GetComponent(VisualDebuggingComponentIds.ISomeInterface); } }
        public bool hasISomeInterface { get { return HasComponent(VisualDebuggingComponentIds.ISomeInterface); } }

        public void AddISomeInterface(ISomeInterface newValue) {
            var component = CreateComponent<ISomeInterfaceComponent>(VisualDebuggingComponentIds.ISomeInterface);
            component.value = newValue;
            AddComponent(VisualDebuggingComponentIds.ISomeInterface, component);
        }

        public void ReplaceISomeInterface(ISomeInterface newValue) {
            var component = CreateComponent<ISomeInterfaceComponent>(VisualDebuggingComponentIds.ISomeInterface);
            component.value = newValue;
            ReplaceComponent(VisualDebuggingComponentIds.ISomeInterface, component);
        }

        public void RemoveISomeInterface() {
            RemoveComponent(VisualDebuggingComponentIds.ISomeInterface);
        }
    }

    public partial class VisualDebuggingContext {

        public VisualDebuggingEntity iSomeInterfaceEntity { get { return GetGroup(VisualDebuggingMatcher.ISomeInterface).GetSingleEntity(); } }
        public ISomeInterfaceComponent iSomeInterface { get { return iSomeInterfaceEntity.iSomeInterface; } }
        public bool hasISomeInterface { get { return iSomeInterfaceEntity != null; } }

        public VisualDebuggingEntity SetISomeInterface(ISomeInterface newValue) {
            if(hasISomeInterface) {
                throw new EntitasException("Could not set iSomeInterface!\n" + this + " already has an entity with ISomeInterfaceComponent!",
                    "You should check if the context already has a iSomeInterfaceEntity before setting it or use context.ReplaceISomeInterface().");
            }
            var entity = CreateEntity();
            entity.AddISomeInterface(newValue);
            return entity;
        }

        public VisualDebuggingEntity ReplaceISomeInterface(ISomeInterface newValue) {
            var entity = iSomeInterfaceEntity;
            if(entity == null) {
                entity = SetISomeInterface(newValue);
            } else {
                entity.ReplaceISomeInterface(newValue);
            }

            return entity;
        }

        public void RemoveISomeInterface() {
            DestroyEntity(iSomeInterfaceEntity);
        }
    }
}

    public partial class VisualDebuggingMatcher {

        static IMatcher<VisualDebuggingEntity> _matcherISomeInterface;

        public static IMatcher<VisualDebuggingEntity> ISomeInterface {
            get {
                if(_matcherISomeInterface == null) {
                    var matcher = (Matcher<VisualDebuggingEntity>)Matcher<VisualDebuggingEntity>.AllOf(VisualDebuggingComponentIds.ISomeInterface);
                    matcher.componentNames = VisualDebuggingComponentIds.componentNames;
                    _matcherISomeInterface = matcher;
                }

                return _matcherISomeInterface;
            }
        }
    }
