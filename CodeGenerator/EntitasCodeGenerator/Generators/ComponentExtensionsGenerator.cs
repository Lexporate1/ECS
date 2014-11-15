﻿using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Entitas.CodeGenerator {
    public class ComponentExtensionsGenerator {
        public const string classSuffix = "GeneratedExtension";

        public Dictionary<string, string> GenerateComponentExtensions(Type[] components) {
            return components
                .Where(shouldGenerate)
                .ToDictionary(
                type => type + classSuffix,
                generateComponentExtension
            );
        }

        static bool shouldGenerate(Type type) {
            Attribute[] attrs = Attribute.GetCustomAttributes(type);
            foreach (Attribute attr in attrs) {
                if (attr is DontGenerateAttribute) {
                    return false;
                }
            }

            return true;
        }

        static string generateComponentExtension(Type type) {
            var code = addNamespace();
            code += addEntityMethods(type);
            if (isSingleEntity(type)) {
                code += addEntityRepositoryMethods(type);
            }
            code += addMatcher(type);
            code += closeNamespace();
            return code;
        }

        static string addNamespace() {
            return @"namespace Entitas {";
        }

        static string closeNamespace() {
            return "}";
        }

        /*
         *
         * ENTITY METHODS
         *
         */

        static string addEntityMethods(Type type) {
            return addEntityClassHeader()
            + addGetMethods(type)
            + addHasMethods(type)
            + addAddMethods(type)
            + addReplaceMethods(type)
            + addRemoveMethods(type)
            + addCloseClass();
        }

        static string addEntityClassHeader() {
            return "\n    public partial class Entity {";
        }

        static string addGetMethods(Type type) {
            string getMethod = isSingletonComponent(type) ?
            "\n        static readonly $Type $nameComponent = new $Type();\n" :
            "\n        public $Type $name { get { return ($Type)GetComponent($Ids.$Name); } }\n";
            return buildString(type, getMethod);
        }

        static string addHasMethods(Type type) {
            string hasMethod = isSingletonComponent(type) ? @"
        public bool is$Name {
            get { return HasComponent($Ids.$Name); }
            set {
                if (value != is$Name) {
                    if (value) {
                        AddComponent($Ids.$Name, $nameComponent);
                    } else {
                        RemoveComponent($Ids.$Name);
                    }
                }
            }
        }
" : @"
        public bool has$Name { get { return HasComponent($Ids.$Name); } }
";
            return buildString(type, hasMethod);
        }

        static string addAddMethods(Type type) {
            return isSingletonComponent(type) ? string.Empty : buildString(type, @"
        public void Add$Name($Type component) {
            AddComponent($Ids.$Name, component);
        }

        public void Add$Name($typedArgs) {
            var component = new $Type();
$assign
            Add$Name(component);
        }
");
        }

        static string addReplaceMethods(Type type) {
            return isSingletonComponent(type) ? string.Empty : buildString(type, @"
        public void Replace$Name($typedArgs) {
            $Type component;
            if (has$Name) {
                WillRemoveComponent($Ids.$Name);
                component = $name;
            } else {
                component = new $Type();
            }
$assign
            ReplaceComponent($Ids.$Name, component);
        }
");
        }

        static string addRemoveMethods(Type type) {
            return isSingletonComponent(type) ? string.Empty : buildString(type, @"
        public void Remove$Name() {
            RemoveComponent($Ids.$Name);
        }
");
        }

        /*
         *
         * ENTITY REPOSITORY METHODS
         *
         */

        static string addEntityRepositoryMethods(Type type) {
            return addEntityRepositoryClassHeader()
            + addRepoGetMethods(type)
            + addRepoHasMethods(type)
            + addRepoAddMethods(type)
            + addRepoReplaceMethods(type)
            + addRepoRemoveMethods(type)
            + addCloseClass();
        }

        static string addEntityRepositoryClassHeader() {
            return "\n    public partial class EntityRepository {";
        }

        static string addRepoGetMethods(Type type) {
            string getMehod = isSingletonComponent(type) ? @"
        public Entity $nameEntity { get { return GetCollection(Matcher.$Name).GetSingleEntity(); } }
" : @"
        public Entity $nameEntity { get { return GetCollection(Matcher.$Name).GetSingleEntity(); } }

        public $Type $name { get { return $nameEntity.$name; } }
";
            return buildString(type, getMehod);
        }

        static string addRepoHasMethods(Type type) {
            string hasMethod = isSingletonComponent(type) ? @"
        public bool is$Name {
            get { return $nameEntity != null; }
            set {
                var entity = $nameEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().is$Name = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
" : @"
        public bool has$Name { get { return $nameEntity != null; } }
";
            return buildString(type, hasMethod);
        }

        static object addRepoAddMethods(Type type) {
            return isSingletonComponent(type) ? string.Empty : buildString(type, @"
        public Entity Set$Name($Type component) {
            if (has$Name) {
                throw new SingleEntityException(Matcher.$Name);
            }
            var entity = CreateEntity();
            entity.Add$Name(component);
            return entity;
        }

        public Entity Set$Name($typedArgs) {
            if (has$Name) {
                throw new SingleEntityException(Matcher.$Name);
            }
            var entity = CreateEntity();
            entity.Add$Name($args);
            return entity;
        }
");
        }

        static string addRepoReplaceMethods(Type type) {
            return isSingletonComponent(type) ? string.Empty : buildString(type, @"
        public Entity Replace$Name($typedArgs) {
            var entity = $nameEntity;
            if (entity == null) {
                entity = Set$Name($args);
            } else {
                entity.Replace$Name($args);
            }

            return entity;
        }
");
        }

        static string addRepoRemoveMethods(Type type) {
            return isSingletonComponent(type) ? string.Empty : buildString(type, @"
        public void Remove$Name() {
            DestroyEntity($nameEntity);
        }
");
        }

        /*
        *
        * MATCHER
        *
        */

        static string addMatcher(Type type) {
            return buildString(type, @"
    public static partial class Matcher {
        static AllOfEntityMatcher _matcher$Name;

        public static AllOfEntityMatcher $Name {
            get {
                if (_matcher$Name == null) {
                    _matcher$Name = Matcher.AllOf(new [] { $Ids.$Name });
                }

                return _matcher$Name;
            }
        }
    }
");
        }

        /*
         *
         * HELPERS
         *
         */

        static bool isSingleEntity(Type type) {
            Attribute[] attrs = Attribute.GetCustomAttributes(type);
            foreach (Attribute attr in attrs) {
                if (attr is SingleEntityAttribute) {
                    return true;
                }
            }

            return false;
        }

        static bool isSingletonComponent(Type type) {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            return fields.Length == 0;
        }

        static string buildString(Type type, string format) {
            format = createFormatString(format);
            var a0_type = type;
            var a1_name = type.RemoveComponentSuffix();
            var a2_lowercaseName = a1_name.LowercaseFirst();
            var a3_tag = indicesLookupTag(type);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            var a4_fieldNamesWithType = fieldNamesWithType(fields);
            var a5_fieldAssigns = fieldAssignments(fields);
            var a6_fieldNames = fieldNames(fields);

            return string.Format(format, a0_type, a1_name, a2_lowercaseName,
                a3_tag, a4_fieldNamesWithType, a5_fieldAssigns, a6_fieldNames);
        }

        static string createFormatString(string format) {
            return format.Replace("{", "{{")
                .Replace("}", "}}")
                .Replace("$Type", "{0}")
                .Replace("$Name", "{1}")
                .Replace("$name", "{2}")
                .Replace("$Ids", "{3}")
                .Replace("$typedArgs", "{4}")
                .Replace("$assign", "{5}")
                .Replace("$args", "{6}");
        }

        static string indicesLookupTag(Type type) {
            Attribute[] attrs = Attribute.GetCustomAttributes(type);
            foreach (Attribute attr in attrs) {
                var lookup = attr as EntityRepositoryAttribute;
                if (lookup != null) {
                    return lookup.tag;
                }
            }

            return "ComponentIds";
        }

        static string fieldNamesWithType(FieldInfo[] fields) {
            var typedArgs = fields.Select(arg => {
                var newArg = "new" + arg.Name.UppercaseFirst();
                var type = getTypeName(arg.FieldType);
                return type + " " + newArg;
            });

            return string.Join(", ", typedArgs);
        }

        static string fieldAssignments(FieldInfo[] fields) {
            const string format = "            component.{0} = {1};";
            var assignments = fields.Select(arg => {
                var newArg = "new" + arg.Name.UppercaseFirst();
                return string.Format(format, arg.Name, newArg);
            });

            return string.Join("\n", assignments);
        }

        static string fieldNames(FieldInfo[] fields) {
            var args = fields.Select(arg => "new" + arg.Name.UppercaseFirst());
            return string.Join(", ", args);
        }

        static Dictionary<string, string> typeShortcuts = new Dictionary<string, string>() {
            { "Byte", "byte" },
            { "SByte", "sbyte" },
            { "Int32", "int" },
            { "UInt32", "uint" },
            { "Int16", "short" },
            { "UInt16", "ushort" },
            { "Int64", "long" },
            { "UInt64", "ulong" },
            { "Single", "float" },
            { "Double", "double" },
            { "Char", "char" },
            { "Boolean", "bool" },
            { "Object", "object" },
            { "String", "string" },
            { "Decimal", "decimal" }
        };

        static string getTypeName(Type type) {
            string typeStr;
            return typeShortcuts.TryGetValue(type.Name, out typeStr) ?
                typeStr : simpleTypeString(type);
        }

        static string simpleTypeString(Type type) {
            var typeString = type.FullName.Split('`')[0];
            return type.GetGenericArguments().Length == 0 ? typeString :
                typeString + "<" + string.Join(", ", type.GetGenericArguments().Select(getTypeName)) + ">";
        }

        static string addCloseClass() {
            return "    }\n";
        }
    }
}

