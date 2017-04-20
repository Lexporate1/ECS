using Entitas;

public class ContextGetEntities : IPerformanceTest {

    const int n = 100000;
    IContext<Entity> _context;

    public void Before() {
        _context = Helper.CreateContext();
        for (int i = 0; i < n; i++) {
            _context.CreateEntity();
        }
    }

    public void Run() {
        _context.GetEntities();
    }
}
