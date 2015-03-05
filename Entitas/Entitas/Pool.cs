﻿using System;
using System.Collections.Generic;

namespace Entitas {
    public partial class Pool {

        public int Count { get { return _entities.Count; } }

        readonly HashSet<Entity> _entities = new HashSet<Entity>(EntityEqualityComparer.comparer);
        readonly Dictionary<IMatcher, Group> _groups = new Dictionary<IMatcher, Group>();
        readonly List<Group>[] _groupsForIndex;
        readonly ObjectPool _entityPool;
        readonly int _totalComponents;
        int _creationIndex;
        Entity[] _entitiesCache;

        public Pool(int totalComponents) : this(totalComponents, 0) {
        }

        public Pool(int totalComponents, int startCreationIndex) {
            _totalComponents = totalComponents;
            _creationIndex = startCreationIndex;
            _groupsForIndex = new List<Group>[totalComponents];
            _entityPool = new ObjectPool(createEntity);
        }

        Entity createEntity() {
            return new Entity(_totalComponents);
        }

        public virtual Entity CreateEntity() {
            var entity = _entityPool.Get();
            entity._creationIndex = _creationIndex++;
            _entities.Add(entity);
            _entitiesCache = null;
            entity.OnComponentAdded += onComponentAddedOrRemoved;
            entity.OnComponentReplaced += onComponentReplaced;
            entity.OnComponentWillBeRemoved += onComponentWillBeRemoved;
            entity.OnComponentRemoved += onComponentAddedOrRemoved;
            return entity;
        }

        public virtual void DestroyEntity(Entity entity) {
            entity.RemoveAllComponents();
            entity.OnComponentAdded -= onComponentAddedOrRemoved;
            entity.OnComponentReplaced -= onComponentReplaced;
            entity.OnComponentWillBeRemoved -= onComponentWillBeRemoved;
            entity.OnComponentRemoved -= onComponentAddedOrRemoved;
            _entities.Remove(entity);
            _entitiesCache = null;
            _entityPool.Push(entity);
        }

        public void DestroyAllEntities() {
            var entities = GetEntities();
            for (int i = 0, entitiesLength = entities.Length; i < entitiesLength; i++) {
                DestroyEntity(entities[i]);
            }
        }

        public bool HasEntity(Entity entity) {
            return _entities.Contains(entity);
        }

        public Entity[] GetEntities() {
            if (_entitiesCache == null) {
                _entitiesCache = new Entity[_entities.Count];
                _entities.CopyTo(_entitiesCache);
            }

            return _entitiesCache;
        }

        public Group GetGroup(IMatcher matcher) {
            Group group;
            if (!_groups.TryGetValue(matcher, out group)) {
                group = new Group(matcher);
                var entities = GetEntities();
                for (int i = 0, entitiesLength = entities.Length; i < entitiesLength; i++) {
                    group.HandleEntity(entities[i]);
                }
                _groups.Add(matcher, group);

                for (int i = 0, indicesLength = matcher.indices.Length; i < indicesLength; i++) {
                    var index = matcher.indices[i];
                    if (_groupsForIndex[index] == null) {
                        _groupsForIndex[index] = new List<Group>();
                    }
                    _groupsForIndex[index].Add(group);
                }
            }

            return group;
        }

        void onComponentAddedOrRemoved(Entity entity, int index, IComponent component) {
            var groups = _groupsForIndex[index];
            if (groups != null) {
                for (int i = 0, groupsCount = groups.Count; i < groupsCount; i++) {
                    groups[i].HandleEntity(entity);
                }
            }
        }

        void onComponentReplaced(Entity entity, int index, IComponent component) {
            var groups = _groupsForIndex[index];
            if (groups != null) {
                for (int i = 0, groupsCount = groups.Count; i < groupsCount; i++) {
                    groups[i].UpdateEntity(entity);
                }
            }
        }

        void onComponentWillBeRemoved(Entity entity, int index, IComponent component) {
            var groups = _groupsForIndex[index];
            if (groups != null) {
                for (int i = 0, groupsCount = groups.Count; i < groupsCount; i++) {
                    var group = groups[i];
                    entity._components[index] = null;
                    var matches = group.Matches(entity);
                    entity._components[index] = component;
                    if (!matches) {
                        group.WillRemoveEntity(entity);
                    }
                }
            }
        }
    }

    class ObjectPool {
        public int Count { get { return _pool.Count; } }

        readonly Func<Entity> _factoryMethod;
        readonly Stack<Entity> _pool = new Stack<Entity>();

        public ObjectPool(Func<Entity> factoryMethod) {
            _factoryMethod = factoryMethod;
        }

        public Entity Get() {
            return _pool.Count > 0 ? _pool.Pop() : _factoryMethod();
        }

        public void Push(Entity entity) {
            _pool.Push(entity);
        }
    }
}

