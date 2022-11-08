﻿using Entitas;

public sealed class MyTest1Context : Context<Test1Entity> {

    public MyTest1Context() : base(CID.TotalComponents, () => new Test1Entity()) {
    }

    public MyTest1Context(int totalComponents, int startCreationIndex, ContextInfo contextInfo)
        : base(totalComponents, startCreationIndex, contextInfo, (entity) => new SafeAERC(entity), () => new Test1Entity()) {
    }
}
