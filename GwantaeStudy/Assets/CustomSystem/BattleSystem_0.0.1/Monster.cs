using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster
{
    public delegate void AttackedDelegate();
    public AttackedDelegate attackedDele;
    public abstract void Attack(Player _playerClass);
    public abstract void Attacked();
}

public class WaterMonster : Monster
{
    public override void Attack(Player _playerClass)
    {
        Debug.Log("수중 몬스터 공격 ");
    }

    public override void Attacked()
    {
        Debug.Log("수중 몬스터 공격 당함");
    }
}
public class AirMonster : Monster
{
    public override void Attack(Player _playerClass)
    {
        Debug.Log("공중 몬스터 공격 ");
    }

    public override void Attacked()
    {
        Debug.Log("공중 몬스터 공격 당함");
    }
}
public class GroundMonster : Monster
{
    public override void Attack(Player _playerClass)
    {
        Debug.Log("지상 몬스터 공격 ");
    }

    public override void Attacked()
    {
        Debug.Log("지상 몬스터 공격 당ㅐ");
    }
}


public class SharkMoster : WaterMonster
{
    public SharkMoster()
    {
        attackedDele = Attacked;
    }
    public override void Attack(Player _playerClass)
    {
        base.Attack(_playerClass);
        Debug.Log("상어 몬스터");
        _playerClass.attackedDele?.Invoke();
    }
    public override void Attacked()
    {
        base.Attacked();
        Debug.Log("상어 몬스터");
    }
}
public class WhaleMoster : WaterMonster
{
    public WhaleMoster()
    {
        attackedDele = Attacked;
    }
    public override void Attack(Player _playerClass)
    {
        base.Attack(_playerClass);
        Debug.Log("고래 몬스터");
        _playerClass.attackedDele?.Invoke();
    }
    public override void Attacked()
    {
        base.Attacked();
        Debug.Log("고래 몬스터");
    }

}
public class CrocodileMoster : WaterMonster
{
    public CrocodileMoster()
    {
        attackedDele = Attacked;
    }
    public override void Attack(Player _playerClass)
    {
        base.Attack(_playerClass);
        Debug.Log("악어 몬스터");
        _playerClass.attackedDele?.Invoke();
    }
    public override void Attacked()
    {
        base.Attacked();
        Debug.Log("악어 몬스터");
    }

}


public class EagleMoster : AirMonster
{
    public EagleMoster()
    {
        attackedDele = Attacked;
    }
    public override void Attack(Player _playerClass)
    {
        base.Attack(_playerClass);
        Debug.Log("독수리 몬스터");
        _playerClass.attackedDele?.Invoke();
    }
    public override void Attacked()
    {
        base.Attacked();
        Debug.Log("독수리 몬스터");
    }

}
public class PigeonMoster : AirMonster
{
    public PigeonMoster()
    {
        attackedDele = Attacked;
    }
    public override void Attack(Player _playerClass)
    {
        base.Attack(_playerClass);
        Debug.Log("비둘기 몬스터");
        _playerClass.attackedDele?.Invoke();
    }
    public override void Attacked()
    {
        base.Attacked();
        Debug.Log("비둘기 몬스터");
    }

}
public class CrowMonster : AirMonster
{
    public CrowMonster()
    {
        attackedDele = Attacked;
    }
    public override void Attack(Player _playerClass)
    {
        base.Attack(_playerClass);
        Debug.Log("까마귀 몬스터");
        _playerClass.attackedDele?.Invoke();
    }
    public override void Attacked()
    {
        base.Attacked();
        Debug.Log("까마귀 몬스터");
    }

}


public class LionMonster : GroundMonster
{
    public LionMonster()
    {
        attackedDele = Attacked;
    }
    public override void Attack(Player _playerClass)
    {
        base.Attack(_playerClass);
        Debug.Log("사자 몬스터");
        _playerClass.attackedDele?.Invoke();
    }
    public override void Attacked()
    {
        base.Attacked();
        Debug.Log("사자 몬스터");
    }

}
public class TigerMonster : GroundMonster
{
    public TigerMonster()
    {
        attackedDele = Attacked;
    }
    public override void Attack(Player _playerClass)
    {
        base.Attack(_playerClass);
        Debug.Log("호랑이 몬스터");
        _playerClass.attackedDele?.Invoke();
    }
    public override void Attacked()
    {
        base.Attacked();
        Debug.Log("호랑이 몬스터");
    }

}
public class ElephantMonster : GroundMonster
{
    public ElephantMonster()
    {
        attackedDele = Attacked;
    }
    public override void Attack(Player _playerClass)
    {
        base.Attack(_playerClass);
        Debug.Log("코끼리 몬스터");
        _playerClass.attackedDele?.Invoke();
    }
    public override void Attacked()
    {
        base.Attacked();
        Debug.Log("코끼리 몬스터");
    }

}

