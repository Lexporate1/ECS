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
    public static global::Entitas.IAllOfMatcher<Entity> AllOf(params int[] indexes)
    {
        return global::Entitas.Matcher<Entity>.AllOf(indexes);
    }

    public static global::Entitas.IAllOfMatcher<Entity> AllOf(params global::Entitas.IMatcher<Entity>[] matchers)
    {
        return global::Entitas.Matcher<Entity>.AllOf(matchers);
    }

    public static global::Entitas.IAnyOfMatcher<Entity> AnyOf(params int[] indexes)
    {
        return global::Entitas.Matcher<Entity>.AnyOf(indexes);
    }

    public static global::Entitas.IAnyOfMatcher<Entity> AnyOf(params global::Entitas.IMatcher<Entity>[] matchers)
    {
        return global::Entitas.Matcher<Entity>.AnyOf(matchers);
    }
}
}
