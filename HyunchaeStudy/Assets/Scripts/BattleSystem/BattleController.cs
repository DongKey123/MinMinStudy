using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    private BaseCharacter player;
    private BaseCharacter monster;
    private bool isBattle = false;
    private bool isPlayerTurn = true;

    private void Update()
    {
        while (isBattle)
        {
            if(isPlayerTurn && isBattle)
            monster.RecieveAttack(player.Attack());
            if(!isPlayerTurn && isBattle)
            player.RecieveAttack(monster.Attack());
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isBattle)
        {
            StartNewGame();
        }

        if (!isBattle)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("워리어 선택");
                player = new Worrior();
                player.recieveAttackDele += PlayerReceiveAttack;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("아처 선택");
                player = new Archer();
                player.recieveAttackDele += PlayerReceiveAttack;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("메이지 선택");
                player = new Mage();
                player.recieveAttackDele += PlayerReceiveAttack;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Debug.Log("시프 선택");
                player = new Thief();
                player.recieveAttackDele += PlayerReceiveAttack;
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("공중몬스터 선택");

                int randomMonNum = Random.RandomRange(0, 3);

                switch(randomMonNum)
                {
                    case 0:
                        monster = new Eagle();
                        break;
                    case 1:
                        monster = new Pizone();
                        break;
                    case 2:
                        monster = new Crow();
                        break;
                }
                Debug.Log("몬스터 타입 : " + monster);
                monster.recieveAttackDele += MonsterReceievAttack;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("수중몬스터 선택");

                int randomMonNum = Random.RandomRange(0, 3);

                switch (randomMonNum)
                {
                    case 0:
                        monster = new Octopus();
                        break;
                    case 1:
                        monster = new Shark();
                        break;
                    case 2:
                        monster = new Whale();
                        break;
                }

                Debug.Log("몬스터 타입 : " + monster);

                monster.recieveAttackDele += MonsterReceievAttack;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("지상몬스터 선택");

                int randomMonNum = Random.RandomRange(0, 3);

                switch (randomMonNum)
                {
                    case 0:
                        monster = new Tiger();
                        break;
                    case 1:
                        monster = new Bear();
                        break;
                    case 2:
                        monster = new Puma();
                        break;
                }
                Debug.Log("몬스터 타입 : " + monster);
                monster.recieveAttackDele += MonsterReceievAttack;
            }
        }
    }

    private void PlayerReceiveAttack(BaseCharacter _character)
    {
        int hp = _character.GetHp();

        Debug.Log("Monster Attack!! - Player Hp : " + hp);

        if(hp <= 0)
        {
            Debug.Log("Player Die BattleEnd");
            BattleEnd();
        }

        isPlayerTurn = true;
    }

    private void MonsterReceievAttack(BaseCharacter _character)
    {
        int hp = _character.GetHp();

        Debug.Log("Player Attack!! - Monster Hp : " + hp);

        if (hp <= 0)
        {
            Debug.Log("Monster Die BattleEnd");
            BattleEnd();
        }

        isPlayerTurn = false;
    }

    private void StartNewGame()
    {
        if(player == null)
        {
            Debug.Log("플레이어 직업 미선택");
            return;
        }
        else if(monster == null)
        {
            Debug.Log("몬스터 미선택");
            return;
        }


        player.SetStatus(Random.RandomRange(20, 35), Random.RandomRange(3, 7));
        monster.SetStatus(Random.RandomRange(20, 35), Random.RandomRange(3, 7));

        player.LogStatus();
        monster.LogStatus();

        isBattle = true;
    }

    private void BattleEnd()
    {
        isBattle = false;
        player = null;
        monster = null;
    }
}
