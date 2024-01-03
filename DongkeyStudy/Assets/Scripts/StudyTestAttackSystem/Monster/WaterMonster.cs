using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    public class Naga : WaterMonser
    {
        public Naga()
        {
            hp = 50;
            attackPower = 3;

            UnityEngine.Debug.Log($"Naga Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log("Naga Attack");
            base.Attack();
        }

        public override void Die()
        {
            UnityEngine.Debug.Log("Naga Die");
            base.Die();
        }

        public override void Hit(int power)
        {
            UnityEngine.Debug.Log($"Naga Hit ({power})");
            base.Hit(power);
        }
    }

    public class Kraken : WaterMonser
    {
        public Kraken()
        {
            hp = 50;
            attackPower = 3;

            UnityEngine.Debug.Log($"Kraken Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log("Kraken Attack");
            base.Attack();
        }

        public override void Die()
        {
            UnityEngine.Debug.Log("Kraken Die");
            base.Die();
        }

        public override void Hit(int power)
        {
            UnityEngine.Debug.Log($"Kraken Hit ({power})");
            base.Hit(power);
        }
    }

    public class Frog : WaterMonser
    {
        public Frog()
        {
            hp = 50;
            attackPower = 3;

            UnityEngine.Debug.Log($"Frog Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log("Frog Attack");
            base.Attack();
        }

        public override void Die()
        {
            UnityEngine.Debug.Log("Frog Die");
            base.Die();
        }

        public override void Hit(int power)
        {
            UnityEngine.Debug.Log($"Frog Hit ({power})");
            base.Hit(power);
        }
    }
}