using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    public abstract class PlayerClass
    {
        public int hp;
        public int attackPower;

        public MonsterTypeFlag attackAbleFlags;

        private BattleController curBattleSystem;

        public virtual void Initialize(BattleController battleSystem)
        {
            curBattleSystem = battleSystem;
        }

        public virtual void Attack()
        {
            curBattleSystem.AttackMonster(this);
        }

        public virtual void OnHit(int power)
        {
            hp -= power;
        }
    }

    public class Warrior : PlayerClass
    {
        public Warrior()
        {
            UnityEngine.Debug.Log($"Warrior Generate");

            hp = 100;
            attackPower = 5;

            attackAbleFlags = MonsterTypeFlag.Ground | MonsterTypeFlag.Water;

        }

        public override void Attack()
        {
            UnityEngine.Debug.Log($"Warrior Attack");
            base.Attack();
        }

        public override void OnHit(int power)
        {
            base.OnHit(power);
            UnityEngine.Debug.Log($"Warrior Hit ({power}) CurHP: {hp}");
        }
    }

    public class Magician : PlayerClass
    {
        public Magician()
        {
            hp = 80;
            attackPower = 8;

            attackAbleFlags = MonsterTypeFlag.Ground | MonsterTypeFlag.Water | MonsterTypeFlag.Air;

            UnityEngine.Debug.Log($"Magician Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log($"Magician Attack");
            base.Attack();
        }

        public override void OnHit(int power)
        {
            base.OnHit(power);

            UnityEngine.Debug.Log($"Magician Hit ({power}) CurHP: {hp}");
        }
    }

    public class Archer : PlayerClass
    {
        public Archer()
        {
            hp = 90;
            attackPower = 7;

            attackAbleFlags = MonsterTypeFlag.Ground | MonsterTypeFlag.Air;

            UnityEngine.Debug.Log($"Archer Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log($"Archer Attack");
            base.Attack();
        }

        public override void OnHit(int power)
        {
            base.OnHit(power);

            UnityEngine.Debug.Log($"Archer Hit ({power}) CurHP: {hp}");
        }
    }

    public class Monk : PlayerClass
    {
        public Monk()
        {
            hp = 150;
            attackPower = 15;

            attackAbleFlags = MonsterTypeFlag.Ground;

            UnityEngine.Debug.Log($"Monk Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log($"Monk Attack");
            base.Attack();
        }

        public override void OnHit(int power)
        {
            base.OnHit(power);

            UnityEngine.Debug.Log($"Monk Hit ({power}) CurHP: {hp}" );
        }
    }
}