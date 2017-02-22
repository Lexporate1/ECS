public partial class Test2Entity {

    public NameAgeComponent nameAge { get { return (NameAgeComponent)GetComponent(Test2ComponentsLookup.NameAge); } }
    public bool hasNameAge { get { return HasComponent(Test2ComponentsLookup.NameAge); } }

    public void AddNameAge(string newName, int newAge) {
        var component = CreateComponent<NameAgeComponent>(Test2ComponentsLookup.NameAge);
        component.name = newName;
        component.age = newAge;
        AddComponent(Test2ComponentsLookup.NameAge, component);
    }

    public void ReplaceNameAge(string newName, int newAge) {
        var component = CreateComponent<NameAgeComponent>(Test2ComponentsLookup.NameAge);
        component.name = newName;
        component.age = newAge;
        ReplaceComponent(Test2ComponentsLookup.NameAge, component);
    }

    public void RemoveNameAge() {
        RemoveComponent(Test2ComponentsLookup.NameAge);
    }
}

public sealed partial class Test2Matcher {

    static Entitas.IMatcher<Test2Entity> _matcherNameAge;

    public static Entitas.IMatcher<Test2Entity> NameAge {
        get {
            if(_matcherNameAge == null) {
                var matcher = (Entitas.Matcher<Test2Entity>)Entitas.Matcher<Test2Entity>.AllOf(Test2ComponentsLookup.NameAge);
                matcher.componentNames = Test2ComponentsLookup.componentNames;
                _matcherNameAge = matcher;
            }

            return _matcherNameAge;
        }
    }
}
