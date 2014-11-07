namespace Entitas {
    public partial class Entity {
        public UserComponent user { get { return (UserComponent)GetComponent(ComponentIds.User); } }

        public bool hasUser { get { return HasComponent(ComponentIds.User); } }

        public void AddUser(UserComponent component) {
            AddComponent(ComponentIds.User, component);
        }

        public void AddUser(string newName, int newAge) {
            var component = new UserComponent();
            component.name = newName;
            component.age = newAge;
            AddUser(component);
        }

        public void ReplaceUser(UserComponent component) {
            ReplaceComponent(ComponentIds.User, component);
        }

        public void ReplaceUser(string newName, int newAge) {
            UserComponent component;
            if (hasUser) {
                WillRemoveComponent(ComponentIds.User);
                component = user;
            } else {
                component = new UserComponent();
            }
            component.name = newName;
            component.age = newAge;
            ReplaceUser(component);
        }

        public void RemoveUser() {
            RemoveComponent(ComponentIds.User);
        }
    }

    public partial class EntityRepository {
        public Entity userEntity { get { return GetCollection(Matcher.User).GetSingleEntity(); } }

        public UserComponent user { get { return userEntity.user; } }

        public bool hasUser { get { return userEntity != null; } }

        public Entity SetUser(UserComponent component) {
            if (hasUser) {
                throw new SingleEntityException(Matcher.User);
            }
            var entity = CreateEntity();
            entity.AddUser(component);
            return entity;
        }

        public Entity SetUser(string newName, int newAge) {
            if (hasUser) {
                throw new SingleEntityException(Matcher.User);
            }
            var entity = CreateEntity();
            entity.AddUser(newName, newAge);
            return entity;
        }

        public Entity ReplaceUser(UserComponent component) {
            var entity = userEntity;
            if (entity == null) {
                entity = SetUser(component);
            } else {
                entity.ReplaceUser(component);
            }

            return entity;
        }

        public Entity ReplaceUser(string newName, int newAge) {
            var entity = userEntity;
            if (entity == null) {
                entity = SetUser(newName, newAge);
            } else {
                entity.ReplaceUser(newName, newAge);
            }

            return entity;
        }

        public void RemoveUser() {
            DestroyEntity(userEntity);
        }
    }

    public static partial class Matcher {
        static AllOfEntityMatcher _matcherUser;

        public static AllOfEntityMatcher User {
            get {
                if (_matcherUser == null) {
                    _matcherUser = EntityMatcher.AllOf(new [] { ComponentIds.User });
                }

                return _matcherUser;
            }
        }
    }
}
