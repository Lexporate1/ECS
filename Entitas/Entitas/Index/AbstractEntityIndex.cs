using System;

namespace Entitas {

    public abstract class AbstractEntityIndex<T> : IEntityIndex {

        protected readonly Group _group;
        protected readonly Func<IEntity, IComponent, T> _getKey;

        protected AbstractEntityIndex(
            Group group,
            Func<IEntity,
            IComponent, T> getKey) {
            _group = group;
            _getKey = getKey;
        }

        public virtual void Activate() {
            _group.OnEntityAdded += onEntityAdded;
            _group.OnEntityRemoved += onEntityRemoved;
        }

        public virtual void Deactivate() {
            _group.OnEntityAdded -= onEntityAdded;
            _group.OnEntityRemoved -= onEntityRemoved;
            clear();
        }

        protected void indexEntities(Group group) {
            var entities = group.GetEntities();
            for (int i = 0; i < entities.Length; i++) {
                addEntity(entities[i], null);
            }
        }

        protected void onEntityAdded(
            Group group, IEntity entity, int index, IComponent component) {
            addEntity(entity, component);
        }

        protected void onEntityRemoved(
            Group group, IEntity entity, int index, IComponent component) {
            removeEntity(entity, component);
        }

        protected abstract void addEntity(IEntity entity, IComponent component);

        protected abstract void removeEntity(
            IEntity entity, IComponent component
        );

        protected abstract void clear();

        ~AbstractEntityIndex () {
            Deactivate();
        }
    }

    public class EntityIndexException : EntitasException {
        public EntityIndexException(string message, string hint) :
        base(message, hint) {
        }
    }
}
