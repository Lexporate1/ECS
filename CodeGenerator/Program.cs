﻿using Entitas.CodeGenerator;

namespace CodeGenerator {
    public class Program {
        public static void Main(string[] args) {
            EntitasCodeGenerator.generatedFolder = "Generated/";
            EntitasCodeGenerator.Generate();
        }
    }
}
