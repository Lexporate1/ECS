﻿using Entitas;

namespace My.Namespace {
    public class NamespaceComponent : IComponent {
        public static string extensions =
            @"namespace Entitas {
    public partial class Entity {
        static readonly My.Namespace.NamespaceComponent namespaceComponent = new My.Namespace.NamespaceComponent();

        public bool isNamespace {
            get { return HasComponent(ComponentIds.Namespace); }
            set {
                if (value != isNamespace) {
                    if (value) {
                        AddComponent(ComponentIds.Namespace, namespaceComponent);
                    } else {
                        RemoveComponent(ComponentIds.Namespace);
                    }
                }
            }
        }

        public Entity IsNamespace(bool value) {
            isNamespace = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherNamespace;

        public static IMatcher Namespace {
            get {
                if (_matcherNamespace == null) {
                    _matcherNamespace = Matcher.AllOf(ComponentIds.Namespace);
                }

                return _matcherNamespace;
            }
        }
    }
}
";

    }
}

