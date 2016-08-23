//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.PoolsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {

    public partial class Pools {

        public static Pool CreateBlueprintsPool() {
            return CreatePool("Blueprints", BlueprintsComponentIds.TotalComponents, BlueprintsComponentIds.componentNames, BlueprintsComponentIds.componentTypes);
        }

        public static Pool CreateVisualDebuggingPool() {
            return CreatePool("VisualDebugging", VisualDebuggingComponentIds.TotalComponents, VisualDebuggingComponentIds.componentNames, VisualDebuggingComponentIds.componentTypes);
        }

        public Pool[] allPools { get { return new[] { blueprints, visualDebugging }; } }

        public Pool blueprints;
        public Pool visualDebugging;
    }
}
