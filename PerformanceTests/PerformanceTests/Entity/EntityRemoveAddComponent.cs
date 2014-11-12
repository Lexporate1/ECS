﻿using Entitas;

public class EntityRemoveAddComponent : IPerformanceTest {
    const int n = 1000000;
    EntityRepository _repo;
    Entity _e;

    public void Before() {
        _repo = new EntityRepository(CP.NumComponents);
        _repo.GetCollection(Matcher.AllOf(new [] { CP.ComponentA }));
        _repo.GetCollection(Matcher.AllOf(new [] { CP.ComponentB }));
        _repo.GetCollection(Matcher.AllOf(new [] { CP.ComponentC }));
        _repo.GetCollection(Matcher.AllOf(new [] {
            CP.ComponentA,
            CP.ComponentB
        }));
        _repo.GetCollection(Matcher.AllOf(new [] {
            CP.ComponentA,
            CP.ComponentC
        }));
        _repo.GetCollection(Matcher.AllOf(new [] {
            CP.ComponentB,
            CP.ComponentC
        }));
        _repo.GetCollection(Matcher.AllOf(new [] {
            CP.ComponentA,
            CP.ComponentB,
            CP.ComponentC
        }));
        _e = _repo.CreateEntity();
        _e.AddComponent(CP.ComponentA, new ComponentA());
    }

    public void Run() {
        for (int i = 0; i < n; i++) {
            _e.RemoveComponent(CP.ComponentA);
            _e.AddComponent(CP.ComponentA, new ComponentA());
        }    
    }
}

