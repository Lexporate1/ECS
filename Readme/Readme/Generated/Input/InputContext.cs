//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputContext : Entitas.Context<InputEntity> {

    public InputContext()
        : base(
            InputComponentsLookup.TotalComponents,
            0,
            new Entitas.Core.ContextInfo(
                "Input",
                InputComponentsLookup.componentNames,
                InputComponentsLookup.componentTypes
            ), (entity) => new Entitas.SafeAERC(entity)
        ) {
    }
}
