﻿using NSpec;
using Entitas;

class describe_Group : nspec {
    Group _group;
    Entity _eA1;
    Entity _eA2;

    void before_each() {
        _group = new Group(Matcher.AllOf(new [] { CID.ComponentA }));
        _eA1 = this.CreateEntity();
        _eA1.AddComponentA();
        _eA2 = this.CreateEntity();
        _eA2.AddComponentA();
    }

    void when_created() {
        it["doesn't have entities which haven't been added"] = () => {
            _group.GetEntities().should_be_empty();
        };

        it["is empty"] = () => {
            _group.Count.should_be(0);
        };

        context["when entity is matching"] = () => {
            before = () => {
                handle(_eA1);
            };

            it["adds matching entity"] = () => _group.GetEntities().should_contain(_eA1);
            it["isn't empty"] = () => _group.Count.should_be(1);
            it["contains entity"] = () => _group.ContainsEntity(_eA1).should_be_true();

            it["doesn't add same entity twice"] = () => {
                handle(_eA1);
                _group.GetEntities().should_contain(_eA1);
                _group.GetEntities().Length.should_be(1);
            };
        };

        context["when entity doesn't match"] = () => {
            before = () => {
                handle(_eA1);
                _eA1.RemoveComponentA();
                handle(_eA1);
            };

            it["doesn't add entity when not matching"] = () => {
                var e = this.CreateEntity();
                e.AddComponentB();
                handle(e);
                _group.GetEntities().should_be_empty();
            };

            it["removes entity"] = () => _group.GetEntities().should_be_empty();
            it["doesn't contains entity"] = () => _group.ContainsEntity(_eA1).should_be_false();
        };

        it["gets null when single entity does not exist"] = () => {
            _group.GetSingleEntity().should_be_null();
        };

        it["gets single entity"] = () => {
            handle(_eA1);
            _group.GetSingleEntity().should_be_same(_eA1);
        };

        it["throws when attempting to get single entity and multiple matching entities exist"] = expect<SingleEntityException>(() => {
            handle(_eA1);
            handle(_eA2);
            _group.GetSingleEntity();
        });

        context["events"] = () => {
            var didDispatch = 0;

            before = () => {
                didDispatch = 0;
            };

            it["dispatches OnEntityAdded when matching entity added"] = () => {
                _group.OnEntityAdded += (group, entity, index, component) => {
                    didDispatch++;
                    group.should_be_same(_group);
                    entity.should_be_same(_eA1);
                    index.should_be(CID.ComponentA);
                    component.should_be_same(Component.A);
                };

                handleAddEA(_eA1);
                didDispatch.should_be(1);
            };

            it["doesn't dispatches OnEntityAdded when matching entity already has been added"] = () => {
                _group.OnEntityAdded += (group, entity, index, component) => didDispatch++;
                handleAddEA(_eA1);
                handleAddEA(_eA1);
                didDispatch.should_be(1);
            };

            it["dispatches OnEntityRemoved when entity got removed"] = () => {
                _group.OnEntityRemoved += (group, entity, index, component) => {
                    didDispatch++;
                    group.should_be_same(_group);
                    entity.should_be_same(_eA1);
                    index.should_be(CID.ComponentA);
                    component.should_be_same(Component.A);
                };

                handle(_eA1);
                _eA1.RemoveComponentA();
                handleRemoveEA(_eA1, Component.A);

                didDispatch.should_be(1);
            };

            it["doesn't dispatch OnEntityRemoved when entity didn't get removed"] = () => {
                _group.OnEntityRemoved += (group, entity, index, component) => this.Fail();
                _eA1.RemoveComponentA();
                handleRemoveEA(_eA1, Component.A);
            };
            
            it["dispatches OnEntityRemoved and OnEntityAdded when updating"] = () => {
                handle(_eA1);
                var removed = 0;
                var added = 0;
                _group.OnEntityRemoved += (group, entity, index, component) => removed++;
                _group.OnEntityAdded += (group, entity, index, component) => added++;

                _group.UpdateEntity(_eA1, 0, null, null);

                removed.should_be(1);
                added.should_be(1);
            };

            it["doesn't dispatch OnEntityRemoved and OnEntityAdded when updating when group doesn't contain entity"] = () => {
                _group.OnEntityRemoved += (group, entity, index, component) => this.Fail();
                _group.OnEntityAdded += (group, entity, index, component) => this.Fail();
                _group.UpdateEntity(_eA1, 0, null, null);
            };
        };

        context["internal caching"] = () => {
            it["gets cached entities"] = () => {
                handle(_eA1);
                _group.GetEntities().should_be_same(_group.GetEntities());
            };

            it["updates cache when adding a new matching entity"] = () => {
                handle(_eA1);
                var g = _group.GetEntities();
                handle(_eA2);
                g.should_not_be_same(_group.GetEntities());
            };

            it["doesn't update cache when attempting to add a not matching entity"] = () => {
                handle(_eA1);
                var g = _group.GetEntities();
                var e = this.CreateEntity();
                handle(e);
                g.should_be_same(_group.GetEntities());
            };

            it["updates cache when removing an entity"] = () => {
                handle(_eA1);
                var g = _group.GetEntities();
                _eA1.RemoveComponentA();
                handle(_eA1);
                g.should_not_be_same(_group.GetEntities());
            };

            it["doesn't update cache when attempting to remove an entity that wasn't added before"] = () => {
                var g = _group.GetEntities();
                _eA1.RemoveComponentA();
                handle(_eA1);
                g.should_be_same(_group.GetEntities());
            };

            it["gets cached singleEntities"] = () => {
                handle(_eA1);
                _group.GetSingleEntity().should_be_same(_group.GetSingleEntity());
            };

            it["updates cache when new single entity was added"] = () => {
                handle(_eA1);
                var s = _group.GetSingleEntity();
                _eA1.RemoveComponentA();
                handle(_eA1);
                handle(_eA2);
                s.should_not_be_same(_group.GetSingleEntity());
            };

            it["updates cache when single entity is removed"] = () => {
                handle(_eA1);
                var s = _group.GetSingleEntity();
                _eA1.RemoveComponentA();
                handle(_eA1);
                s.should_not_be_same(_group.GetSingleEntity());
            };
        };

        it["can ToString"] = () => {
            var m = Matcher.AllOf(Matcher.AllOf(0), Matcher.AllOf(1));
            var group = new Group(m);
            group.ToString().should_be("Group(AllOf(0, 1))");
        };
    }

    void handle(Entity entity, int index, IComponent component) {
        _group.HandleEntity(entity, index, component);
    }

    void handle(Entity entity) {
        _group.HandleEntity(entity);
    }

    void handleAddEA(Entity entity) {
        handle(entity, CID.ComponentA, entity.GetComponent(CID.ComponentA));
    }

    void handleRemoveEA(Entity entity, IComponent component) {
        handle(entity, CID.ComponentA, component);
    }
}

