//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.PoolsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public static class Pools {

    static Pool[] _allPools;

    public static Pool[] allPools {
        get {
            if(_allPools == null) {
                _allPools = new[] { pool };
            }

            return _allPools;
        }
    }

    static Pool _pool;

    public static Pool pool {
        get {
            if(_pool == null) {
                _pool = new Pool(ComponentIds.TotalComponents, 0, new PoolMetaData("Pool", ComponentIds.componentNames, ComponentIds.componentTypes));
#if(!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
                var poolObserver = new Entitas.Unity.VisualDebugging.PoolObserver(_pool);
                UnityEngine.Object.DontDestroyOnLoad(poolObserver.gameObject);
#endif
            }

            return _pool;
        }
    }
}