using System;
using System.Collections.Generic;
using System.Linq;
using Entitas.Utils;
using Fabl;

namespace Entitas.CodeGeneration.CodeGenerator.CLI {

    public class Status : AbstractCommand {

        public override string trigger { get { return "status"; } }
        public override string description { get { return "List available and unavailable plugins"; } }
        public override string example { get { return "entitas status"; } }

        protected override void run() {
            var config = new CodeGeneratorConfig();
            config.Configure(_preferences);

            var cliConfig = new CLIConfig();
            cliConfig.Configure(_preferences);

            fabl.Debug(_preferences.ToString());

            Type[] types = null;
            Dictionary<string, string> defaultProperties = null;

            try {
                types = CodeGeneratorUtil.LoadTypesFromPlugins(_preferences);
                defaultProperties = CodeGeneratorUtil.GetDefaultProperties(types, config);

            } catch(Exception ex) {
                printKeyStatus(config.defaultProperties.Keys.ToArray(), cliConfig, _preferences);
                throw ex;
            }

            var requiredKeys = config.defaultProperties
                .Merge(cliConfig.defaultProperties)
                .Merge(defaultProperties).Keys.ToArray();

            printKeyStatus(requiredKeys, cliConfig, _preferences);
            printPluginStatus(types, config);
            printCollisions(config);
        }

        static void printKeyStatus(string[] requiredKeys, CLIConfig cliConfig, Preferences preferences) {
            var unusedKeys = Helper
                .GetUnusedKeys(requiredKeys, preferences)
                .Where(key => !cliConfig.ignoreUnusedKeys.Contains(key));

            foreach (var key in unusedKeys) {
                fabl.Info("Unused key: " + key);
            }

            foreach (var key in Helper.GetMissingKeys(requiredKeys, preferences)) {
                fabl.Warn("Missing key: " + key);
            }
        }

        static void printPluginStatus(Type[] types, CodeGeneratorConfig config) {
            var unavailableDataProviders = CodeGeneratorUtil.GetUnavailableNamesOf<ICodeGeneratorDataProvider>(types, config.dataProviders);
            var unavailableCodeGenerators = CodeGeneratorUtil.GetUnavailableNamesOf<ICodeGenerator>(types, config.codeGenerators);
            var unavailablePostProcessors = CodeGeneratorUtil.GetUnavailableNamesOf<ICodeGenFilePostProcessor>(types, config.postProcessors);

            var availableDataProviders = CodeGeneratorUtil.GetAvailableNamesOf<ICodeGeneratorDataProvider>(types, config.dataProviders);
            var availableCodeGenerators = CodeGeneratorUtil.GetAvailableNamesOf<ICodeGenerator>(types, config.codeGenerators);
            var availablePostProcessors = CodeGeneratorUtil.GetAvailableNamesOf<ICodeGenFilePostProcessor>(types, config.postProcessors);

            printUnavailable(unavailableDataProviders);
            printUnavailable(unavailableCodeGenerators);
            printUnavailable(unavailablePostProcessors);

            printAvailable(availableDataProviders);
            printAvailable(availableCodeGenerators);
            printAvailable(availablePostProcessors);
        }

        static void printUnavailable(string[] names) {
            foreach (var name in names) {
                fabl.Warn("Unavailable: " + name);
            }
        }

        static void printAvailable(string[] names) {
            foreach (var name in names) {
                fabl.Info("Available: " + name);
            }
        }

        static void printCollisions(CodeGeneratorConfig config) {
            printDuplicates(config.dataProviders);
            printDuplicates(config.codeGenerators);
            printDuplicates(config.postProcessors);
        }

        static void printDuplicates(string[] names) {
            var shortNames = names
                .Select(name => name.ShortTypeName())
                .ToArray();

            var duplicates = names
                .Where(name => shortNames.Count(n => n == name.ShortTypeName()) > 1)
                .OrderBy(name => name.ShortTypeName());

            foreach (var duplicate in duplicates) {
                fabl.Warn("Potential collision detected: " + duplicate.ShortTypeName() + " -> " + duplicate);
            }
        }
    }
}
