﻿using Entitas;
using UnityEngine;

public class PoolUpdateGroupsComponentAddedOrRemovedPerformanceTest : MonoBehaviour {

    Entity _entity;

    void Start() {
        Pools.sharedInstance.visualDebugging = Pools.CreateVisualDebuggingPool();
        Pools.sharedInstance.visualDebugging.GetGroup(VisualDebuggingMatcher.MyInt);
        _entity = Pools.sharedInstance.visualDebugging.CreateEntity();
    }

    void Update() {
        _entity.AddMyInt(0);
        _entity.RemoveMyInt();
    }
}
