﻿using Entitas;

public sealed class MyTestContext : Context<TestEntity> {

    public MyTestContext() : base(CID.TotalComponents) {
    }

    public MyTestContext(int totalComponents, int startCreationIndex, ContextInfo contextInfo)
        : base(totalComponents, startCreationIndex, contextInfo, (entity) => new SafeAERC(entity)) {
    }
}
