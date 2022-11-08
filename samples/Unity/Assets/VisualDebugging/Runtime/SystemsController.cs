using Entitas;
using UnityEngine;

public class SystemsController : MonoBehaviour
{
    Contexts _contexts;
    Systems _systems;

    void Start()
    {
        _contexts = new Contexts();

        //_systems = createNestedSystems();

        _systems = new Feature().Add(new SomeMultiReactiveSystem(_contexts));

        //// Test call
        _systems.Initialize();
        _systems.Execute();
        _systems.Cleanup();
        _systems.TearDown();

        _contexts.game.CreateEntity().AddMyString("");
    }

    void Update()
    {
        _contexts.game.GetGroup(GameMatcher.MyString).GetSingleEntity()
            .ReplaceMyString(Random.value.ToString());

        _systems.Execute();
        _systems.Cleanup();
    }

    Systems CreateAllSystemCombinations() => new Feature("All System Combinations")
        .Add(new SomeInitializeSystem())
        .Add(new SomeExecuteSystem())
        .Add(new SomeReactiveSystem(_contexts))
        .Add(new SomeMultiReactiveSystem(_contexts))
        .Add(new SomeInitializeExecuteSystem())
        .Add(new SomeInitializeReactiveSystem(_contexts));

    Systems CreateSubSystems()
    {
        var allSystems = CreateAllSystemCombinations();
        var subSystems = new Feature("Sub Systems").Add(allSystems);
        return new Feature("Systems with SubSystems")
            .Add(allSystems)
            .Add(allSystems)
            .Add(subSystems)
            .Add(subSystems);
    }

    Systems CreateSameInstance()
    {
        var system = new RandomDurationSystem();
        return new Feature("Same System Instances")
            .Add(system)
            .Add(system)
            .Add(system);
    }

    Systems CreateNestedSystems()
    {
        var systems1 = new Feature("Nested 1");
        var systems2 = new Feature("Nested 2");
        var systems3 = new Feature("Nested 3");

        systems1.Add(systems2);
        systems2.Add(systems3);
        systems1.Add(CreateSomeSystems());

        return new Feature("Nested Systems")
            .Add(systems1);
    }

    Systems CreateEmptySystems()
    {
        var systems1 = new Feature("Empty 1");
        var systems2 = new Feature("Empty 2");
        var systems3 = new Feature("Empty 3");

        systems1.Add(systems2);
        systems2.Add(systems3);

        return new Feature("Empty Systems")
            .Add(systems1);
    }

    Systems CreateSomeSystems()
    {
        return new SomeSystems(_contexts);
    }

    sealed class SomeSystems : Feature
    {
        public SomeSystems(Contexts contexts)
        {
            Add(new SlowInitializeSystem());
            Add(new SlowInitializeExecuteSystem());
            Add(new FastSystem());
            Add(new SlowSystem());
            Add(new RandomDurationSystem());
            Add(new AReactiveSystem(contexts));

            Add(new RandomValueSystem(contexts));
            Add(new ProcessRandomValueSystem(contexts));
            Add(new CleanupSystem());
            Add(new TearDownSystem());
            Add(new MixedSystem());
        }
    }
}
