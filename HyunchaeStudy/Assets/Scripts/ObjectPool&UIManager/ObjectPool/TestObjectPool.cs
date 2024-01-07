using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjectPool<T> : IPool where T : IPoolable, new()
{
    private int increaseSize;
    private Queue<T> objectPool;

    public TestObjectPool(int _poolSize,int _increaseSize = 4)
    {
        increaseSize = _increaseSize;
        objectPool = new Queue<T>(_poolSize);
    }

    public T GetObject()
    {
        T obj;

        Debug.Log("PoolCount " + objectPool.Count);

        if (objectPool.TryDequeue(out obj))
        {
            return obj;
        }
        else
        {
            IncreasePool();
            return objectPool.Dequeue();
        }
    }

    public void RetrunObject(T obj)
    {
        objectPool.Enqueue(obj);

        Debug.Log("PoolCount " + objectPool.Count);

    }

    private void IncreasePool()
    {
        for(int i = 0; i<increaseSize;i++)
        {
            objectPool.Enqueue(new T());
        }
    }
}
