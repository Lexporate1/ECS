﻿//HintName: MyFeature.MyAppMainUniqueOneFieldNamespacedContextExtension.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ComponentGenerator.ContextExtension
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace MyFeature
{
public static class MyAppMainUniqueOneFieldNamespacedContextExtension
{
    public static bool HasUniqueOneFieldNamespaced(this global::MyApp.MainContext context)
    {
        return context.GetUniqueOneFieldNamespacedEntity() != null;
    }

    public static global::MyApp.Main.Entity SetUniqueOneFieldNamespaced(this global::MyApp.MainContext context, string value)
    {
        if (context.HasUniqueOneFieldNamespaced())
        {
            throw new global::Entitas.EntitasException(
                $"Could not set UniqueOneFieldNamespaced!\n{context} already has an entity with MyFeature.UniqueOneFieldNamespacedComponent!",
                "You should check if the context already has a UniqueOneFieldNamespacedEntity before setting it or use context.ReplaceUniqueOneFieldNamespaced()."
            );
        }

        return context.CreateEntity().AddUniqueOneFieldNamespaced(value);
    }

    public static global::MyApp.Main.Entity ReplaceUniqueOneFieldNamespaced(this global::MyApp.MainContext context, string value)
    {
        var entity = context.GetUniqueOneFieldNamespacedEntity();
        if (entity == null)
            entity = context.CreateEntity().AddUniqueOneFieldNamespaced(value);
        else
            entity.ReplaceUniqueOneFieldNamespaced(value);

        return entity;
    }

    public static void RemoveUniqueOneFieldNamespaced(this global::MyApp.MainContext context)
    {
        context.GetUniqueOneFieldNamespacedEntity().Destroy();
    }

    public static global::MyApp.Main.Entity GetUniqueOneFieldNamespacedEntity(this global::MyApp.MainContext context)
    {
        return context.GetGroup(MyAppMainUniqueOneFieldNamespacedMatcher.UniqueOneFieldNamespaced).GetSingleEntity();
    }

    public static UniqueOneFieldNamespacedComponent GetUniqueOneFieldNamespaced(this global::MyApp.MainContext context)
    {
        return context.GetUniqueOneFieldNamespacedEntity().GetUniqueOneFieldNamespaced();
    }
}
}
