using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    public enum MonsterType
    {
        Ground = 0,
        Water = 1,
        Air = 2
    }

    public enum MonsterTypeFlag
    {
        NULL = 0x00000000 ,

        Ground = 0x00000001 << MonsterType.Ground,
        Water = 0x000000001 << MonsterType.Water,
        Air = 0x00000000 << MonsterType.Air,

        MAX = 0x00000000
    }

    

    public abstract class BaseMonster
    {
        //Todo: 추후 몬스터 id를 통해 관리 
        public int hp;
        public int attackPower;

        protected MonsterType monsterType;
        public MonsterType MonsterType
        {
            get
            {
                return monsterType;
            }
        }

        protected MonsterTypeFlag monsterTypeFlag;
        public MonsterTypeFlag MonsterTypeFlag
        {
            get { return monsterTypeFlag; }
        }

        public virtual void Attack()
        {

        }

        public virtual void Hit(int power)
        {
            hp -= power;
        }
        public virtual void Die()
        {

        }
    }

    public class AirMonster : BaseMonster
    {

        protected AirMonster()
        {
            monsterType = MonsterType.Air;
            monsterTypeFlag = MonsterTypeFlag.Air;
        }
    }

    public class WaterMonser : BaseMonster
    {
        protected WaterMonser()
        {

            monsterType = MonsterType.Water;
            monsterTypeFlag = MonsterTypeFlag.Water;
        }

    }

    public class GroundMonster : BaseMonster
    {
        public GroundMonster()
        {
            monsterType = MonsterType.Ground;
            monsterTypeFlag = MonsterTypeFlag.Ground;
        }

    }
}