//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if (_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public GameContext game { get; set; }
    public Test1Context test1 { get; set; }
    public Test2Context test2 { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { game, test1, test2 }; } }

    public Contexts() {
        game = new GameContext();
        test1 = new Test1Context();
        test2 = new Test2Context();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string MultiplePrimaryEntityIndicesValue = "MultiplePrimaryEntityIndicesValue";
    public const string MultiplePrimaryEntityIndicesValue2 = "MultiplePrimaryEntityIndicesValue2";
    public const string MyNamespaceCustomEntityIndex = "MyNamespaceCustomEntityIndex";
    public const string MyNamespaceEntityIndex = "MyNamespaceEntityIndex";
    public const string MyNamespaceEntityIndexNoContext = "MyNamespaceEntityIndexNoContext";
    public const string MyNamespaceMultipleEntityIndicesValue = "MyNamespaceMultipleEntityIndicesValue";
    public const string MyNamespaceMultipleEntityIndicesValue2 = "MyNamespaceMultipleEntityIndicesValue2";
    public const string PrimaryEntityIndex = "PrimaryEntityIndex";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, string>(
            MultiplePrimaryEntityIndicesValue,
            game.GetGroup(GameMatcher.MultiplePrimaryEntityIndices),
            (e, c) => ((MultiplePrimaryEntityIndicesComponent)c).value));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, string>(
            MultiplePrimaryEntityIndicesValue2,
            game.GetGroup(GameMatcher.MultiplePrimaryEntityIndices),
            (e, c) => ((MultiplePrimaryEntityIndicesComponent)c).value2));

        test1.AddEntityIndex(new MyNamespace.CustomEntityIndex(test1));

        test1.AddEntityIndex(new Entitas.EntityIndex<Test1Entity, string>(
            MyNamespaceEntityIndex,
            test1.GetGroup(Test1Matcher.MyNamespaceEntityIndex),
            (e, c) => ((My.Namespace.EntityIndexComponent)c).value));
        test2.AddEntityIndex(new Entitas.EntityIndex<Test2Entity, string>(
            MyNamespaceEntityIndex,
            test2.GetGroup(Test2Matcher.MyNamespaceEntityIndex),
            (e, c) => ((My.Namespace.EntityIndexComponent)c).value));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, string>(
            MyNamespaceEntityIndexNoContext,
            game.GetGroup(GameMatcher.MyNamespaceEntityIndexNoContext),
            (e, c) => ((My.Namespace.EntityIndexNoContextComponent)c).value));

        test1.AddEntityIndex(new Entitas.EntityIndex<Test1Entity, string>(
            MyNamespaceMultipleEntityIndicesValue,
            test1.GetGroup(Test1Matcher.MyNamespaceMultipleEntityIndices),
            (e, c) => ((My.Namespace.MultipleEntityIndicesComponent)c).value));
        test2.AddEntityIndex(new Entitas.EntityIndex<Test2Entity, string>(
            MyNamespaceMultipleEntityIndicesValue,
            test2.GetGroup(Test2Matcher.MyNamespaceMultipleEntityIndices),
            (e, c) => ((My.Namespace.MultipleEntityIndicesComponent)c).value));

        test1.AddEntityIndex(new Entitas.EntityIndex<Test1Entity, string>(
            MyNamespaceMultipleEntityIndicesValue2,
            test1.GetGroup(Test1Matcher.MyNamespaceMultipleEntityIndices),
            (e, c) => ((My.Namespace.MultipleEntityIndicesComponent)c).value2));
        test2.AddEntityIndex(new Entitas.EntityIndex<Test2Entity, string>(
            MyNamespaceMultipleEntityIndicesValue2,
            test2.GetGroup(Test2Matcher.MyNamespaceMultipleEntityIndices),
            (e, c) => ((My.Namespace.MultipleEntityIndicesComponent)c).value2));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, string>(
            PrimaryEntityIndex,
            game.GetGroup(GameMatcher.PrimaryEntityIndex),
            (e, c) => ((PrimaryEntityIndexComponent)c).value));
    }
}

public static class ContextsExtensions {

    public static GameEntity GetEntityWithMultiplePrimaryEntityIndicesValue(this GameContext context, string value) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.MultiplePrimaryEntityIndicesValue)).GetEntity(value);
    }

    public static GameEntity GetEntityWithMultiplePrimaryEntityIndicesValue2(this GameContext context, string value2) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.MultiplePrimaryEntityIndicesValue2)).GetEntity(value2);
    }

    public static System.Collections.Generic.HashSet<Test1Entity> GetEntitiesWithPosition(this Test1Context context, IntVector2 position) {
        return ((MyNamespace.CustomEntityIndex)(context.GetEntityIndex(Contexts.MyNamespaceCustomEntityIndex))).GetEntitiesWithPosition(position);
    }

    public static System.Collections.Generic.HashSet<Test1Entity> GetEntitiesWithPosition2(this Test1Context context, IntVector2 position, IntVector2 size) {
        return ((MyNamespace.CustomEntityIndex)(context.GetEntityIndex(Contexts.MyNamespaceCustomEntityIndex))).GetEntitiesWithPosition2(position, size);
    }


    public static System.Collections.Generic.HashSet<Test1Entity> GetEntitiesWithMyNamespaceEntityIndex(this Test1Context context, string value) {
        return ((Entitas.EntityIndex<Test1Entity, string>)context.GetEntityIndex(Contexts.MyNamespaceEntityIndex)).GetEntities(value);
    }

    public static System.Collections.Generic.HashSet<Test2Entity> GetEntitiesWithMyNamespaceEntityIndex(this Test2Context context, string value) {
        return ((Entitas.EntityIndex<Test2Entity, string>)context.GetEntityIndex(Contexts.MyNamespaceEntityIndex)).GetEntities(value);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithMyNamespaceEntityIndexNoContext(this GameContext context, string value) {
        return ((Entitas.EntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.MyNamespaceEntityIndexNoContext)).GetEntities(value);
    }

    public static System.Collections.Generic.HashSet<Test1Entity> GetEntitiesWithMyNamespaceMultipleEntityIndicesValue(this Test1Context context, string value) {
        return ((Entitas.EntityIndex<Test1Entity, string>)context.GetEntityIndex(Contexts.MyNamespaceMultipleEntityIndicesValue)).GetEntities(value);
    }

    public static System.Collections.Generic.HashSet<Test2Entity> GetEntitiesWithMyNamespaceMultipleEntityIndicesValue(this Test2Context context, string value) {
        return ((Entitas.EntityIndex<Test2Entity, string>)context.GetEntityIndex(Contexts.MyNamespaceMultipleEntityIndicesValue)).GetEntities(value);
    }

    public static System.Collections.Generic.HashSet<Test1Entity> GetEntitiesWithMyNamespaceMultipleEntityIndicesValue2(this Test1Context context, string value2) {
        return ((Entitas.EntityIndex<Test1Entity, string>)context.GetEntityIndex(Contexts.MyNamespaceMultipleEntityIndicesValue2)).GetEntities(value2);
    }

    public static System.Collections.Generic.HashSet<Test2Entity> GetEntitiesWithMyNamespaceMultipleEntityIndicesValue2(this Test2Context context, string value2) {
        return ((Entitas.EntityIndex<Test2Entity, string>)context.GetEntityIndex(Contexts.MyNamespaceMultipleEntityIndicesValue2)).GetEntities(value2);
    }

    public static GameEntity GetEntityWithPrimaryEntityIndex(this GameContext context, string value) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.PrimaryEntityIndex)).GetEntity(value);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeContextObservers() {
        try {
            CreateContextObserver(game);
            CreateContextObserver(test1);
            CreateContextObserver(test2);
        } catch(System.Exception e) {
            UnityEngine.Debug.LogError(e);
        }
    }

    public void CreateContextObserver(Entitas.IContext context) {
        if (UnityEngine.Application.isPlaying) {
            var observer = new Entitas.VisualDebugging.Unity.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
    }

#endif
}