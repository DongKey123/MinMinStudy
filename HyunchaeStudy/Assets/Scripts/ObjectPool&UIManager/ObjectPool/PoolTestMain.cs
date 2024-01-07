using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTestMain : MonoBehaviour
{
    private PoolManager poolManager = PoolManager.instance;
    private TestObjectPool<Monster> monsterPool;
    public Stack<Monster> mStack = new Stack<Monster>();

    private int num = 0;
    void Start()
    {
        monsterPool = poolManager.GetPool<Monster>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Monster m = monsterPool.GetObject();

            if(m.monNum == 0)
            {
                m.monNum = num;
                num++;
            }
            m.OnDequeue();


            mStack.Push(m);

        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(mStack.Count >= 1)
            {
                Monster m = mStack.Pop();

                m.OnEnqueue();
                monsterPool.RetrunObject(m);

            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            var pool = poolManager.GetPool<Monster>();

        }
    }
}
