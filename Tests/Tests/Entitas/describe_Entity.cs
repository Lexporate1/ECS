﻿using Entitas;
using NSpec;

class describe_Entity : nspec {

    readonly int[] _indicesA = { CID.ComponentA };
    readonly int[] _indicesAB = { CID.ComponentA, CID.ComponentB };

    void assertHasComponentA(Entity e, IComponent component = null) {
        if (component == null) {
            component = Component.A;
        }

        e.GetComponentA().should_be_same(component);
        var components = e.GetComponents();
        components.Length.should_be(1);
        components.should_contain(component);
        var indices = e.GetComponentIndices();
        indices.Length.should_be(1);
        indices.should_contain(CID.ComponentA);
        e.HasComponentA().should_be_true();
        e.HasComponents(_indicesA).should_be_true();
        e.HasAnyComponent(_indicesA).should_be_true();
    }

    void assertHasNotComponentA(Entity e) {
        var components = e.GetComponents();
        components.Length.should_be(0);
        var indices = e.GetComponentIndices();
        indices.Length.should_be(0);
        e.HasComponentA().should_be_false();
        e.HasComponents(_indicesA).should_be_false();
        e.HasAnyComponent(_indicesA).should_be_false();
    }

    void when_created() {

        Entity e = null;
        before = () => {
            e = this.CreateEntity();
        };

        context["initial state"] = () => {

            it["throws when attempting to get component of type which hasn't been added"] = expect<EntityDoesNotHaveComponentException>(() => {
                e.GetComponentA();
            });

            it["gets empty array of components when no components were added"] = () => {
                e.GetComponents().should_be_empty();
            };

            it["gets empty array of component indices when no components were added"] = () => {
                e.GetComponentIndices().should_be_empty();
            };

            it["doesn't have component of type when no component of that type was added"] = () => {
                e.HasComponentA().should_be_false();
            };

            it["doesn't have components of types when no components of these types were added"] = () => {
                e.HasComponents(_indicesA).should_be_false();
            };

            it["doesn't have any components of types when no components of these types were added"] = () => {
                e.HasAnyComponent(_indicesA).should_be_false();
            };

            it["returns entity when adding a component"] = () => {
                e.AddComponent(0, null).should_be_same(e);
            };

            it["adds a component"] = () => {
                e.AddComponentA();
                assertHasComponentA(e);
            };

            it["throws when attempting to remove a component of type which hasn't been added"] = expect<EntityDoesNotHaveComponentException>(() => {
                e.RemoveComponentA();
            });

            it["replacing a non existing component adds component"] = () => {
                e.ReplaceComponentA(Component.A);
                assertHasComponentA(e);
            };
        };

        context["when component added"] = () => {
            before = () => {
                e.AddComponentA();
            };

            it["throws when adding a component of the same type twice"] = expect<EntityAlreadyHasComponentException>(() => {
                e.AddComponentA();
                e.AddComponentA();
            });

            it["returns entity when removing a component"] = () => {
                e.RemoveComponent(CID.ComponentA).should_be_same(e);
            };

            it["removes a component of type"] = () => {
                e.RemoveComponentA();
                assertHasNotComponentA(e);
            };

            it["returns entity when replacing a component"] = () => {
                e.ReplaceComponent(CID.ComponentA, null).should_be_same(e);
            };

            it["replaces existing component"] = () => {
                var newComponentA = new ComponentA();
                e.ReplaceComponentA(newComponentA);
                assertHasComponentA(e, newComponentA);
            };

            it["doesn't have components of types when not all components of these types were added"] = () => {
                e.HasComponents(_indicesAB).should_be_false();
            };

            it["has any components of types when any component of these types was added"] = () => {
                e.HasAnyComponent(_indicesAB).should_be_true();
            };

            context["when adding another component"] = () => {
                before = () => {
                    e.AddComponentB();
                };

                it["gets all components"] = () => {
                    var components = e.GetComponents();
                    components.Length.should_be(2);
                    components.should_contain(Component.A);
                    components.should_contain(Component.B);
                };

                it["gets all component indices"] = () => {
                    var componentIndices = e.GetComponentIndices();
                    componentIndices.Length.should_be(2);
                    componentIndices.should_contain(CID.ComponentA);
                    componentIndices.should_contain(CID.ComponentB);
                };

                it["has other component"] = () => {
                    e.HasComponentB().should_be_true();
                };

                it["has components of types when all components of these types were added"] = () => {
                    e.HasComponents(_indicesAB).should_be_true();
                };

                it["removes all components"] = () => {
                    e.RemoveAllComponents();
                    e.HasComponentA().should_be_false();
                    e.HasComponentB().should_be_false();
                    e.GetComponents().should_be_empty();
                    e.GetComponentIndices().should_be_empty();
                };

                it["can ToString"] = () => {
                    e.ToString().should_be("Entity_0(ComponentA, ComponentB)");
                };
            };
        };

        context["events"] = () => {
            int didDispatch = 0;

            before = () => {
                didDispatch = 0;
            };

            it["dispatches OnComponentAdded when adding a component"] = () => {
                e.OnComponentAdded += (entity, index, component) => {
                    didDispatch += 1;
                    entity.should_be_same(e);
                    index.should_be(CID.ComponentA);
                    component.should_be_same(Component.A);
                };
                e.OnComponentRemoved += (entity, index, component) => this.Fail();
                e.OnComponentReplaced += (entity, index, previousComponent, newComponent) => this.Fail();

                e.AddComponentA();
                didDispatch.should_be(1);
            };

            it["dispatches OnComponentRemoved when removing a component"] = () => {
                e.AddComponentA();
                e.OnComponentRemoved += (entity, index, component) => {
                    didDispatch += 1;
                    entity.should_be_same(e);
                    index.should_be(CID.ComponentA);
                    component.should_be_same(Component.A);
                };
                e.OnComponentAdded += (entity, index, component) => this.Fail();
                e.OnComponentReplaced += (entity, index, previousComponent, newComponent) => this.Fail();

                e.RemoveComponentA();
                didDispatch.should_be(1);
            };

            it["dispatches OnComponentReplaced when replacing a component"] = () => {
                e.AddComponentA();
                var newComponentA = new ComponentA();
                e.OnComponentReplaced += (entity, index, previousComponent, newComponent) => {
                    didDispatch += 1;
                    entity.should_be_same(e);
                    index.should_be(CID.ComponentA);
                    previousComponent.should_be_same(Component.A);
                    newComponent.should_be_same(newComponentA);
                };
                e.OnComponentAdded += (entity, index, component) => this.Fail();
                e.OnComponentRemoved += (entity, index, component) => this.Fail();

                e.ReplaceComponentA(newComponentA);
                didDispatch.should_be(1);
            };

            it["provides previous and new component OnComponentReplaced when replacing with different component"] = () => {
                var prevComp = new ComponentA();
                var newComp = new ComponentA();
                e.OnComponentReplaced += (entity, index, previousComponent, newComponent) => {
                    didDispatch += 1;
                    entity.should_be_same(e);
                    previousComponent.should_be_same(prevComp);
                    newComponent.should_be_same(newComp);
                };

                e.AddComponent(CID.ComponentA, prevComp);
                e.ReplaceComponent(CID.ComponentA, newComp);
                didDispatch.should_be(1);
            };

            it["provides previous and new component OnComponentReplaced when replacing with same component"] = () => {
                e.OnComponentReplaced += (entity, index, previousComponent, newComponent) => {
                    didDispatch += 1;
                    entity.should_be_same(e);
                    previousComponent.should_be_same(Component.A);
                    newComponent.should_be_same(Component.A);
                };

                e.AddComponentA();
                e.ReplaceComponentA(Component.A);
                didDispatch.should_be(1);
            };

            it["doesn't dispatch anything when replacing a non existing component with null"] = () => {
                e.OnComponentAdded += (entity, index, component) => this.Fail();
                e.OnComponentReplaced += (entity, index, previousComponent, newComponent) => this.Fail();
                e.OnComponentRemoved += (entity, index, component) => this.Fail();

                e.ReplaceComponentA(null);
            };

            it["dispatches OnComponentAdded when attempting to replace a component which hasn't been added"] = () => {
                var newComponentA = new ComponentA();
                e.OnComponentAdded += (entity, index, component) => {
                    didDispatch += 1;
                    entity.should_be_same(e);
                    index.should_be(CID.ComponentA);
                    component.should_be_same(newComponentA);
                };
                e.OnComponentReplaced += (entity, index, previousComponent, newComponent) => this.Fail();
                e.OnComponentRemoved += (entity, index, component) => this.Fail();

                e.ReplaceComponentA(newComponentA);
                didDispatch.should_be(1);
            };

            it["dispatches OnComponentRemoved when replacing a component with null"] = () => {
                e.AddComponentA();
                e.OnComponentRemoved += (entity, index, component) => {
                    didDispatch += 1;
                };
                e.OnComponentAdded += (entity, index, component) => this.Fail();
                e.OnComponentReplaced += (entity, index, previousComponent, newComponent) => this.Fail();

                e.ReplaceComponentA(null);
                didDispatch.should_be(1);
            };

            it["dispatches OnComponentRemoved when removing all components"] = () => {
                e.AddComponentA();
                e.AddComponentB();
                e.OnComponentRemoved += (entity, index, component) => didDispatch += 1;
                e.RemoveAllComponents();
                didDispatch.should_be(2);
            };
        };

        context["reference counting"] = () => {
            it["retains entity"] = () => {
                e.RefCount().should_be(0);
                e.Retain();
                e.RefCount().should_be(1);
            };

            it["releases entity"] = () => {
                e.Retain();
                e.Release();
                e.RefCount().should_be(0);
            };

            it["throws when releasing more than it has been retained"] = expect<EntityIsAlreadyReleasedException>(() => {
                e.Retain();
                e.Release();
                e.Release();
            });

            context["events"] = () => {
                it["doesn't dispatch OnEntityReleased when retaining"] = () => {
                    e.OnEntityReleased += entity => this.Fail();
                    e.Retain();
                };

                it["dispatches OnEntityReleased when retain and release"] = () => {
                    var didDispatch = 0;
                    e.OnEntityReleased += entity => {
                        didDispatch += 1;
                        entity.should_be_same(e);
                    };
                    e.Retain();
                    e.Release();
                };
            };
        };

        context["internal caching"] = () => {
            context["components"] = () => {

                IComponent[] cache = null;
                before = () => {
                    e.AddComponentA();
                    cache = e.GetComponents();
                };

                it["caches components"] = () => {
                    e.GetComponents().should_be_same(cache);
                };

                it["updates cache when a new component was added"] = () => {
                    e.AddComponentB();
                    e.GetComponents().should_not_be_same(cache);
                };

                it["updates cache when a component was removed"] = () => {
                    e.RemoveComponentA();
                    e.GetComponents().should_not_be_same(cache);
                };

                it["updates cache when a component was replaced"] = () => {
                    e.ReplaceComponentA(new ComponentA());
                    e.GetComponents().should_not_be_same(cache);
                };

                it["doesn't update cache when a component was replaced with same component"] = () => {
                    e.ReplaceComponentA(Component.A);
                    e.GetComponents().should_be_same(cache);
                };

                it["updates cache when all components were removed"] = () => {
                    e.RemoveAllComponents();
                    e.GetComponents().should_not_be_same(cache);
                };
            };

            context["component indices"] = () => {

                int[] cache = null;
                before = () => {
                    e.AddComponentA();
                    cache = e.GetComponentIndices();
                };

                it["caches component indices"] = () => {
                    e.GetComponentIndices().should_be_same(cache);
                };

                it["updates cache when a new component was added"] = () => {
                    e.AddComponentB();
                    e.GetComponentIndices().should_not_be_same(cache);
                };

                it["updates cache when a component was removed"] = () => {
                    e.RemoveComponentA();
                    e.GetComponentIndices().should_not_be_same(cache);
                };

                it["doesn't update cache when a component was replaced"] = () => {
                    e.ReplaceComponentA(new ComponentA());
                    e.GetComponentIndices().should_be_same(cache);
                };

                it["updates cache when adding a new component with ReplaceComponent"] = () => {
                    e.ReplaceComponentC(Component.C);
                    e.GetComponentIndices().should_not_be_same(cache);
                };

                it["updates cache when all components were removed"] = () => {
                    e.RemoveAllComponents();
                    e.GetComponentIndices().should_not_be_same(cache);
                };
            };

            context["ToString"] = () => {

                context["when component was added"] = () => {

                    string cache = null;
                    before = () => {
                        e.AddComponentA();
                        cache = e.ToString();
                    };

                    it["caches entity description"] = () => {
                        e.ToString().should_be_same(cache);
                    };

                    it["updates cache when a new component was added"] = () => {
                        e.AddComponentB();
                        e.ToString().should_not_be_same(cache);
                    };

                    it["updates cache when a component was removed"] = () => {
                        e.RemoveComponentA();
                        e.ToString().should_not_be_same(cache);
                    };

                    it["doesn't update cache when a component was replaced"] = () => {
                        e.ReplaceComponentA(new ComponentA());
                        e.ToString().should_be_same(cache);
                    };

                    it["updates cache when all components were removed"] = () => {
                        e.RemoveAllComponents();
                        e.ToString().should_not_be_same(cache);
                    };
                };

                it["updates cache when RemoveAllComponents is called, even if entity has no components"] = () => {
                    var str = e.ToString();
                    e.RemoveAllComponents();
                    e.ToString().should_not_be_same(str);
                };
            };
        };
    }
}

