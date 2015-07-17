﻿using System;
using System.Reflection;
using Entitas.CodeGenerator;

public class Program {
    public static void Main(string[] args) {
        var assembly = Assembly.GetAssembly(typeof(CodeGenerator));

        var codeGenerators = new ICodeGenerator[] {
            new ComponentExtensionsGenerator(),
            new IndicesLookupGenerator(),
            new PoolAttributeGenerator(),
            new PoolsGenerator(),
            new SystemExtensionsGenerator()
        };

        CodeGenerator.Generate(assembly.GetTypes(), new string[0], "Generated/", codeGenerators);

        Console.WriteLine("Done. Press any key...");
        Console.Read();
    }
}
