﻿using NSpec;
using Entitas;

class describe_Systems : nspec {

    static ReactiveSystem createReactiveSystem() {
        var subSystem = new ReactiveSubSystemSpy(Matcher.AllOf(new[] {
            CID.ComponentA
        }), GroupEventType.OnEntityAdded);
        var pool = new Pool(10);
        var reactiveSystem = new ReactiveSystem(pool, subSystem);
        pool.CreateEntity().AddComponentA();

        return reactiveSystem;
    }

    void when_systems() {

        context["fixtures"] = () => {
            it["starts InitializeSystemSpy"] = () => {
                var initializeSystem = new InitializeSystemSpy();
                initializeSystem.started.should_be_false();
                initializeSystem.Initialize();
                initializeSystem.started.should_be_true();
            };

            it["executes ExecuteSystemSpy"] = () => {
                var initializeSystem = new ExecuteSystemSpy();
                initializeSystem.executed.should_be_false();
                initializeSystem.Execute();
                initializeSystem.executed.should_be_true();
            };

            it["starts and executes InitializeExecuteSystemSpy"] = () => {
                var initializeSystem = new InitializeExecuteSystemSpy();
                initializeSystem.started.should_be_false();
                initializeSystem.executed.should_be_false();
                initializeSystem.Initialize();
                initializeSystem.Execute();
                initializeSystem.started.should_be_true();
                initializeSystem.executed.should_be_true();
            };

            it["executes ReactiveSystemSpy"] = () => {
                var system = createReactiveSystem();
                var spy = (ReactiveSubSystemSpy)system.subsystem;
                spy.didExecute.should_be(0);
                spy.started.should_be_false();
                system.Execute();
                spy.didExecute.should_be(1);
                spy.started.should_be_false();
            };
        };

        context["systems"] = () => {
            Systems systems = null;
            before = () => {
                systems = new Systems();
            };

            it["returns systems when adding system"] = () => {
                systems.Add(new InitializeSystemSpy()).should_be_same(systems);
            };

            it["starts IInitializeSystem"] = () => {
                var system = new InitializeSystemSpy();
                systems.Add(system);
                systems.Initialize();
                system.started.should_be_true();
            };

            it["executes IExecuteSystem"] = () => {
                var system = new ExecuteSystemSpy();
                systems.Add(system);
                systems.Execute();
                system.executed.should_be_true();
            };

            it["starts and executes IInitializeSystem, IExecuteSystem"] = () => {
                var system = new InitializeExecuteSystemSpy();
                systems.Add(system);
                systems.Initialize();
                systems.Execute();
                system.started.should_be_true();
                system.executed.should_be_true();
            };

            it["starts and executes ReactiveSystem"] = () => {
                var system = createReactiveSystem();

                systems.Add(system);
                systems.Initialize();
                systems.Execute();
                systems.Execute();

                var spy = (ReactiveSubSystemSpy)system.subsystem;
                spy.didExecute.should_be(1);
                spy.started.should_be_true();
            };
        };
    }
}

