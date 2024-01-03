using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private int monsterIndex;
    private Player player = new Player();
    private Monster[] monsterArr = new Monster[]
    {
        new SharkMoster(),
        new WhaleMoster(),
        new CrocodileMoster(),
        new EagleMoster(),
        new PigeonMoster(),
        new CrowMonster(),
        new LionMonster(),
        new TigerMonster(),
        new ElephantMonster()
    };

    public Action playerAttackedAction;
    public Action monsterAttackedAction;

    public void Start()
    {
        Debug.Log("직업 선택");
        Debug.Log("q : 한손도끼");
        Debug.Log("w : 양손도끼");
        Debug.Log("e : 성기사");
        Debug.Log("r : 사무라이");

        Debug.Log("적 선택");
        Debug.Log(" 0 : SharkMonster");
        Debug.Log(" 1 : WhaleMoster");
        Debug.Log(" 2 : CrocodileMoster");
        Debug.Log(" 3 : EagleMoster");
        Debug.Log(" 4 : PigeonMoster");
        Debug.Log(" 5 : CrowMonster");
        Debug.Log(" 6 : LionMonster");
        Debug.Log(" 7 : TigerMonster");
        Debug.Log(" 8 : ElephantMonster");

        Debug.Log("전투 시작 : a 플레이어 공격 한번 몬스터 공격 한번");

    }

    public void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            player.SetPlayerClass(new OneHandedAxClass());
            Debug.Log("직업 선택 완료");
        }
        if (Input.GetKeyDown("w"))
        {
            player.SetPlayerClass(new TwoHandedAxClass());
            Debug.Log("직업 선택 완료");
        }
        if (Input.GetKeyDown("e"))
        {
            player.SetPlayerClass(new PaladinClass());
            Debug.Log("직업 선택 완료");
        }
        if (Input.GetKeyDown("r"))
        {
            player.SetPlayerClass(new SamuraiClass());
            Debug.Log("직업 선택 완료");
        }

        if (Input.GetKeyDown("a"))
        {
            BattleStart();
        }
    }

    private void BattleStart()
    {
        Debug.Log("===============================");

        player.playerClass.Attack(monsterArr[monsterIndex]);
        monsterArr[monsterIndex].Attack(player);

        Debug.Log("===============================");
    }
}
