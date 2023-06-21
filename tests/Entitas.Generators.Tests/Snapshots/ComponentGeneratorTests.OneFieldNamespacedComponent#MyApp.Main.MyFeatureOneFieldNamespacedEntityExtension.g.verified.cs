﻿//HintName: MyApp.Main.MyFeatureOneFieldNamespacedEntityExtension.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ComponentGenerator.EntityExtension
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace MyApp.Main
{
public static class MyFeatureOneFieldNamespacedEntityExtension
{
    public static MyFeature.OneFieldNamespacedComponent GetOneFieldNamespaced(this Entity entity)
    {
        return (MyFeature.OneFieldNamespacedComponent)entity.GetComponent(MyFeatureOneFieldNamespacedComponentIndex.Value);
    }

    public static void Deconstruct(this MyFeature.OneFieldNamespacedComponent component, out string value)
    {
        value = component.Value;
    }

    public static bool HasOneFieldNamespaced(this Entity entity)
    {
        return entity.HasComponent(MyFeatureOneFieldNamespacedComponentIndex.Value);
    }

    public static Entity AddOneFieldNamespaced(this Entity entity, string value)
    {
        var index = MyFeatureOneFieldNamespacedComponentIndex.Value;
        var component = (MyFeature.OneFieldNamespacedComponent)entity.CreateComponent(index, typeof(MyFeature.OneFieldNamespacedComponent));
        component.Value = value;
        entity.AddComponent(index, component);
        return entity;
    }

    public static Entity ReplaceOneFieldNamespaced(this Entity entity, string value)
    {
        var index = MyFeatureOneFieldNamespacedComponentIndex.Value;
        var component = (MyFeature.OneFieldNamespacedComponent)entity.CreateComponent(index, typeof(MyFeature.OneFieldNamespacedComponent));
        component.Value = value;
        entity.ReplaceComponent(index, component);
        return entity;
    }

    public static Entity RemoveOneFieldNamespaced(this Entity entity)
    {
        entity.RemoveComponent(MyFeatureOneFieldNamespacedComponentIndex.Value);
        return entity;
    }
}
}
