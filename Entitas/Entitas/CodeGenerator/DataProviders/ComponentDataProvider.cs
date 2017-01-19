﻿using System;
using System.Collections.Generic;
using System.Linq;
using Entitas.Serialization;

namespace Entitas.CodeGenerator {

    public static class ComponentCodeGeneratorDataExtensions {

        public static string GetType(this CodeGeneratorData data) {
            return (string)data[ComponentDataProvider.TYPE];
        }

        public static string GetFullTypeName(this CodeGeneratorData data) {
            return (string)data[ComponentDataProvider.FULL_TYPE_NAME];
        }

        public static string GetTypeName(this CodeGeneratorData data) {
            var fullTypeName = GetFullTypeName(data);
            var nameSplit = fullTypeName.Split('.');
            return nameSplit[nameSplit.Length - 1];
        }

        public static List<PublicMemberInfo> GetMemberInfos(this CodeGeneratorData data) {
            return (List<PublicMemberInfo>)data[ComponentDataProvider.MEMBER_INFOS];
        }

        public static string[] GetContexts(this CodeGeneratorData data) {
            return (string[])data[ComponentDataProvider.CONTEXTS];
        }

        public static bool IsUnique(this CodeGeneratorData data) {
            return (bool)data[ComponentDataProvider.IS_UNIQUE];
        }

        public static string GetUniqueComponentPrefix(this CodeGeneratorData data) {
            return (string)data[ComponentDataProvider.UNIQUE_COMPONENT_PREFIX];
        }

        public static bool IsComponent(this CodeGeneratorData data) {
            return (bool)data[ComponentDataProvider.IS_COMPONENT];
        }

        public static bool ShouldGenerateMethods(this CodeGeneratorData data) {
            return (bool)data[ComponentDataProvider.GENERATE_METHODS];
        }

        public static bool ShouldGenerateIndex(this CodeGeneratorData data) {
            return (bool)data[ComponentDataProvider.GENERATE_INDEX];
        }

        public static bool ShouldHideInBlueprintInspector(this CodeGeneratorData data) {
            return (bool)data[ComponentDataProvider.HIDE_IN_BLUEPRINT_INSPECTOR];
        }
    }

    public class ComponentDataProvider : ICodeGeneratorDataProvider {

        public const string TYPE = "type";
        public const string FULL_TYPE_NAME = "fullTypeName";
        public const string MEMBER_INFOS = "memberInfos";
        public const string CONTEXTS = "contexts";
        public const string IS_UNIQUE = "isUnique";
        public const string UNIQUE_COMPONENT_PREFIX = "uniqueComponentPrefix";
        public const string IS_COMPONENT = "isComponent";
        public const string GENERATE_METHODS = "generateMethods";
        public const string GENERATE_INDEX = "generateIndex";
        public const string HIDE_IN_BLUEPRINT_INSPECTOR = "hideInBlueprintInspector";

        readonly Type[] _types;

        public ComponentDataProvider(Type[] types) {
            _types = types;
        }

        public CodeGeneratorData[] GetData() {
            var dataFromComponents = _types
                .Where(type => !type.IsInterface)
                .Where(type => !type.IsAbstract)
                .Where(type => type.GetInterfaces().Any(i => i.FullName == "Entitas.IComponent"))
                .Select(type => createDataForComponent(type));

            var dataFromNonComponents = _types
                .Where(type => !type.IsGenericType)
                .Where(type => !type.GetInterfaces().Any(i => i.FullName == "Entitas.IComponent"))
                .Where(type => getContexts(type).Length > 0)
                .SelectMany(type => createDataForNonComponent(type));

            var generatedComponentsLookup = dataFromNonComponents.ToLookup(data => data[FULL_TYPE_NAME]);

            return dataFromComponents
                .Where(data => !generatedComponentsLookup.Contains(data[FULL_TYPE_NAME]))
                .Concat(dataFromNonComponents)
                .ToArray();
        }

        CodeGeneratorData createDataForComponent(Type type) {
            var data = new CodeGeneratorData(GetType().FullName);

            data[TYPE] = type;
            data[FULL_TYPE_NAME] = type.ToCompilableString();
            data[MEMBER_INFOS] = type.GetPublicMemberInfos();

            data[CONTEXTS] = getContexts(type);
            data[IS_UNIQUE] = getIsSingleEntity(type);
            data[UNIQUE_COMPONENT_PREFIX] = getUniqueComponentPrefix(type);

            data[IS_COMPONENT] = false;

            data[GENERATE_METHODS] = getGenerateMethods(type);
            data[GENERATE_INDEX] = getGenerateIndex(type);
            data[HIDE_IN_BLUEPRINT_INSPECTOR] = getHideInBlueprintInspector(type);

            return data;
        }

        CodeGeneratorData[] createDataForNonComponent(Type type) {
            return getComponentNames(type).Select(componentName => {
                var data = new CodeGeneratorData(GetType().FullName);

                data[TYPE] = type;
                data[FULL_TYPE_NAME] = componentName;
                data[MEMBER_INFOS] = new List<PublicMemberInfo> { new PublicMemberInfo(type, "value") };

                data[CONTEXTS] = getContexts(type);
                data[IS_UNIQUE] = getIsSingleEntity(type);
                data[UNIQUE_COMPONENT_PREFIX] = getUniqueComponentPrefix(type);

                data[IS_COMPONENT] = true;

                data[GENERATE_METHODS] = getGenerateMethods(type);
                data[GENERATE_INDEX] = getGenerateIndex(type);
                data[HIDE_IN_BLUEPRINT_INSPECTOR] = getHideInBlueprintInspector(type);

                return data;
            }).ToArray();
        }

        string[] getContexts(Type type) {
            return Attribute.GetCustomAttributes(type)
                            .Where(attr => isTypeOrHasBaseType(attr.GetType(), "Entitas.CodeGenerator.ContextAttribute"))
                            .Select(attr => attr.GetType().GetField("contextName").GetValue(attr) as string)
                            .OrderBy(contextName => contextName)
                            .ToArray();
        }

        bool getIsSingleEntity(Type type) {
            return Attribute.GetCustomAttributes(type)
                            .Any(attr => attr.GetType().FullName == "Entitas.CodeGenerator.SingleEntityAttribute");
        }

        string getUniqueComponentPrefix(Type type) {
            var attr = Attribute.GetCustomAttributes(type)
                                .SingleOrDefault(a => isTypeOrHasBaseType(a.GetType(), "Entitas.CodeGenerator.CustomPrefixAttribute"));

            return attr == null ? "is" : (string)attr.GetType().GetField("prefix").GetValue(attr);
        }

        bool getGenerateMethods(Type type) {
            return Attribute.GetCustomAttributes(type)
                            .All(attr => attr.GetType().FullName != "Entitas.CodeGenerator.DontGenerateAttribute");
        }

        bool getGenerateIndex(Type type) {
            var attr = Attribute.GetCustomAttributes(type)
                                .SingleOrDefault(a => isTypeOrHasBaseType(a.GetType(), "Entitas.CodeGenerator.DontGenerateAttribute"));

            return attr == null || (bool)attr.GetType().GetField("generateIndex").GetValue(attr);
        }

        bool getHideInBlueprintInspector(Type type) {
            var attr = Attribute.GetCustomAttributes(type)
                                .SingleOrDefault(a => isTypeOrHasBaseType(a.GetType(), "Entitas.Serialization.Blueprints.HideInBlueprintInspectorAttribute"));

            return attr != null;
        }

        string[] getComponentNames(Type type) {
            var attr = Attribute.GetCustomAttributes(type)
                                .SingleOrDefault(a => isTypeOrHasBaseType(a.GetType(), "Entitas.CodeGenerator.CustomComponentNameAttribute"));

            if(attr == null) {
                var nameSplit = type.ToCompilableString().Split('.');
                var componentName = nameSplit[nameSplit.Length - 1].AddComponentSuffix();
                return new[] { componentName };
            }

            return (string[])attr.GetType().GetField("componentNames").GetValue(attr);
        }

        bool hasBaseType(Type type, string fullTypeName) {
            if(type.FullName == fullTypeName) {
                return false;
            }

            return isTypeOrHasBaseType(type, fullTypeName);
        }

        bool isTypeOrHasBaseType(Type type, string fullTypeName) {
            var t = type;
            while(t != null) {
                if(t.FullName == fullTypeName) {
                    return true;
                }
                t = t.BaseType;
            }

            return false;
        }
    }
}
