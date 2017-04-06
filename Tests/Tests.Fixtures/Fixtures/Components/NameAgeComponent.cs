﻿using Entitas.Core;
using Entitas.CodeGeneration.Attributes;

[Context("Test"), Context("Test2")]
public sealed class NameAgeComponent : IComponent {

    public string name;
    public int age;

    public override string ToString() {
        return string.Format("NameAge(" + name + ", " + age + ")");
    }
}
