using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    public void OnEnqueue();
    public void OnDequeue();
}

public class Monster : IPoolable
{
    public int monNum;

    public void OnDequeue()
    {
        Debug.Log(monNum + "MonsterEnqueue");
    }

    public void OnEnqueue()
    {
        Debug.Log(monNum + "MonsterDequeue");
    }
}
