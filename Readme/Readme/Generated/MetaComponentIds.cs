using Entitas;

public static class MetaComponentIds {
    public const int Coins = 0;

    public const int TotalComponents = 1;

    static readonly string[] _components = {
        "Coins"
    };

    public static string IdToString(int componentId) {
        return _components[componentId];
    }
}