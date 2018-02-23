//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEventGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TestEntity {

    public void AddStandardEntityEventListener(IStandardEntityEventListener value) {
        var listeners = hasStandardEntityEventListener
            ? standardEntityEventListener.value
            : new System.Collections.Generic.List<IStandardEntityEventListener>();
        listeners.Add(value);
        ReplaceStandardEntityEventListener(listeners);
    }

    public void RemoveStandardEntityEventListener(IStandardEntityEventListener value) {
        var listeners = standardEntityEventListener.value;
        listeners.Remove(value);
        if (listeners.Count == 0) {
            RemoveStandardEntityEventListener();
        } else {
            ReplaceStandardEntityEventListener(listeners);
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventComponentGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class StandardEntityEventListenerComponent : Entitas.IComponent {
    public System.Collections.Generic.List<IStandardEntityEventListener> value;
}
