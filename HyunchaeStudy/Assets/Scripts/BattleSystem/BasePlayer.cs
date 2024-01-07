using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EJob
{
    WORRIOR = 0,
    ARCHER = 1,
    MAGE = 2,
    THIEF = 3
}

public abstract class BasePlayer : BaseCharacter
{
    protected EJob job;

    public BasePlayer() { }

    public override void LogStatus()
    {
        Debug.Log("Player Job : " + job);
        Debug.Log("Player HP : " + hp);
        Debug.Log("Plater Damage : " + damage);
    }

    public override BaseCharacter Attack()
    {
        return this;
    }

    public override void RecieveAttack(BaseCharacter _character)
    {
        hp -= _character.GetDamage();
        recieveAttackDele.Invoke(this);
    }
}

public class Worrior : BasePlayer
{
    public Worrior() : base()
    {
        job = EJob.WORRIOR;
    }

}

public class Archer : BasePlayer
{
    public Archer() : base()
    {
        job = EJob.ARCHER;
    }
}

public class Mage : BasePlayer
{
    public Mage() : base()
    {
        job = EJob.MAGE;
    }
}

public class Thief : BasePlayer
{
    public Thief() : base() 
    {
        job = EJob.THIEF;
    }
}