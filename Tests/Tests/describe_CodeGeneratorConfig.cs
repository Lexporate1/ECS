﻿using Entitas.CodeGenerator;
using NSpec;

class describe_CodeGeneratorConfig : nspec {

    void when_creating_config() {

        it["creates config from string"] = () => {
            const string configString =
                "Entitas.CodeGenerator.GeneratedFolderPath = path/to/folder/\n" +
                "Entitas.CodeGenerator.Pools = Core, Meta, UI\n";

            var config = new CodeGeneratorConfig(configString);

            config.generatedFolderPath.should_be("path/to/folder/");
            config.pools.should_be(new [] { "Core", "Meta", "UI" });
        };

        it["gets default values when keys dont exist"] = () => {
            var config = new CodeGeneratorConfig(string.Empty);
            config.generatedFolderPath.should_be("Assets/Generated/");
            config.pools.should_be_empty();
        };

        it["sets values"] = () => {
            const string configString = "Entitas.CodeGenerator.GeneratedFolderPath = path/to/folder/\n" +
                                        "Entitas.CodeGenerator.Pools = Core, Meta ,UI";

            var config = new CodeGeneratorConfig(configString);
            config.generatedFolderPath = "new/path/";
            config.pools = new [] { "Other1", "Other2" };

            config.generatedFolderPath.should_be("new/path/");
            config.pools.should_be(new [] { "Other1", "Other2" });
        };

        it["gets string"] = () => {
            const string configString = "Entitas.CodeGenerator.GeneratedFolderPath = path/to/folder/\n" +
                                        "Entitas.CodeGenerator.Pools = Core, Meta ,UI";

            var config = new CodeGeneratorConfig(configString);
            config.generatedFolderPath = "new/path/";
            config.pools = new [] { "Other1", "Other2" };

            config.ToString().should_be(
                "Entitas.CodeGenerator.GeneratedFolderPath = new/path/\n" +
                "Entitas.CodeGenerator.Pools = Other1,Other2\n");
        };

        it["gets string from empty config"] = () => {
            var config = new CodeGeneratorConfig(string.Empty);
            config.ToString().should_be(
                "Entitas.CodeGenerator.GeneratedFolderPath = Assets/Generated/\n" +
                "Entitas.CodeGenerator.Pools = \n");
        };

        it["removes empty pools"] = () => {
            const string configString = "Entitas.CodeGenerator.Pools = ,,Core,,UI,,";
            var config = new CodeGeneratorConfig(configString);
            config.pools.should_be(new [] { "Core", "UI" });
        };

        it["removes trailing comma in pools string"] = () => {
            var config = new CodeGeneratorConfig(string.Empty);
            config.pools = new [] {"Meta", string.Empty};
            config.ToString().should_be(
                "Entitas.CodeGenerator.GeneratedFolderPath = Assets/Generated/\n" +
                "Entitas.CodeGenerator.Pools = Meta\n"
            );
        };
    }
}

