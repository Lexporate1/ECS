﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Entitas;
using Entitas.Serialization;
using Entitas.Unity;
using Entitas.Unity.VisualDebugging;
using UnityEditor;
using UnityEngine;

namespace Entitas.Unity.VisualDebugging {
    public static class EntityDrawer {

        static Dictionary<Pool, bool[]> _poolToUnfoldedComponents;
        static GUIStyle _foldoutStyle;
        static Dictionary<int, GUIStyle[]> _coloredBoxStyles;

        static IDefaultInstanceCreator[] _defaultInstanceCreators;
        static ITypeDrawer[] _typeDrawers;
        static string _componentNameSearchTerm = string.Empty;

        static bool _isInitialized;

        public static void Initialize() {
            if (!_isInitialized) {
                _isInitialized = true;

                _poolToUnfoldedComponents = new Dictionary<Pool, bool[]>();

                var types = Assembly.GetAssembly(typeof(EntityInspector)).GetTypes();
                _defaultInstanceCreators = types
                .Where(type => type.ImplementsInterface<IDefaultInstanceCreator>())
                .Select(type => (IDefaultInstanceCreator)Activator.CreateInstance(type))
                .ToArray();

                _typeDrawers = types
                .Where(type => type.ImplementsInterface<ITypeDrawer>())
                .Select(type => (ITypeDrawer)Activator.CreateInstance(type))
                .ToArray();
            }

            // Unity bug
            // NullReferenceException at EditorStyles.cs:136 when entering play-mode
            try {
                _foldoutStyle = new GUIStyle(EditorStyles.foldout);
                _foldoutStyle.fontStyle = FontStyle.Bold;
            } catch (Exception) {
            }

            _coloredBoxStyles = new Dictionary<int, GUIStyle[]>();
        }

        public static void DrawEntity(Pool pool, Entity entity) {
            var bgColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button("Destroy Entity")) {
                pool.DestroyEntity(entity);
            }
            GUI.backgroundColor = bgColor;

            bool[] unfoldedComponents;
            if (!_poolToUnfoldedComponents.TryGetValue(pool, out unfoldedComponents)) {
                unfoldedComponents = new bool[pool.totalComponents];
                for (int i = 0; i < unfoldedComponents.Length; i++) {
                    unfoldedComponents[i] = true;
                }
                _poolToUnfoldedComponents.Add(pool, unfoldedComponents);
            }

            EntitasEditorLayout.BeginVerticalBox();
            {
                EntitasEditorLayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField("Components (" + entity.GetComponents().Length + ")", EditorStyles.boldLabel);
                    if (GUILayout.Button("▸", GUILayout.Width(21), GUILayout.Height(14))) {
                        for (int i = 0; i < unfoldedComponents.Length; i++) {
                            unfoldedComponents[i] = false;
                        }
                    }
                    if (GUILayout.Button("▾", GUILayout.Width(21), GUILayout.Height(14))) {
                        for (int i = 0; i < unfoldedComponents.Length; i++) {
                            unfoldedComponents[i] = true;
                        }
                    }
                }
                EntitasEditorLayout.EndHorizontal();

                EditorGUILayout.Space();

                var componentNames = entity.poolMetaData.componentNames;
                var index = EditorGUILayout.Popup("Add Component", -1, componentNames);
                if (index >= 0) {
                    var componentType = entity.poolMetaData.componentTypes[index];
                    var component = (IComponent)Activator.CreateInstance(componentType);
                    entity.AddComponent(index, component);
                }

                EditorGUILayout.Space();

                _componentNameSearchTerm = EditorGUILayout.TextField("Search", _componentNameSearchTerm);

                EditorGUILayout.Space();

                var indices = entity.GetComponentIndices();
                var components = entity.GetComponents();
                for (int i = 0; i < components.Length; i++) {
                    DrawComponent(unfoldedComponents, entity, indices[i], components[i]);
                }

                EditorGUILayout.Space();

                EditorGUILayout.LabelField("Retained by (" + entity.retainCount + ")", EditorStyles.boldLabel);

                #if !ENTITAS_FAST_AND_UNSAFE

                EntitasEditorLayout.BeginVerticalBox();
                {
                    foreach (var owner in entity.owners.ToArray()) {
                        EntitasEditorLayout.BeginHorizontal();
                        {
                            EditorGUILayout.LabelField(owner.ToString());
                            if (GUILayout.Button("Release", GUILayout.Width(88), GUILayout.Height(14))) {
                                entity.Release(owner);
                            }
                            EntitasEditorLayout.EndHorizontal();
                        }
                    }
                }
                EntitasEditorLayout.EndVertical();

                #endif
            }
            EntitasEditorLayout.EndVertical();
        }

        public static void DrawMultipleEntities(Pool pool, Entity[] entities) {
            EditorGUILayout.Space();
            EntitasEditorLayout.BeginHorizontal();
            {
                var entity = entities[0];
                var componentNames = entity.poolMetaData.componentNames;
                var index = EditorGUILayout.Popup("Add Component", -1, componentNames);
                if (index >= 0) {
                    var componentType = entity.poolMetaData.componentTypes[index];
                    foreach (var e in entities) {
                        var component = (IComponent)Activator.CreateInstance(componentType);
                        e.AddComponent(index, component);
                    }
                }
            }
            EntitasEditorLayout.EndHorizontal();

            EditorGUILayout.Space();

            var bgColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.red;

            if (GUILayout.Button("Destroy selected entities")) {
                foreach (var e in entities) {
                    pool.DestroyEntity(e);
                }
            }

            GUI.backgroundColor = bgColor;

            EditorGUILayout.Space();

            foreach (var e in entities) {

                EntitasEditorLayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField(e.ToString());

                    bgColor = GUI.backgroundColor;
                    GUI.backgroundColor = Color.red;

                    if (GUILayout.Button("Destroy Entity")) {
                        pool.DestroyEntity(e);
                    }

                    GUI.backgroundColor = bgColor;
                }
                EntitasEditorLayout.EndHorizontal();
            }
        }

        public static void DrawComponent(bool[] unfoldedComponents, Entity entity, int index, IComponent component) {
            var componentType = component.GetType();

            var componentName = EntityExtension.RemoveComponentSuffix(componentType.Name);
            if (componentName.ToLower().Contains(_componentNameSearchTerm.ToLower())) {
                var fields = componentType.GetFields(BindingFlags.Public | BindingFlags.Instance);

                var boxStyle = getColoredBoxStyle(entity.totalComponents, index);
                EntitasEditorLayout.BeginVerticalBox(boxStyle);
                {
                    EntitasEditorLayout.BeginHorizontal();
                    {
                        if (fields.Length == 0) {
                            EditorGUILayout.LabelField(componentName, EditorStyles.boldLabel);
                        } else {
                            unfoldedComponents[index] = EditorGUILayout.Foldout(unfoldedComponents[index], componentName, _foldoutStyle);
                        }
                        if (GUILayout.Button("-", GUILayout.Width(19), GUILayout.Height(14))) {
                            entity.RemoveComponent(index);
                        }
                    }
                    EntitasEditorLayout.EndHorizontal();

                    if (unfoldedComponents[index]) {
                        foreach (var field in fields) {
                            var value = field.GetValue(component);
                            DrawAndSetElement(field.FieldType, field.Name, value,
                                entity, index, component, field.SetValue);
                        }
                    }
                }
                EntitasEditorLayout.EndVertical();
            }
        }

        public static void DrawAndSetElement(Type type, string fieldName, object value, Entity entity, int index, IComponent component, Action<IComponent, object> setValue) {
            var newValue = DrawAndGetNewValue(type, fieldName, value, entity, index, component);
            if (DidValueChange(value, newValue)) {
                var newComponent = entity.CreateComponent(index, component.GetType());
                component.CopyPublicMemberValues(newComponent);
                setValue(newComponent, newValue);
                entity.ReplaceComponent(index, newComponent);
            }
        }

        public static bool DidValueChange(object value, object newValue) {
            return (value == null && newValue != null)
                || (value != null && newValue == null)
                || ((value != null && newValue != null && !newValue.Equals(value)));
        }

        public static object DrawAndGetNewValue(Type type, string fieldName, object value, Entity entity, int index, IComponent component) {
            if (value == null) {
                var isUnityObject = type == typeof(UnityEngine.Object) || type.IsSubclassOf(typeof(UnityEngine.Object));
                EntitasEditorLayout.BeginHorizontal();
                {
                    if (isUnityObject) {
                        value = EditorGUILayout.ObjectField(fieldName, (UnityEngine.Object)value, type, true);
                    } else {
                        EditorGUILayout.LabelField(fieldName, "null");
                    }

                    if (GUILayout.Button("Create", GUILayout.Height(14))) {
                        object defaultValue;
                        if (CreateDefault(type, out defaultValue)) {
                            value = defaultValue;
                        }
                    }
                }
                EntitasEditorLayout.EndHorizontal();
                return value;
            }

            if (!type.IsValueType) {
                EntitasEditorLayout.BeginHorizontal();
                EntitasEditorLayout.BeginVertical();
            }

            var typeDrawer = getTypeDrawer(type);
            if (typeDrawer != null) {
                value = typeDrawer.DrawAndGetNewValue(type, fieldName, value, entity, index, component);
            } else {
                drawUnsupportedType(type, fieldName, value);
            }

            if (!type.IsValueType) {
                EntitasEditorLayout.EndVertical();
                if (GUILayout.Button("x", GUILayout.Width(19), GUILayout.Height(14))) {
                    value = null;
                }
                EntitasEditorLayout.EndHorizontal();
            }

            return value;
        }

        public static bool CreateDefault(Type type, out object defaultValue) {
            try {
                defaultValue = Activator.CreateInstance(type);
                return true;
            } catch (Exception) {
                foreach (var creator in _defaultInstanceCreators) {
                    if (creator.HandlesType(type)) {
                        defaultValue = creator.CreateDefault(type);
                        return true;
                    }
                }
            }

            var typeName = type.ToCompilableString();
            if (EditorUtility.DisplayDialog(
                    "No IDefaultInstanceCreator found",
                    "There's no IDefaultInstanceCreator implementation to handle the type '" + typeName + "'.\n" +
                    "Providing an IDefaultInstanceCreator enables you to create instances for that type.\n\n" +
                    "Do you want to generate an IDefaultInstanceCreator implementation for '" + typeName + "'?\n",
                    "Generate",
                    "Cancel"
                )) {
                generateIDefaultInstanceCreator(typeName);
            }

            defaultValue = null;
            return false;
        }

        static GUIStyle getColoredBoxStyle(int totalComponents, int index) {
            GUIStyle[] styles;
            if (!_coloredBoxStyles.TryGetValue(totalComponents, out styles)) {
                styles = new GUIStyle[totalComponents];
                for (int i = 0; i < styles.Length; i++) {
                    var hue = (float)i / (float)totalComponents;
                    var componentColor = Color.HSVToRGB(hue, 0.7f, 1f);
                    componentColor.a = 0.15f;
                    var style = new GUIStyle(GUI.skin.box);
                    style.normal.background = createTexture(2, 2, componentColor);
                    styles[i] = style;
                }
                _coloredBoxStyles.Add(totalComponents, styles);
            }

            return styles[index];
        }

        static Texture2D createTexture(int width, int height, Color color) {
            var pixels = new Color[width * height];
            for (int i = 0; i < pixels.Length; ++i) {
                pixels[i] = color;
            }
            var result = new Texture2D(width, height);
            result.SetPixels(pixels);
            result.Apply();
            return result;
        }

        static ITypeDrawer getTypeDrawer(Type type) {
            foreach (var drawer in _typeDrawers) {
                if (drawer.HandlesType(type)) {
                    return drawer;
                }
            }

            return null;
        }

        static void drawUnsupportedType(Type type, string fieldName, object value) {
            EntitasEditorLayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField(fieldName, value.ToString());
                if (GUILayout.Button("Missing ITypeDrawer", GUILayout.Height(14))) {
                    var typeName = type.ToCompilableString();
                    if (EditorUtility.DisplayDialog(
                            "No ITypeDrawer found",
                            "There's no ITypeDrawer implementation to handle the type '" + typeName + "'.\n" +
                            "Providing an ITypeDrawer enables you draw instances for that type.\n\n" +
                            "Do you want to generate an ITypeDrawer implementation for '" + typeName + "'?\n",
                            "Generate",
                            "Cancel"
                        )) {
                        generateITypeDrawer(typeName);
                    }
                }
            }
            EntitasEditorLayout.EndHorizontal();
        }

        static void generateIDefaultInstanceCreator(string typeName) {
            var config = new VisualDebuggingConfig(EntitasPreferences.LoadConfig());
            var folder = config.defaultInstanceCreatorFolderPath;
            var filePath = folder + "Default_type_InstanceCreator.cs";
            var template = string.Format(DEFAULT_INSTANCE_CREATOR_TEMPLATE_FORMAT, typeName);
            generateTemplate(folder, filePath, template);
        }

        static void generateITypeDrawer(string typeName) {
            var config = new VisualDebuggingConfig(EntitasPreferences.LoadConfig());
            var folder = config.typeDrawerFolderPath;
            var filePath = folder + "Type_TypeDrawer.cs";
            var template = string.Format(TYPE_DRAWER_TEMPLATE_FORMAT, typeName);
            generateTemplate(folder, filePath, template);
        }

        static void generateTemplate(string folder, string filePath, string template) {
            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }
            File.WriteAllText(filePath, template);
            AssetDatabase.Refresh();
            EditorApplication.isPlaying = false;
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(filePath);
        }

        const string DEFAULT_INSTANCE_CREATOR_TEMPLATE_FORMAT = @"using System;
using Entitas.Unity.VisualDebugging;

// Please rename class name and file name
public class Default_type_InstanceCreator : IDefaultInstanceCreator {{
    public bool HandlesType(Type type) {{
        return type == typeof({0});
    }}

    public object CreateDefault(Type type) {{
        // return your implementation to create an instance of type {0}
        throw new NotImplementedException();
    }}
}}
";

        const string TYPE_DRAWER_TEMPLATE_FORMAT = @"using System;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class Type_TypeDrawer : ITypeDrawer {{
    public bool HandlesType(Type type) {{
        return type == typeof({0});
    }}

    public object DrawAndGetNewValue(Type type, string fieldName, object value, Entity entity, int index, IComponent component) {{
        // return your implementation to draw the type {0}
        throw new NotImplementedException();
    }}
}}";
    }
}