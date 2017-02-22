public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if(_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public static void CreateContextObserver(Entitas.IContext context) {
#if(!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
        if(UnityEngine.Application.isPlaying) {
            var observer = new Entitas.Unity.VisualDebugging.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
#endif
    }

    public GameContext game { get; set; }
    public GameStateContext gameState { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { game, gameState }; } }

    public Contexts() {
        game = new GameContext();
        gameState = new GameStateContext();

        CreateContextObserver(game);
        CreateContextObserver(gameState);
    }
}
