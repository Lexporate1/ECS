﻿//HintName: MyAppMainMultipleFieldsMatcher.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ComponentGenerator.Matcher
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using global::MyApp.Main;
using static global::MyAppMainMultipleFieldsComponentIndex;

public sealed class MyAppMainMultipleFieldsMatcher
{
    static global::Entitas.IMatcher<Entity> _matcher;

    public static global::Entitas.IMatcher<Entity> MultipleFields
    {
        get
        {
            if (_matcher == null)
            {
                var matcher = (global::Entitas.Matcher<Entity>)global::Entitas.Matcher<Entity>.AllOf(Index.Value);
                matcher.componentNames = MyApp.MainContext.ComponentNames;
                _matcher = matcher;
            }

            return _matcher;
        }
    }
}
