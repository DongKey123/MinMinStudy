using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace AttackSystem
{
    public class BattleController //BattleMode 1
    {
        public Action<int> OnHitPlayer;

        private BaseMonster target = null;

        public void GenerateMonster(BaseMonster monster)
        {
            target = monster;
        }

        public void AttackMonster(PlayerClass player)
        {
            if(target == null)
            {
                Debug.Log("공격할 대상이 없습니다.");
            }

            //공격 가능 판
            bool attackable = IsAttackAble(player.attackAbleFlags);
            if(attackable == false)
            {
                Debug.Log("공격 불가능");

                // 반격 !
                CountAttackPlayer();
            }
            else
            {
                //Todo: 수식처리
                if(target.hp - player.attackPower > 0)
                {
                    target.Hit(player.attackPower);

                    CountAttackPlayer();
                }
                else
                {
                    target.Die();
                }
                
            }
        }

        private void CountAttackPlayer()
        {
            target.Attack();
            OnHitPlayer?.Invoke(target.attackPower);
        }

        private bool IsAttackAble(MonsterTypeFlag flag)
        {
            bool attackable = (target.MonsterTypeFlag | flag) != MonsterTypeFlag.NULL;

            return attackable;
        }
    }
}
