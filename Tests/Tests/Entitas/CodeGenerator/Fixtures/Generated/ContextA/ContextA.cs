﻿using Entitas;

public sealed partial class ContextA : Context<ContextAEntity> {

    public ContextA(int totalComponents, int startCreationIndex, ContextInfo contextInfo)
        : base(totalComponents, startCreationIndex, contextInfo) {
    }
}
