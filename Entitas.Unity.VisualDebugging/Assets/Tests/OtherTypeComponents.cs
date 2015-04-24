﻿using System;
using System.Collections.Generic;
using Entitas;

public class CustomObject {
    public string name;

    public CustomObject(string name) {
        this.name = name;
    }
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
    public int[,,] array3d;
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

