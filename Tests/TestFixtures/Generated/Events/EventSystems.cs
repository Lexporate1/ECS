//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class EventSystems : Feature {

    public EventSystems(Contexts contexts) {
        Add(new FlagEventEventSystem(contexts)); // priority: 0
        Add(new TestMultipleContextStandardEventEventSystem(contexts)); // priority: 0
        Add(new Test2MultipleContextStandardEventEventSystem(contexts)); // priority: 0
        Add(new StandardEventEventSystem(contexts)); // priority: 0
        Add(new FlagEntityEventEventSystem(contexts)); // priority: 1
        Add(new StandardEntityEventEventSystem(contexts)); // priority: 1
    }
}
