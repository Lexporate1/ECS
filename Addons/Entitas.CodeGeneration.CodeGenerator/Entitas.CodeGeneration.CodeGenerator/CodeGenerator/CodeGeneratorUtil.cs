﻿using System;
using System.Collections.Generic;
using System.Linq;
using Entitas.Utils;

namespace Entitas.CodeGeneration.CodeGenerator {

    public static class CodeGeneratorUtil {

        public static DependencyResolver pluginsDependencyResolver {
            get {
                var config = new CodeGeneratorConfig();
                config.Configure(Preferences.LoadProperties());
                var resolver = new DependencyResolver(AppDomain.CurrentDomain, config.searchPaths);
                foreach(var path in config.plugins) {
                    resolver.Load(path);
                }

                return resolver;
            }
        }

        public static CodeGenerator CodeGeneratorFromConfig(string configPath) {
            Preferences.configPath = configPath;
            var config = new CodeGeneratorConfig();
            var properties = Preferences.LoadProperties();
            config.Configure(properties);

            var types = LoadTypesFromPlugins();

            var dataProviders = GetEnabledInstances<ICodeGeneratorDataProvider>(types, config.dataProviders);
            var codeGenerators = GetEnabledInstances<ICodeGenerator>(types, config.codeGenerators);
            var postProcessors = GetEnabledInstances<ICodeGenFilePostProcessor>(types, config.postProcessors);

            configure(dataProviders, properties);
            configure(codeGenerators, properties);
            configure(postProcessors, properties);

            return new CodeGenerator(dataProviders, codeGenerators, postProcessors);
        }

        static void configure(ICodeGeneratorInterface[] plugins, Properties properties) {
            foreach(var plugin in plugins.OfType<IConfigurable>()) {
                plugin.Configure(properties);
            }
        }

        public static Type[] LoadTypesFromPlugins() {
            return pluginsDependencyResolver.GetTypes();
        }

        public static string[] GetOrderedNames(string[] types) {
            return types
                    .OrderBy(type => type)
                    .ToArray();
        }

        public static T[] GetOrderedInstances<T>(Type[] types) where T : ICodeGeneratorInterface {
            return types
                    .Where(type => type.ImplementsInterface<T>())
                    .Where(type => !type.IsAbstract)
                    .Select(type => (T)Activator.CreateInstance(type))
                    .OrderBy(instance => instance.priority)
                    .ThenBy(instance => instance.GetType().ToCompilableString())
                    .ToArray();
        }

        public static string[] GetOrderedTypeNames<T>(Type[] types) where T : ICodeGeneratorInterface {
            return GetOrderedInstances<T>(types)
                    .Select(instance => instance.GetType().ToCompilableString())
                    .ToArray();
        }

        public static T[] GetEnabledInstances<T>(Type[] types, string[] enabledTypeNames) where T : ICodeGeneratorInterface {
            return GetOrderedInstances<T>(types)
                    .Where(instance => enabledTypeNames.Contains(instance.GetType().ToCompilableString()))
                    .ToArray();
        }

        public static string[] GetAvailable<T>(Type[] types, string[] enabledTypeNames) where T : ICodeGeneratorInterface {
            return GetOrderedTypeNames<T>(types)
                    .Where(typeName => !enabledTypeNames.Contains(typeName))
                    .ToArray();
        }

        public static string[] GetUnavailable<T>(Type[] types, string[] enabledTypeNames) where T : ICodeGeneratorInterface {
            var typeNames = GetOrderedTypeNames<T>(types);
            return enabledTypeNames
                    .Where(typeName => !typeNames.Contains(typeName))
                    .ToArray();
        }

        public static T[] GetUsed<T>(Type[] types, string[] enabledTypeNames) where T : ICodeGeneratorInterface {
            return GetOrderedInstances<T>(types)
                .Where(instance => enabledTypeNames.Contains(instance.GetType().ToCompilableString()))
                .ToArray();
        }

        public static KeyValuePair<string, string>[] GetConfigurableKeyValuePairs(ICodeGeneratorDataProvider[] dataProviders, ICodeGenerator[] codeGenerators, ICodeGenFilePostProcessor[] postProcessors) {
            return dataProviders.OfType<IConfigurable>()
                                .Concat(codeGenerators.OfType<IConfigurable>())
                                .Concat(postProcessors.OfType<IConfigurable>())
                                .Select(instance => instance.defaultProperties)
                                .SelectMany(dict => dict.Select(kv => kv))
                                .Distinct()
                                .ToArray();
        }

        public static KeyValuePair<string, string>[] GetMissingConfigurableKeyValuePairs(KeyValuePair<string, string>[] configurableKeyValuePairs, Properties properties) {
            return configurableKeyValuePairs
                .Where(kv => !properties.HasKey(kv.Key))
                .ToArray();
        }
    }
}
