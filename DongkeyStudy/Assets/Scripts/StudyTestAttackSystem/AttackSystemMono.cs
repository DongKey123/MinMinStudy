using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttackSystem;

public class AttackSystemMono : MonoBehaviour
{
    [SerializeField]
    [Range(0, 4)]
    private int unitClassIndex = 0;

    [SerializeField]
    [Range(0, 9)]
    private int monsterGenerateIndex = 0;


    private PlayerClass player = null;
    private BaseMonster monster = null;
    private BattleController battleSystem = null;

    private void Awake()
    {
        battleSystem = new BattleController();
        player = GenerateUnit();
        monster = GenerateMonster();
        player.Initialize(battleSystem);
        battleSystem.GenerateMonster(monster);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            player.Attack();
        }
    }

    private PlayerClass GenerateUnit()
    {
        if( unitClassIndex == 0)
        {
            return new Warrior();
        }
        else if(unitClassIndex == 1)
        {
            return new Magician();
        }
        else if (unitClassIndex == 2)
        {
            return new Archer();
        }
        else if (unitClassIndex == 3)
        {
            return new Monk();
        }
        return null;
    }

    private BaseMonster GenerateMonster()
    {
        if ( monsterGenerateIndex == 0)
        {
            return new Dragon();
        }
        else if (monsterGenerateIndex == 1)
        {
            return new Griffin();
        }
        else if (monsterGenerateIndex == 2)
        {
            return new Harpy();
        }
        else if (monsterGenerateIndex == 3)
        {
            return new Ork();
        }
        else if (monsterGenerateIndex == 4)
        {
            return new Troll();
        }
        else if (monsterGenerateIndex == 5)
        {
            return new Goblin();
        }
        else if (monsterGenerateIndex == 6)
        {
            return new Naga();
        }
        else if (monsterGenerateIndex == 7)
        {
            return new Kraken();
        }
        else if (monsterGenerateIndex == 8)
        {
            return new Frog();
        }

        return null;
    }
}
