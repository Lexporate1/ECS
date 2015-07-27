﻿using System.Linq;
using System.Text.RegularExpressions;

namespace Entitas.Migration {
    public class M0190 : IMigration {

        public string version { get { return "0.19.0"; } }

        public string description { get { return "Migrates IReactiveSystem.Execute"; } }

        const string executePattern = @"public\s*void\s*Execute\s*\(\s*Entity\s*\[\s*\]\s*entities\s*\)";
        const string executeReplacement = "public void Execute(System.Collections.Generic.List<Entity> entities)";

        public MigrationFile[] Migrate(string path) {
            var files = MigrationUtils.GetSourceFiles(path)
                .Where(file => Regex.IsMatch(file.fileContent, executePattern))
                .ToArray();

            for (int i = 0; i < files.Length; i++) {
                var file = files[i];
                file.fileContent = Regex.Replace(file.fileContent, executePattern, executeReplacement, RegexOptions.Multiline);
                files[i] = file;
            }

            return files;
        }
    }
}

