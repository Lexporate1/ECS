//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class Test2EventSystems : Feature {

    public Test2EventSystems(Contexts contexts) {
        Add(new TestMultipleContextStandardEventEventSystem(contexts)); // priority: 0
        Add(new Test2MultipleContextStandardEventEventSystem(contexts)); // priority: 0
        Add(new TestMultipleEventsStandardEventEventSystem(contexts)); // priority: 1
        Add(new Test2MultipleEventsStandardEventEventSystem(contexts)); // priority: 1
        Add(new TestMultipleEventsStandardEventRemovedEventSystem(contexts)); // priority: 2
        Add(new Test2MultipleEventsStandardEventRemovedEventSystem(contexts)); // priority: 2
    }
}
