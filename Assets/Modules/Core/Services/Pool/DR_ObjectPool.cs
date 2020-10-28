using System;
using System.Collections.Generic;

namespace Game.Core
{ 
     public class DR_ObjectPool<T> where T : class
    {
        Func<T>   actionCreate  = default;
        Action<T> actionOnGet = default;
        Action<T> actionOnRelease = default;

        private static Stack<T> objectsStack;   

        public DR_ObjectPool(Func<T> actionCreate, Action<T> actionOnGet = null, Action<T> actionOnRelease = null, bool concurrent = false, bool collectionCheck = true, int defaultCapacity = -1, uint maxSize = 10000)
        {
            this.actionCreate = actionCreate;
            this.actionOnGet = actionOnGet;
            this.actionOnRelease = actionOnRelease;
            objectsStack = new Stack<T>();
        }
        

        //public int CountAll      { get; }
        //public int CountActive   { get; }
        //public int CountInactive { get; }



        ////public void Clear();
        //public T Get()
        //{   
           

            
        //}

             

                
        //public PooledObject Get(out T v);
        //public void PreWarm(int count);
        //public void Release(T element);
        //public bool TryGet(Predicate<T> pred, out T result);

        //public struct PooledObject : IDisposable, IEquatable<PooledObject>
        //{
        //    public bool Equals(PooledObject other);
        //    public override bool Equals(object obj);
        //    public override int GetHashCode();
        //}
        //}
    }

}