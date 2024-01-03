using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    public class Ork : GroundMonster
    {
        public Ork()
        {
            hp = 60;
            attackPower = 3;

            UnityEngine.Debug.Log($"Ork Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log("Ork Attack");
            base.Attack();
        }

        public override void Die()
        {
            UnityEngine.Debug.Log("Ork Die");
            base.Die();
        }

        public override void Hit(int power)
        {
            UnityEngine.Debug.Log($"Ork Hit ({power})");
            base.Hit(power);
        }
    }

    public class Troll : GroundMonster
    {
        public Troll()
        {
            hp = 60;
            attackPower = 3;

            UnityEngine.Debug.Log($"Troll Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log("Troll Attack");
            base.Attack();
        }

        public override void Die()
        {
            UnityEngine.Debug.Log("Troll Die");
            base.Die();
        }

        public override void Hit(int power)
        {
            UnityEngine.Debug.Log($"Troll Hit ({power})");
            base.Hit(power);
        }
    }

    public class Goblin : GroundMonster
    {
        public Goblin()
        {
            hp = 60;
            attackPower = 3;

            UnityEngine.Debug.Log($"Goblin Generate");
        }

        public override void Attack()
        {
            UnityEngine.Debug.Log("Goblin Attack");
            base.Attack();
        }

        public override void Die()
        {
            UnityEngine.Debug.Log("Goblin Die");
            base.Die();
        }

        public override void Hit(int power)
        {
            UnityEngine.Debug.Log($"Goblin Hit ({power})");
            base.Hit(power);
        }
    }
}
