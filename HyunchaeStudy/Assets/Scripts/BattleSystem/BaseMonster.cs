using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EMonsterType
{
    AIR = 0,
    WATER = 1,
    EARTH = 2
}

public abstract class BaseMonster : BaseCharacter
{
    protected EMonsterType type;

    public BaseMonster() { }

    public override void LogStatus()
    {
        Debug.Log(type);
        Debug.Log(this);
        Debug.Log("Monster Name : " + this);
        Debug.Log("Monster HP : " + hp);
        Debug.Log("Monster Damage : " + damage);
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

public abstract class BaseAirMonster : BaseMonster
{
    public BaseAirMonster() : base()
    {
        type = EMonsterType.AIR;
    }
}

public abstract class BaseWaterMonster : BaseMonster
{
    public BaseWaterMonster() : base()
    {
        type = EMonsterType.WATER;
    }
}
public abstract class BaseEarthMonster : BaseMonster
{
    public BaseEarthMonster() : base()
    {
        type = EMonsterType.EARTH;
    }
}

public class Eagle : BaseAirMonster
{
    public Eagle() : base() { }
}

public class Pizone : BaseAirMonster
{
    public Pizone() : base() { }
}
public class Crow : BaseAirMonster
{
    public Crow() : base() { }
}

public class Octopus : BaseWaterMonster
{
    public Octopus() : base() { }
}

public class Shark : BaseWaterMonster
{
    public Shark() : base() { }
}

public class Whale : BaseWaterMonster
{
    public Whale() : base() { }
}

public class Tiger : BaseEarthMonster
{
    public Tiger() : base() { }
}
public class Bear : BaseEarthMonster
{
    public Bear() : base() { }
}

public class Puma : BaseEarthMonster
{
    public Puma() : base() { }
}