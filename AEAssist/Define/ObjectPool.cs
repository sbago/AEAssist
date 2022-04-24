using System;
using System.Collections.Generic;

namespace AEAssist.Define
{
    public class ObjectPool
    {
        public static ObjectPool Instance = new ObjectPool();

        private Dictionary<Type, Queue<object>> AllObjs = new Dictionary<Type, Queue<object>>();

        public T Fetch<T>() where T : Entity, new()
        {
            var type = typeof(T);
            if (!AllObjs.TryGetValue(type, out var pool))
            {
                return Activator.CreateInstance<T>();
            }

            if (pool.Count == 0)
                return Activator.CreateInstance<T>();

            var ret = pool.Dequeue() as T;
            ret.IsDisposed = false;
            return ret;
        }

        public void Return<T>(T t) where T : class, IDisposable, new()
        {
            var type = typeof(T);
            if (!AllObjs.TryGetValue(type, out var pool))
            {
                pool = new Queue<object>();
                AllObjs[type] = pool;
            }

            if (pool.Count >= 100)
                return;
            
            t.Dispose();
            pool.Enqueue(t);
        }

    }
}