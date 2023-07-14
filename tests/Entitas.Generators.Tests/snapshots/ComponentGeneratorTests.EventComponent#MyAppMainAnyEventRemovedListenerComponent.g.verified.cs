﻿//HintName: MyAppMainAnyEventRemovedListenerComponent.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ComponentGenerator.Events
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using global::MyApp.Main;

public interface IMyAppMainAnyEventRemovedListener
{
    void OnAnyEventRemoved(Entity entity);
}

public sealed class MyAppMainAnyEventRemovedListenerComponent : global::Entitas.IComponent
{
    public global::System.Collections.Generic.List<IMyAppMainAnyEventRemovedListener> Value;
}

public static class MyAppMainAnyEventRemovedListenerEventEntityExtension
{
    public static Entity AddAnyEventRemovedListener(this Entity entity, IMyAppMainAnyEventRemovedListener value)
    {
        var listeners = entity.HasAnyEventRemovedListener()
            ? entity.GetAnyEventRemovedListener().Value
            : new global::System.Collections.Generic.List<IMyAppMainAnyEventRemovedListener>();
        listeners.Add(value);
        return entity.ReplaceAnyEventRemovedListener(listeners);
    }

    public static void RemoveAnyEventRemovedListener(this Entity entity, IMyAppMainAnyEventRemovedListener value, bool removeListenerWhenEmpty = true)
    {
        var listeners = entity.GetAnyEventRemovedListener().Value;
        listeners.Remove(value);
        if (removeListenerWhenEmpty && listeners.Count == 0)
        {
            entity.RemoveAnyEventRemovedListener();
            if (entity.IsEmpty())
                entity.Destroy();
        }
        else
        {
            entity.ReplaceAnyEventRemovedListener(listeners);
        }
    }
}

public sealed class MyAppMainAnyEventRemovedEventSystem : global::Entitas.ReactiveSystem<Entity>
{
    readonly global::Entitas.IGroup<Entity> _listeners;
    readonly global::System.Collections.Generic.List<Entity> _entityBuffer;
    readonly global::System.Collections.Generic.List<IMyAppMainAnyEventRemovedListener> _listenerBuffer;

    public MyAppMainAnyEventRemovedEventSystem(MyApp.MainContext context) : base(context)
    {
        _listeners = context.GetGroup(MyAppMainAnyEventRemovedListenerMatcher.AnyEventRemovedListener);
        _entityBuffer = new global::System.Collections.Generic.List<Entity>();
        _listenerBuffer = new global::System.Collections.Generic.List<IMyAppMainAnyEventRemovedListener>();
    }

    protected override global::Entitas.ICollector<Entity> GetTrigger(global::Entitas.IContext<Entity> context)
    {
        return global::Entitas.CollectorContextExtension.CreateCollector(
            context, global::Entitas.TriggerOnEventMatcherExtension.Added(MyAppMainEventMatcher.Event)
        );
    }

    protected override bool Filter(Entity entity)
    {
        return !entity.HasEvent();
    }

    protected override void Execute(global::System.Collections.Generic.List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var listenerEntity in _listeners.GetEntities(_entityBuffer))
            {
                _listenerBuffer.Clear();
                _listenerBuffer.AddRange(listenerEntity.GetAnyEventRemovedListener().Value);
                foreach (var listener in _listenerBuffer)
                {
                    listener.OnAnyEventRemoved(entity);
                }
            }
        }
    }
}
