using Entitas;
using Entitas.CodeGenerator;

public class ComponentWithProperties : IComponent {

    // Has one public property

    [IndexKey("myProperty")]
    public string publicProperty { get; set; }
    public static bool publicStaticProperty { get; set; }
    bool _privateProperty { get; set; }
    static bool _privateStaticProperty { get; set; }

    public string publicPropertyGet { get { return null; } }
    public string publicPropertySet { set { } }
}
