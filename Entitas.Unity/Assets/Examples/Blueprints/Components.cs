﻿using Entitas;

[Blueprints]
public class NameComponent : IComponent {
    public string value;
}

[Blueprints]
public class AgeComponent : IComponent {
    public int value;
}

[Blueprints]
public class AAAComponent : IComponent {
    public int[] value;
}

