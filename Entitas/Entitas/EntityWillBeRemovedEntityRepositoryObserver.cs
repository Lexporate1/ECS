﻿using ToolKit;
using System.Collections.Generic;

namespace Entitas {
    public class EntityComponentPair {
        public Entity entity { get { return _entity; } }

        public IComponent component { get { return _component; } }

        readonly Entity _entity;
        readonly IComponent _component;

        public EntityComponentPair(Entity entity, IComponent component) {
            _entity = entity;
            _component = component;
        }
    }

    public class EntityWillBeRemovedEntityRepositoryObserver {
        public HashSet<EntityComponentPair> collectedEntityComponentPairs { get { return _collectedEntityComponentPairs; } }

        readonly HashSet<Entity> _collectedEntities;
        readonly HashSet<EntityComponentPair> _collectedEntityComponentPairs;
        readonly EntityCollection _collection;
        readonly int _index;

        public EntityWillBeRemovedEntityRepositoryObserver(EntityRepository repo, int index) {
            _collectedEntities = new HashSet<Entity>(new EntityEqualityComparer());
            _collectedEntityComponentPairs = new HashSet<EntityComponentPair>();
            _collection = repo.GetCollection(EntityMatcher.AllOf(new [] { index }));
            _index = index;

            Activate();
        }

        public void Activate() {
            _collection.OnEntityWillBeRemoved += addEntity;
        }

        public void Deactivate() {
            _collectedEntities.Clear();
            _collectedEntityComponentPairs.Clear();
            _collection.OnEntityWillBeRemoved -= addEntity;
        }

        public void ClearCollectedEntites() {
            _collectedEntities.Clear();
            _collectedEntityComponentPairs.Clear();
        }

        void addEntity(EntityCollection collection, Entity entity) {
            var added = _collectedEntities.Add(entity);
            if (added) {
                _collectedEntityComponentPairs.Add(new EntityComponentPair(entity, entity.GetComponent(_index)));
            }
        }
    }
}

