﻿//HintName: MyFeature.MyAppMainEventNamespacedRemovedListenerComponent.g.cs
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

namespace MyFeature
{
public interface IMyAppMainEventNamespacedRemovedListener
{
    void OnEventNamespacedRemoved(Entity entity);
}

public sealed class MyAppMainEventNamespacedRemovedListenerComponent : global::Entitas.IComponent
{
    public global::System.Collections.Generic.List<IMyAppMainEventNamespacedRemovedListener> Value;
}

public static class MyAppMainEventNamespacedRemovedListenerEventEntityExtension
{
    public static Entity AddEventNamespacedRemovedListener(this Entity entity, IMyAppMainEventNamespacedRemovedListener value)
    {
        var listeners = entity.HasEventNamespacedRemovedListener()
            ? entity.GetEventNamespacedRemovedListener().Value
            : new global::System.Collections.Generic.List<IMyAppMainEventNamespacedRemovedListener>();
        listeners.Add(value);
        return entity.ReplaceEventNamespacedRemovedListener(listeners);
    }

    public static void RemoveEventNamespacedRemovedListener(this Entity entity, IMyAppMainEventNamespacedRemovedListener value, bool removeListenerWhenEmpty = true)
    {
        var listeners = entity.GetEventNamespacedRemovedListener().Value;
        listeners.Remove(value);
        if (removeListenerWhenEmpty && listeners.Count == 0)
        {
            entity.RemoveEventNamespacedRemovedListener();
            if (entity.IsEmpty())
                entity.Destroy();
        }
        else
        {
            entity.ReplaceEventNamespacedRemovedListener(listeners);
        }
    }
}

public sealed class MyAppMainEventNamespacedRemovedEventSystem : global::Entitas.ReactiveSystem<Entity>
{
    readonly global::System.Collections.Generic.List<IMyAppMainEventNamespacedRemovedListener> _listenerBuffer;

    public MyAppMainEventNamespacedRemovedEventSystem(MyApp.MainContext context) : base(context)
    {
        _listenerBuffer = new global::System.Collections.Generic.List<IMyAppMainEventNamespacedRemovedListener>();
    }

    protected override global::Entitas.ICollector<Entity> GetTrigger(global::Entitas.IContext<Entity> context)
    {
        return global::Entitas.CollectorContextExtension.CreateCollector(
            context, global::Entitas.TriggerOnEventMatcherExtension.Added(MyAppMainEventNamespacedMatcher.EventNamespaced)
        );
    }

    protected override bool Filter(Entity entity)
    {
        return !entity.HasEventNamespaced() && entity.HasEventNamespacedRemovedListener();
    }

    protected override void Execute(global::System.Collections.Generic.List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(entity.GetEventNamespacedRemovedListener().Value);
            foreach (var listener in _listenerBuffer)
            {
                listener.OnEventNamespacedRemoved(entity);
            }
        }
    }
}
}
