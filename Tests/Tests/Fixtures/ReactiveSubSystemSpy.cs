﻿using Entitas;
using System.Collections.Generic;
using System.Linq;

public class ReactiveSubSystemSpy : IReactiveSubEntitySystem {
    public int didExecute { get { return _didExecute; } }

    public Entity[] entites { get { return _entites; } }

    readonly IEntityMatcher _matcher;
    readonly EntityCollectionEventType _eventType;
    int _didExecute;
    Entity[] _entites;

    public ReactiveSubSystemSpy(IEntityMatcher matcher, EntityCollectionEventType eventType) {
        _matcher = matcher;
        _eventType = eventType;
    }

    public IEntityMatcher GetTriggeringMatcher() {
        return _matcher;
    }

    public EntityCollectionEventType GetEventType() {
        return _eventType;
    }

    public void Execute(IEnumerable<Entity> entities) {
        _didExecute++;
        _entites = entities.ToArray();
    }
}
