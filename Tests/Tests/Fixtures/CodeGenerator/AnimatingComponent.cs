using Entitas.CodeGenerator;
using Entitas;

[SingleEntity]
public class AnimatingComponent : IComponent {
    public static string extensions =
        @"namespace Entitas {
    public partial class Entity {
        static readonly AnimatingComponent animatingComponent = new AnimatingComponent();

        public bool isAnimating { get { return HasComponent(ComponentIds.Animating); } }

        public void FlagAnimating() {
            AddComponent(ComponentIds.Animating, animatingComponent);
        }

        public void UnflagAnimating() {
            RemoveComponent(ComponentIds.Animating);
        }
    }

    public partial class EntityRepository {
        public Entity animatingEntity { get { return GetCollection(Matcher.Animating).GetSingleEntity(); } }

        public bool isAnimating { get { return animatingEntity != null; } }

        public Entity FlagAnimating() {
            if (isAnimating) {
                throw new SingleEntityException(Matcher.Animating);
            }
            var entity = CreateEntity();
            entity.FlagAnimating();
            return entity;
        }

        public void UnflagAnimating() {
            DestroyEntity(animatingEntity);
        }
    }

    public static partial class Matcher {
        static AllOfEntityMatcher _matcherAnimating;

        public static AllOfEntityMatcher Animating {
            get {
                if (_matcherAnimating == null) {
                    _matcherAnimating = EntityMatcher.AllOf(new [] { ComponentIds.Animating });
                }

                return _matcherAnimating;
            }
        }
    }
}";
    }
