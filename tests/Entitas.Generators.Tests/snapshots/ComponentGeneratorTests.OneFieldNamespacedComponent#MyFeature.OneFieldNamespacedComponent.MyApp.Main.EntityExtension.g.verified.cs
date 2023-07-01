﻿//HintName: MyFeature.OneFieldNamespacedComponent.MyApp.Main.EntityExtension.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ComponentGenerator.EntityExtension
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using global::MyApp.Main;
using static global::MyFeature.MyAppMainOneFieldNamespacedComponentIndex;

namespace MyFeature
{
public static class MyAppMainOneFieldNamespacedEntityExtension
{
    public static bool HasOneFieldNamespaced(this Entity entity)
    {
        return entity.HasComponent(Index.Value);
    }

    public static Entity AddOneFieldNamespaced(this Entity entity, string value)
    {
        var index = Index.Value;
        var component = (OneFieldNamespacedComponent)entity.CreateComponent(index, typeof(OneFieldNamespacedComponent));
        component.Value = value;
        entity.AddComponent(index, component);
        return entity;
    }

    public static Entity ReplaceOneFieldNamespaced(this Entity entity, string value)
    {
        var index = Index.Value;
        var component = (OneFieldNamespacedComponent)entity.CreateComponent(index, typeof(OneFieldNamespacedComponent));
        component.Value = value;
        entity.ReplaceComponent(index, component);
        return entity;
    }

    public static Entity RemoveOneFieldNamespaced(this Entity entity)
    {
        entity.RemoveComponent(Index.Value);
        return entity;
    }

    public static OneFieldNamespacedComponent GetOneFieldNamespaced(this Entity entity)
    {
        return (OneFieldNamespacedComponent)entity.GetComponent(Index.Value);
    }
}
}
