using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Entitas.Unity.VisualDebugging {

    public class PoolObserver {

        public Pool pool { get { return _pool; } }
        public Group[] groups { get { return _groups.ToArray(); }}
        public GameObject gameObject { get { return _gameObject; } }

        readonly Pool _pool;
        readonly List<Group> _groups;
        readonly GameObject _gameObject;
        StringBuilder _toStringBuilder = new StringBuilder();

        public PoolObserver(Pool pool) {
            _pool = pool;
            _groups = new List<Group>();
            _gameObject = new GameObject();
            _gameObject.AddComponent<PoolObserverBehaviour>().Init(this);

            _pool.OnEntityCreated += onEntityCreated;
            _pool.OnGroupCreated += onGroupCreated;
            _pool.OnGroupCleared += onGroupCleared;
        }

        public void Deactivate() {
            _pool.OnEntityCreated -= onEntityCreated;
            _pool.OnGroupCreated -= onGroupCreated;
            _pool.OnGroupCleared -= onGroupCleared;
        }

        void onEntityCreated(Pool pool, Entity entity) {
            var entityBehaviour = new GameObject().AddComponent<EntityBehaviour>();
            entityBehaviour.Init(pool, entity);
            entityBehaviour.transform.SetParent(_gameObject.transform, false);
        }

        void onGroupCreated(Pool pool, Group group) {
            _groups.Add(group);
        }

        void onGroupCleared(Pool pool, Group group) {
            _groups.Remove(group);
        }

        public override string ToString() {
            _toStringBuilder.Length = 0;
            _toStringBuilder
                .Append(_pool.metaData.poolName).Append(" (")
                .Append(_pool.count).Append(" entities, ")
                .Append(_pool.reusableEntitiesCount).Append(" reusable, ");

            if(_pool.retainedEntitiesCount != 0) {
                _toStringBuilder
                    .Append(_pool.retainedEntitiesCount).Append(" retained, ");
            }

            _toStringBuilder
                .Append(_groups.Count)
                .Append(" groups)");

            var str = _toStringBuilder.ToString();
            _gameObject.name = str;
            return str;
        }
    }
}
