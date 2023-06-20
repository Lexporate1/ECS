﻿//HintName: Other.MyAppOneFieldNamespacedEntityExtension.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ComponentGenerator.EntityExtension
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Other
{
public static class MyAppOneFieldNamespacedEntityExtension
{
    public static bool HasOneFieldNamespaced(this Entity entity)
    {
        return entity.HasComponent(MyAppOneFieldNamespacedComponentIndex.Value);
    }

    public static Entity AddOneFieldNamespaced(this Entity entity, string value)
    {
        var index = MyAppOneFieldNamespacedComponentIndex.Value;
        var component = (MyApp.OneFieldNamespacedComponent)entity.CreateComponent(index, typeof(MyApp.OneFieldNamespacedComponent));
        component.Value = value;
        entity.AddComponent(index, component);
        return entity;
    }

    public static Entity ReplaceOneFieldNamespaced(this Entity entity, string value)
    {
        var index = MyAppOneFieldNamespacedComponentIndex.Value;
        var component = (MyApp.OneFieldNamespacedComponent)entity.CreateComponent(index, typeof(MyApp.OneFieldNamespacedComponent));
        component.Value = value;
        entity.ReplaceComponent(index, component);
        return entity;
    }

    public static Entity RemoveOneFieldNamespaced(this Entity entity)
    {
        entity.RemoveComponent(MyAppOneFieldNamespacedComponentIndex.Value);
        return entity;
    }
}
}
