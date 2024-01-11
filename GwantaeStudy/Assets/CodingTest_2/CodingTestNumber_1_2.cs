using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 13.	액션 RPG의 경우 (던파/철권/스트리트 파이트 등) 커맨드를 입력 받아 기술을 실행하는 로직들을 이용한다. 커맨드를 입력받아 최종 동작을 실행시키는 로직을 작성하시오 [25점]

public class CodingTestNumber_1_2 : MonoBehaviour
{
    private const float COMMAND_LIMIT = 0.5f;
    private CommandController commandCotroller = null;
    private float commandTimer = 0f;
    private bool isInput = false;

    public void Awake()
    {
        commandCotroller = new CommandController();
    }

    public void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            commandCotroller.AddMoveCommand(EMoveCommand.up);
            isInput = true;
        }
        if (Input.GetKeyDown("a"))
        {
            commandCotroller.AddMoveCommand(EMoveCommand.left);
            isInput = true;
        }
        if (Input.GetKeyDown("s"))
        {
            commandCotroller.AddMoveCommand(EMoveCommand.down);
            isInput = true;
        }
        if (Input.GetKeyDown("d"))
        {
            commandCotroller.AddMoveCommand(EMoveCommand.right);
            isInput = true;
        }
        if (Input.GetKeyDown("i"))
        {
            commandCotroller.InputAttackKey(EAttackKey.rightHand);
        }
        if (Input.GetKeyDown("o"))
        {
            commandCotroller.InputAttackKey(EAttackKey.leftHand);
        }
        if (Input.GetKeyDown("p"))
        {
            commandCotroller.InputAttackKey(EAttackKey.rightFoot);
        }


        if (isInput)
        {
            commandTimer += Time.deltaTime;
        }
        if(commandTimer > COMMAND_LIMIT)
        {
            commandCotroller.CarculateCommand();
            isInput = false;
            commandTimer = 0;
        }
    }

    private void OnDestroy()
    {
        commandCotroller = null;
    }
}

public enum EMoveCommand
{
    up = 0, // up
    left = 1, // left
    down = 2, // down
    right = 3, // right
}
public enum EAttackKey
{
    rightHand = 0, // right hand attck
    leftHand = 1, // left hand attack
    rightFoot = 2, // rigth foot attck

    none = 100,
}

// 대리자의 가능성도 생각을 해야 하는가?
public class CommandController
{
    private Queue<EMoveCommand> moveCommandQueue = null;
    private EAttackKey attackKey;
    private bool isInputAttack;
    private string commandString;

    public CommandController()
    {
        moveCommandQueue = new Queue<EMoveCommand>();
        isInputAttack = false;
        attackKey = EAttackKey.none;
    }

    public void AddMoveCommand(EMoveCommand _moveCommand)
    {
        moveCommandQueue.Enqueue(_moveCommand);
    }

    public void InputAttackKey(EAttackKey _attackKey)
    {
        isInputAttack = true;
        attackKey = _attackKey;

        if(moveCommandQueue.Count <= 1)
        {
            ExcuteAttack();
        }
    }

    public void CarculateCommand()
    {
        if (!isInputAttack)
        {
            Debug.Log("cancle Command");
            CancleCommand();
            return;
        }
        else if (moveCommandQueue.Count <= 1)
        {
            //ExcuteAttack();
        }
        else
        {
            ExcuteCommandAttack();
        }
    }

    private void ExcuteAttack()
    {
        Debug.Log(attackKey);
        attackKey = EAttackKey.none;
        isInputAttack = false;
        moveCommandQueue.Clear();
    }

    public void ExcuteCommandAttack()
    {
        int count = moveCommandQueue.Count;
        EMoveCommand movecommand;

        for(int i =0; i < count; i++)
        {
            movecommand = moveCommandQueue.Dequeue();

            if(movecommand == EMoveCommand.up)
            {
                commandString += "UP -> ";
            }
            if(movecommand == EMoveCommand.left)
            {
                commandString += "LEFT -> ";
            }
            if (movecommand == EMoveCommand.right)
            {
                commandString += "RIGHT -> ";
            }
            if (movecommand == EMoveCommand.down)
            {
                commandString += "DOWN -> ";
            }
        }

        Debug.Log(commandString + attackKey);

        attackKey = EAttackKey.none;
        isInputAttack = false;
        commandString = null;
        moveCommandQueue.Clear();
    }

    private void CancleCommand()
    {
        moveCommandQueue.Clear();
    }
    

    ~CommandController()
    {
        moveCommandQueue.Clear();
    }
}
