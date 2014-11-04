﻿using Entitas;

public class EntityRepositoryCreateEntity : IPerformanceTest {
    const int n = 100000;
    EntityRepository _repo;

    public void Before() {
        _repo = new EntityRepository(CP.NumComponents);
    }

    public void Run() {
        for (int i = 0; i < n; i++) {
            _repo.CreateEntity();
        }
    }
}

