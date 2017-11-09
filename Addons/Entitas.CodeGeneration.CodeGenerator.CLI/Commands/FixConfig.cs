using System;
using System.Collections.Generic;
using System.Linq;
using Entitas.Utils;

namespace Entitas.CodeGeneration.CodeGenerator.CLI {

    public class FixConfig : AbstractCommand {

        public override string trigger { get { return "fix"; } }
        public override string description { get { return "Add missing or remove unused keys interactively"; } }
        public override string example { get { return "entitas fix"; } }

        public override void Run(string[] args) {
            if (assertPreferences(args)) {
                var preferences = loadPreferences(args);
                var config = new CodeGeneratorConfig();
                config.Configure(preferences);

                var cliConfig = new CLIConfig();
                cliConfig.Configure(preferences);

                forceAddKeys(config.defaultProperties, preferences);
                forceAddKeys(cliConfig.defaultProperties, preferences);

                Type[] types = null;

                try {
                    types = CodeGeneratorUtil.LoadTypesFromPlugins(preferences);
                    getConfigurables(types, config);
                } catch (Exception ex) {
                    throw ex;
                }

                var askedRemoveKeys = new HashSet<string>();
                var askedAddKeys = new HashSet<string>();
                while (fix(askedRemoveKeys, askedAddKeys, types, config, cliConfig, preferences)) { }
            }
        }

        static Dictionary<string, string> getConfigurables(Type[] types, CodeGeneratorConfig config) {
            return CodeGeneratorUtil.GetDefaultProperties(
                CodeGeneratorUtil.GetEnabledInstancesOf<ICodeGeneratorDataProvider>(types, config.dataProviders),
                CodeGeneratorUtil.GetEnabledInstancesOf<ICodeGenerator>(types, config.codeGenerators),
                CodeGeneratorUtil.GetEnabledInstancesOf<ICodeGenFilePostProcessor>(types, config.postProcessors)
            );
        }

        static void forceAddKeys(Dictionary<string, string> requiredProperties, Preferences preferences) {
            var requiredKeys = requiredProperties.Keys.ToArray();
            var missingKeys = Helper.GetMissingKeys(requiredKeys, preferences);

            foreach (var key in missingKeys) {
                Helper.ForceAddKey("Will add missing key", key, requiredProperties[key], preferences);
            }
        }

        static bool fix(HashSet<string> askedRemoveKeys, HashSet<string> askedAddKeys, Type[] types, CodeGeneratorConfig config, CLIConfig cliConfig, Preferences preferences) {
            var changed = fixPlugins(askedRemoveKeys, askedAddKeys, types, config, preferences);

            forceAddKeys(getConfigurables(types, config), preferences);

            var requiredKeys = config.defaultProperties
                .Merge(cliConfig.defaultProperties)
                .Merge(getConfigurables(types, config)).Keys.ToArray();

            removeUnusedKeys(askedRemoveKeys, requiredKeys, cliConfig, preferences);

            return changed;
        }

        static bool fixPlugins(HashSet<string> askedRemoveKeys, HashSet<string> askedAddKeys, Type[] types, CodeGeneratorConfig config, Preferences preferences) {
            var changed = false;

            var unavailableDataProviders = CodeGeneratorUtil.GetUnavailableNamesOf<ICodeGeneratorDataProvider>(types, config.dataProviders);
            var unavailableCodeGenerators = CodeGeneratorUtil.GetUnavailableNamesOf<ICodeGenerator>(types, config.codeGenerators);
            var unavailablePostProcessors = CodeGeneratorUtil.GetUnavailableNamesOf<ICodeGenFilePostProcessor>(types, config.postProcessors);

            var availableDataProviders = CodeGeneratorUtil.GetAvailableNamesOf<ICodeGeneratorDataProvider>(types, config.dataProviders);
            var availableCodeGenerators = CodeGeneratorUtil.GetAvailableNamesOf<ICodeGenerator>(types, config.codeGenerators);
            var availablePostProcessors = CodeGeneratorUtil.GetAvailableNamesOf<ICodeGenFilePostProcessor>(types, config.postProcessors);

            foreach (var key in unavailableDataProviders) {
                if (!askedRemoveKeys.Contains(key)) {
                    Helper.RemoveValue("Remove unavailable data provider", key, config.dataProviders,
                                       values => config.dataProviders = values, preferences);
                    askedRemoveKeys.Add(key);
                    changed = true;
                }
            }

            foreach (var key in unavailableCodeGenerators) {
                if (!askedRemoveKeys.Contains(key)) {
                    Helper.RemoveValue("Remove unavailable code generator", key, config.codeGenerators,
                                       values => config.codeGenerators = values, preferences);
                    askedRemoveKeys.Add(key);
                    changed = true;
                }
            }

            foreach (var key in unavailablePostProcessors) {
                if (!askedRemoveKeys.Contains(key)) {
                    Helper.RemoveValue("Remove unavailable post processor", key, config.postProcessors,
                                       values => config.postProcessors = values, preferences);
                    askedRemoveKeys.Add(key);
                    changed = true;
                }
            }

            foreach (var key in availableDataProviders) {
                if (!askedAddKeys.Contains(key)) {
                    Helper.AddValue("Add available data provider", key, config.dataProviders,
                                    values => config.dataProviders = values, preferences);
                    askedAddKeys.Add(key);
                    changed = true;
                }
            }

            foreach (var key in availableCodeGenerators) {
                if (!askedAddKeys.Contains(key)) {
                    Helper.AddValue("Add available code generator", key, config.codeGenerators,
                                    values => config.codeGenerators = values, preferences);
                    askedAddKeys.Add(key);
                    changed = true;
                }
            }

            foreach (var key in availablePostProcessors) {
                if (!askedAddKeys.Contains(key)) {
                    Helper.AddValue("Add available post processor", key, config.postProcessors,
                                    values => config.postProcessors = values, preferences);
                    askedAddKeys.Add(key);
                    changed = true;
                }
            }

            return changed;
        }

        static void removeUnusedKeys(HashSet<string> askedRemoveKeys, string[] requiredKeys, CLIConfig cliConfig, Preferences preferences) {
            var unusedKeys = Helper
                .GetUnusedKeys(requiredKeys, preferences)
                .Where(key => !cliConfig.ignoreUnusedKeys.Contains(key));

            foreach (var key in unusedKeys) {
                if (!askedRemoveKeys.Contains(key)) {
                    Helper.RemoveOrIgnoreKey("Remove unused key", key, cliConfig, preferences);
                    askedRemoveKeys.Add(key);
                }
            }
        }
    }
}
