﻿using System;
using System.IO;
using System.Linq;
using Entitas.Migration;
using NSpec;

class describe_M0320 : nspec {

    void when_migrating() {

        var dir = Environment.CurrentDirectory + "/Tests/Tests/Entitas.Migration/Fixtures/M0320";

        IMigration m = null;
        before = () => {
            m = new M0320();
        };

        it["finds all files"] = () => {
            var updatedFiles = m.Migrate(dir);
            updatedFiles.Length.should_be(1);
            updatedFiles.Any(file => file.fileName == Path.Combine(dir, "Entitas.properties")).should_be_true();
        };

        it["updates Entitas.properties"] = () => {
            var updatedFiles = m.Migrate(dir);
            var file = updatedFiles[0];


            file.fileContent.Contains("Entitas.Unity.CodeGenerator.GeneratedFolderPath").should_be_false();
            file.fileContent.Contains("Entitas.CodeGenerator.GeneratedFolderPath").should_be_true();

            file.fileContent.Contains("Entitas.Unity.CodeGenerator.Pools").should_be_false();
            file.fileContent.Contains("Entitas.CodeGenerator.Pools").should_be_true();

            file.fileContent.Contains("Entitas.Unity.CodeGenerator.EnabledCodeGenerators").should_be_false();
            file.fileContent.Contains("Entitas.CodeGenerator.EnabledCodeGenerators").should_be_true();

            // Ignores Entitas.Unity.VisualDebugging
            file.fileContent.Contains("Entitas.Unity.VisualDebugging.DefaultInstanceCreatorFolderPath").should_be_true();
            file.fileContent.Contains("Entitas.Unity.VisualDebugging.TypeDrawerFolderPath").should_be_true();
        };
    }
}

