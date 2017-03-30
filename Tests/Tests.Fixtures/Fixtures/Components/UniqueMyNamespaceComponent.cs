using Entitas;
using Entitas.CodeGenerator.Attributes;

namespace My.Namespace {

    [Context("Test"), Unique]
    public sealed class UniqueMyNamespaceComponent : IComponent {
        public string value;
    }
}
