//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

namespace Entitas {
    public partial class Entity {
        public CoinsComponent coins { get { return (CoinsComponent)GetComponent(MetaComponentIds.Coins); } }

        public bool hasCoins { get { return HasComponent(MetaComponentIds.Coins); } }

        public Entity AddCoins(int newCount) {
            var component = CreateComponent<CoinsComponent>(MetaComponentIds.Coins);
            component.count = newCount;
            return AddComponent(MetaComponentIds.Coins, component);
        }

        public Entity ReplaceCoins(int newCount) {
            var component = CreateComponent<CoinsComponent>(MetaComponentIds.Coins);
            component.count = newCount;
            ReplaceComponent(MetaComponentIds.Coins, component);
            return this;
        }

        public Entity RemoveCoins() {
            return RemoveComponent(MetaComponentIds.Coins);
        }
    }

    public partial class Context {
        public Entity coinsEntity { get { return GetGroup(MetaMatcher.Coins).GetSingleEntity(); } }

        public CoinsComponent coins { get { return coinsEntity.coins; } }

        public bool hasCoins { get { return coinsEntity != null; } }

        public Entity SetCoins(int newCount) {
            if (hasCoins) {
                throw new EntitasException("Could not set coins!\n" + this + " already has an entity with CoinsComponent!",
                    "You should check if the pool already has a coinsEntity before setting it or use pool.ReplaceCoins().");
            }
            var entity = CreateEntity();
            entity.AddCoins(newCount);
            return entity;
        }

        public Entity ReplaceCoins(int newCount) {
            var entity = coinsEntity;
            if (entity == null) {
                entity = SetCoins(newCount);
            } else {
                entity.ReplaceCoins(newCount);
            }

            return entity;
        }

        public void RemoveCoins() {
            DestroyEntity(coinsEntity);
        }
    }
}

    public partial class MetaMatcher {
        static IMatcher _matcherCoins;

        public static IMatcher Coins {
            get {
                if (_matcherCoins == null) {
                    var matcher = (Matcher)Matcher.AllOf(MetaComponentIds.Coins);
                    matcher.componentNames = MetaComponentIds.componentNames;
                    _matcherCoins = matcher;
                }

                return _matcherCoins;
            }
        }
    }
