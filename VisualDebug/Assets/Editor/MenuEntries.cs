﻿using System.Reflection;
using Entitas;
using Entitas.CodeGenerator;
using UnityEditor;

public static class MenuEntries {

    [MenuItem("Game/Entitas/Generate")]
    public static void EntitasGenerate() {
        var assembly = Assembly.GetAssembly(typeof(Entity));
        EntitasCodeGenerator.Generate(assembly, "Assets/Sources/Generated/");
        AssetDatabase.Refresh();
    }
}
