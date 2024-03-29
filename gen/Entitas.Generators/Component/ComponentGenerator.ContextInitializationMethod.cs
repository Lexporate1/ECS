using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static Entitas.Generators.Templates;

namespace Entitas.Generators
{
    partial class ComponentGenerator
    {
        static void ContextInitializationMethod(SourceProductionContext spc, ContextInitializationMethodDeclaration method, AnalyzerConfigOptionsProvider optionsProvider)
        {
            if (!EntitasAnalyzerConfigOptions.ComponentContextInitializationMethod(optionsProvider, method.SyntaxTree))
                return;

            spc.AddSource(
                GeneratedPath(CombinedNamespace(method.Namespace, $"{method.Class}.{method.Name}.ContextInitialization")),
                GeneratedFileHeader(GeneratorSource(nameof(ContextInitializationMethod))) +
                NamespaceDeclaration(method.Namespace,
                    $$"""
                    public static partial class {{method.Class}}
                    {
                        public static partial void {{method.Name}}()
                        {
                    {{ComponentIndexAssignments(method, method.Components)}}

                            global::{{method.ContextFullName}}.ComponentNames = new string[]
                            {
                    {{ComponentNames(method.Components)}}
                            };

                            global::{{method.ContextFullName}}.ComponentTypes = new global::System.Type[]
                            {
                    {{ComponentTypes(method.Components)}}
                            };
                        }
                    }

                    """));

            static string ComponentIndexAssignments(ContextInitializationMethodDeclaration method, ImmutableArray<ComponentDeclaration> components)
            {
                return string.Join("\n", components.Select((component, i) =>
                {
                    var contextPrefix = "global::" + CombinedNamespace(component.Namespace, ContextAware(method.FullContextPrefix).Replace(".", string.Empty));
                    return $"        {contextPrefix}{component.Prefix}ComponentIndex.Index = new global::{method.FullContextPrefix}.ComponentIndex({i});";
                }));
            }

            static string ComponentNames(ImmutableArray<ComponentDeclaration> components)
            {
                return string.Join(",\n", components.Select(static component => $"            \"{component.FullName.RemoveSuffix("Component")}\""));
            }

            static string ComponentTypes(ImmutableArray<ComponentDeclaration> components)
            {
                return string.Join(",\n", components.Select(static component => $"            typeof(global::{component.FullName})"));
            }
        }
    }
}
