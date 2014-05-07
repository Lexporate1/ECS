﻿using System.Collections.Generic;

namespace Entitas {
    public interface IReactiveSubEntitySystem {
        IEntityMatcher GetTriggeringMatcher();

        EntityCollectionEventType GetEventType();

        void Execute(List<Entity> entities);
    }
}

