//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas.Api;

public partial class TestContext {

    public TestEntity uniqueStandardEntity { get { return GetGroup(TestMatcher.UniqueStandard).GetSingleEntity(); } }
    public UniqueStandardComponent uniqueStandard { get { return uniqueStandardEntity.uniqueStandard; } }
    public bool hasUniqueStandard { get { return uniqueStandardEntity != null; } }

    public TestEntity SetUniqueStandard(string newValue) {
        if(hasUniqueStandard) {
            throw new EntitasException("Could not set uniqueStandard!\n" + this + " already has an entity with UniqueStandardComponent!",
                "You should check if the context already has a uniqueStandardEntity before setting it or use context.ReplaceUniqueStandard().");
        }
        var entity = CreateEntity();
        entity.AddUniqueStandard(newValue);
        return entity;
    }

    public void ReplaceUniqueStandard(string newValue) {
        var entity = uniqueStandardEntity;
        if(entity == null) {
            entity = SetUniqueStandard(newValue);
        } else {
            entity.ReplaceUniqueStandard(newValue);
        }
    }

    public void RemoveUniqueStandard() {
        DestroyEntity(uniqueStandardEntity);
    }
}
