//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Test2Context {

    public Test2Entity uniqueClassToGenerateEntity { get { return GetGroup(Test2Matcher.UniqueClassToGenerate).GetSingleEntity(); } }
    public UniqueClassToGenerateComponent uniqueClassToGenerate { get { return uniqueClassToGenerateEntity.uniqueClassToGenerate; } }
    public bool hasUniqueClassToGenerate { get { return uniqueClassToGenerateEntity != null; } }

    public Test2Entity SetUniqueClassToGenerate(My.Namespace.UniqueClassToGenerate newValue) {
        if (hasUniqueClassToGenerate) {
            throw new Entitas.EntitasException("Could not set UniqueClassToGenerate!\n" + this + " already has an entity with UniqueClassToGenerateComponent!",
                "You should check if the context already has a uniqueClassToGenerateEntity before setting it or use context.ReplaceUniqueClassToGenerate().");
        }
        var entity = CreateEntity();
        entity.AddUniqueClassToGenerate(newValue);
        return entity;
    }

    public void ReplaceUniqueClassToGenerate(My.Namespace.UniqueClassToGenerate newValue) {
        var entity = uniqueClassToGenerateEntity;
        if (entity == null) {
            entity = SetUniqueClassToGenerate(newValue);
        } else {
            entity.ReplaceUniqueClassToGenerate(newValue);
        }
    }

    public void RemoveUniqueClassToGenerate() {
        uniqueClassToGenerateEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Test2Entity {

    public UniqueClassToGenerateComponent uniqueClassToGenerate { get { return (UniqueClassToGenerateComponent)GetComponent(Test2ComponentLookup.UniqueClassToGenerate); } }
    public bool hasUniqueClassToGenerate { get { return HasComponent(Test2ComponentLookup.UniqueClassToGenerate); } }

    public void AddUniqueClassToGenerate(My.Namespace.UniqueClassToGenerate newValue) {
        var index = Test2ComponentLookup.UniqueClassToGenerate;
        var component = CreateComponent<UniqueClassToGenerateComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUniqueClassToGenerate(My.Namespace.UniqueClassToGenerate newValue) {
        var index = Test2ComponentLookup.UniqueClassToGenerate;
        var component = CreateComponent<UniqueClassToGenerateComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUniqueClassToGenerate() {
        RemoveComponent(Test2ComponentLookup.UniqueClassToGenerate);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Test2Entity : IUniqueClassToGenerateEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class Test2Matcher {

    static Entitas.IMatcher<Test2Entity> _matcherUniqueClassToGenerate;

    public static Entitas.IMatcher<Test2Entity> UniqueClassToGenerate {
        get {
            if (_matcherUniqueClassToGenerate == null) {
                var matcher = (Entitas.Matcher<Test2Entity>)Entitas.Matcher<Test2Entity>.AllOf(Test2ComponentLookup.UniqueClassToGenerate);
                matcher.componentNames = Test2ComponentLookup.componentNames;
                _matcherUniqueClassToGenerate = matcher;
            }

            return _matcherUniqueClassToGenerate;
        }
    }
}
