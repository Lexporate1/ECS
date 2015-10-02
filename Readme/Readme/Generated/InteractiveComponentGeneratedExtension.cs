namespace Entitas {
    public partial class Entity {
        static readonly InteractiveComponent interactiveComponent = new InteractiveComponent();

        public bool isInteractive {
            get { return HasComponent(ComponentIds.Interactive); }
            set {
                if (value != isInteractive) {
                    if (value) {
                        AddComponent(ComponentIds.Interactive, interactiveComponent);
                    } else {
                        RemoveComponent(ComponentIds.Interactive);
                    }
                }
            }
        }

        public Entity IsInteractive(bool value) {
            isInteractive = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherInteractive;

        public static IMatcher Interactive {
            get {
                if (_matcherInteractive == null) {
                    _matcherInteractive = Matcher.AllOf(ComponentIds.Interactive);
                }

                return _matcherInteractive;
            }
        }
    }
}
