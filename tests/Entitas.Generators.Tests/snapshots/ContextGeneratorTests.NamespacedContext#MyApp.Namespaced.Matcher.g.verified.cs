﻿//HintName: MyApp.Namespaced.Matcher.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ContextGenerator.Matcher
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace MyApp.Namespaced
{
public static class Matcher
{
    public static global::Entitas.IAllOfMatcher<Entity> AllOf(ComponentIndex[] indices)
    {
        var indexes = global::System.Runtime.CompilerServices.Unsafe.As<ComponentIndex[], int[]>(ref indices);
        return global::Entitas.Matcher<Entity>.AllOf(indexes);
    }

    public static global::Entitas.IAnyOfMatcher<Entity> AnyOf(ComponentIndex[] indices)
    {
        var indexes = global::System.Runtime.CompilerServices.Unsafe.As<ComponentIndex[], int[]>(ref indices);
        return global::Entitas.Matcher<Entity>.AnyOf(indexes);
    }

    public static global::Entitas.IAnyOfMatcher<Entity> AnyOf(this global::Entitas.IAllOfMatcher<Entity> matcher, ComponentIndex[] indices)
    {
        var indexes = global::System.Runtime.CompilerServices.Unsafe.As<ComponentIndex[], int[]>(ref indices);
        return matcher.AnyOf(indexes);
    }

    public static global::Entitas.INoneOfMatcher<Entity> NoneOf(this global::Entitas.IAnyOfMatcher<Entity> matcher, ComponentIndex[] indices)
    {
        var indexes = global::System.Runtime.CompilerServices.Unsafe.As<ComponentIndex[], int[]>(ref indices);
        return matcher.NoneOf(indexes);
    }
}
}
