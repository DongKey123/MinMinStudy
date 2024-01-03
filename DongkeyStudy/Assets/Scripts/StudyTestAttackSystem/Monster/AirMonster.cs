using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    public class Dragon : AirMonster
    {
        public Dragon()
        {
            hp = 30;
            attackPower = 3;

            UnityEngine.Debug.Log($"Dragon Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log("Dragon Attack");
            base.Attack();
        }

        public override void Die()
        {
            base.Die();
            UnityEngine.Debug.Log("Dragon Die");
        }

        public override void Hit(int power)
        {
            UnityEngine.Debug.Log($"Dragon Hit ({power})");
            base.Hit(power);
        }
    }

    public class Griffin : AirMonster
    {
        public Griffin()
        {
            hp = 40;
            attackPower = 3;

            UnityEngine.Debug.Log($"Griffin Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log("Griffin Attack");
            base.Attack();
        }

        public override void Die()
        {
            UnityEngine.Debug.Log("Griffin Die");
            base.Die();
        }

        public override void Hit(int power)
        {
            UnityEngine.Debug.Log($"Griffin Hit ({power})");
            base.Hit(power);
        }
    }

    public class Harpy : AirMonster
    {
        public Harpy()
        {
            hp = 50;
            attackPower = 3;

            UnityEngine.Debug.Log($"Harpy Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log("Harpy Attack");
            base.Attack();
        }

        public override void Die()
        {
            UnityEngine.Debug.Log("Harpy Die");
            base.Die();
        }

        public override void Hit(int power)
        {
            UnityEngine.Debug.Log($"Harpy Hit ({power})");
            base.Hit(power);
        }
    }
}
