﻿using System;
using System.Collections.Generic;

namespace ToolKit {
    public class ObjectPool<T> where T : new() {
        readonly Func<T> _factoryMethod;
        readonly Stack<T> _pool = new Stack<T>();

        public ObjectPool() {
            _factoryMethod = () => new T();
        }

        public ObjectPool(Func<T> factoryMethod) {
            _factoryMethod = factoryMethod;
        }

        public T Get() {
            if (_pool.Count > 0)
                return _pool.Pop();

            return _factoryMethod();
        }

        public void Push(T obj) {
            _pool.Push(obj);
        }
    }
}

