﻿using System;
using System.Collections.Generic;
using Entitas;

public class CustomObject {
    public string name = "CustomObject";
}

public class CustomObjectComponent : IComponent {
    public CustomObject customObject;
}

public class SystemObjectComponent : IComponent {
    public Object systemObject;
}

public class DateTimeComponent : IComponent {
    public DateTime date;
}

public class ArrayComponent : IComponent {
    public string[] array;
}

public class Array2DComponent : IComponent {
    public int[,] array2d;
}

public class Array3DComponent : IComponent {
    public int[,,] array23;
}

public class JaggedArrayComponent : IComponent {
    public string[][] jaggedArray;
}

public class ListArrayComponent : IComponent {
    public List<string>[] listArray;
}

public class ListComponent : IComponent {
    public List<string> list;
}

