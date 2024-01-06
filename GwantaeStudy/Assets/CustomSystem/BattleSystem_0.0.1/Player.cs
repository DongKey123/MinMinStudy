using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerClass
{
    public abstract void Attack(Monster _monster);
    public abstract void Attacked();
}
public class OneHandedAxClass : PlayerClass
{
    public override void Attack(Monster _monster)
    {
        Debug.Log("한손도끼 공격 ");
        _monster.attackedDele?.Invoke();
    }

    public override void Attacked()
    {
        Debug.Log("한손도끼 공격 당함 ");
    }
}
public class TwoHandedAxClass : PlayerClass
{
    public override void Attack(Monster _monster)
    {
        Debug.Log("두손도끼 공격 ");
        _monster.attackedDele?.Invoke();
    }

    public override void Attacked()
    {
        Debug.Log("두손도끼 공격 당함");
    }
}
public class PaladinClass : PlayerClass
{
    public override void Attack(Monster _monster)
    {
        Debug.Log("성기사 공격 ");
        _monster.attackedDele?.Invoke();
    }

    public override void Attacked()
    {
        Debug.Log("성기사 공격 당함");
    }
}
public class SamuraiClass : PlayerClass
{
    public override void Attack(Monster _monster)
    {
        Debug.Log("사무라이 공격 ");
        _monster.attackedDele?.Invoke();
    }

    public override void Attacked()
    {
        Debug.Log("사무라이 공격 당함");
    }
}
public class Player
{
    public PlayerClass playerClass;
    public delegate void AttackedDelegate();
    public AttackedDelegate attackedDele;

    public void SetPlayerClass(PlayerClass _class)
    {
        playerClass = _class;
        attackedDele = _class.Attacked;
    }

}
