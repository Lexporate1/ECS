﻿using System;
using System.Collections.Generic;

namespace Entitas.CodeGenerator {
    public class IndicesLookupGenerator {
        public Dictionary<string, string> GenerateIndicesLookup(Type[] components) {
            var lookups = new Dictionary<string, string>();
            var lookupsWithTypes = getLookups(components);
            foreach (var lookup in lookupsWithTypes) {
                lookups.Add(lookup.Key, generateIndicesLookup(lookup.Key, lookup.Value.ToArray()));
            }

            return lookups;
        }

        Dictionary<string, List<Type>> getLookups(Type[] components) {
            var lookups = new Dictionary<string, List<Type>>();
            foreach (var type in components) {
                var lookupTag = lookupTagForType(type);
                if (!lookups.ContainsKey(lookupTag)) {
                    lookups.Add(lookupTag, new List<Type>());
                }

                lookups[lookupTag].Add(type);
            }

            return lookups;
        }

        string lookupTagForType(Type type) {
            Attribute[] attrs = Attribute.GetCustomAttributes(type);
            foreach (Attribute attr in attrs) {
                var era = attr as EntityRepositoryAttribute;
                if (era != null) {
                    return era.tag;
                }
            }

            return "ComponentIds";
        }

        string generateIndicesLookup(string tag, Type[] components) {
            var code = addClassHeader(tag);
            code += addIndices(components);
            code += addCloseClass();
            return code;
        }

        string addClassHeader(string className) {
            return string.Format("public static class {0} {{\n", className);;
        }

        string addIndices(Type[] components) {
            const string fieldFormat = "    public const int {0} = {1};\n";
            const string totalFormat = "    public const int TotalComponents = {0};";
            var code = string.Empty;
            for (int i = 0; i < components.Length; i++) {
                code += string.Format(fieldFormat, components[i].RemoveComponentSuffix(), i);
            }

            code += "\n";
            code += string.Format(totalFormat, components.Length);
            return code;        
        }

        string addCloseClass() {
            return "\n}";
        }
    }
}