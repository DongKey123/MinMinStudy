using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private static PoolManager poolManager;
    public static PoolManager instance
    {
        get
        {
            if (poolManager == null)
            {
                poolManager = new PoolManager();
            }

            return poolManager;
        }
    }

    private const int DEFAULT_POOL_SIZE = 10;
    private List<IPool> poolList = new List<IPool>();

    private TestObjectPool<T> CreatePool<T>() where T : IPoolable, new()
    {
        TestObjectPool<T> newPool = new TestObjectPool<T>(DEFAULT_POOL_SIZE);
        poolList.Add(newPool);
        return newPool;
    }

    public TestObjectPool<T> GetPool<T>() where T : IPoolable, new()
    {
        int listSize = poolList.Capacity;

        for(int i = 0; i <listSize; i++)
        {
            Type t = poolList[i].GetType();
            if(typeof(TestObjectPool<T>).Equals(t))
            {
                Debug.Log("Already Create Pool");
                return (TestObjectPool<T>)poolList[i];
            }
        }

        Debug.Log("Create New Pool");
        return CreatePool<T>();
    }
}
