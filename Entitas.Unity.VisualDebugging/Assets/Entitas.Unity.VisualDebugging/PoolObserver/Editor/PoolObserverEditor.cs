﻿using Entitas;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace Entitas.Unity.VisualDebugging {
    [CustomEditor(typeof(PoolObserverBehaviour))]
    public class PoolObserverEditor : Editor {

        public override void OnInspectorGUI() {
            var poolObserver = ((PoolObserverBehaviour)target).poolObserver;

            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField(poolObserver.name, EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Entities", poolObserver.pool.Count.ToString());
            EditorGUILayout.LabelField("Reusable entities", poolObserver.pool.reusableEntitiesCount.ToString());
            EditorGUILayout.LabelField("Retained entities", poolObserver.pool.retainedEntitiesCount.ToString());
            EditorGUILayout.EndVertical();

            var groups = poolObserver.groups;
            if (groups.Length != 0) {
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUILayout.LabelField("Groups (" + groups.Length + ")", EditorStyles.boldLabel);
                foreach (var group in groups.OrderByDescending(g => g.Count)) {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(group.ToString());
                    EditorGUILayout.LabelField(group.Count.ToString(), GUILayout.Width(48));
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }

            EditorUtility.SetDirty(target);
        }
    }
}