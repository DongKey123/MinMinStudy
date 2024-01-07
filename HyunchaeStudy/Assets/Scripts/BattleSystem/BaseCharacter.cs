using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter
{
    public delegate void RecieveAttackDele(BaseCharacter _character);
    public RecieveAttackDele recieveAttackDele;

    protected int hp;
    protected int damage;

    public BaseCharacter() { }

    public abstract BaseCharacter Attack();

    public abstract void RecieveAttack(BaseCharacter _character);

    public virtual void SetStatus(int _hp, int _damage)
    {
        hp = _hp;
        damage = _damage;
    }

    public abstract void LogStatus();

    public virtual int GetDamage()
    {
        return damage;
    }

    public virtual int GetHp()
    {
        return hp;
    }
    
}