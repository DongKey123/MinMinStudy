using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	13.	액션 RPG의 경우 (던파/철권/스트리트 파이트 등) 커맨드를 입력 받아 기술을 실행하는 로직들을 이용한다. 커맨드를 입력받아 최종 동작을 실행시키는 로직을 작성하시오 [25점]

public class ActionRPG : MonoBehaviour
{
    private Queue<int> actionCommandQueue = new Queue<int>(5);
    private Queue<int> moveCommandQueue = new Queue<int>(5);

    private const float COMMANDTIMELIMIT = 0.5f;

    private float moveTime;
    private float actionTime;

    private int[] skillCommandList = { 664, 334, 328};
    private int skillCommandCount;
    private bool isActionInput = false;
    private bool isMoveInput = false;
    private bool isSkillCommand = false;

    private void Awake()
    {
        skillCommandCount = skillCommandList.Length;
    }

    public void InputActionCommand(KeyCode _commandNum)
    {
        Debug.Log(moveCommandQueue.Count);

        if(actionCommandQueue.Count == 0)
        {
            isActionInput = true;
            actionTime = 0.0f;
        }

        if(moveCommandQueue.Count >= 1)
        {
            isSkillCommand = true;
        }

        actionCommandQueue.Enqueue((int)_commandNum);

        Debug.Log(isSkillCommand);
    }

    public void InputMoveCommand(KeyCode _commandNum)
    {
        if(moveCommandQueue.Count == 0)
        {
            isMoveInput = true;
            moveTime = 0.0f;
        }

        moveCommandQueue.Enqueue((int)_commandNum);
    }

    private void PlayCommand()
    {
        Debug.Log(actionCommandQueue.Dequeue() + "번 액션 실행");

        if(actionCommandQueue.Count == 0 && moveCommandQueue.Count == 0)
        {
            isActionInput = false;
            actionTime = 0.0f;
        }
    }

    private void Update()
    {
        CheckMoveInput();
        CheckActionInput();

        if(isMoveInput)
        {
            moveTime += Time.deltaTime;
        }

        if (isActionInput)
        {
            actionTime += Time.deltaTime;
        }

        // 이동 키의 입력과 액션 키의 입력이 모두 있을 때
        if(moveTime >= COMMANDTIMELIMIT && isSkillCommand)
        {
            CheckSkill();
            PlayCommand();

            moveTime = 0.0f;
            isSkillCommand = false;
        }
        else if (actionTime >= COMMANDTIMELIMIT && actionCommandQueue.Count >= 1)
        {
            PlayCommand();
        }

        // 이동 키만 누를 때
        if (moveTime >= COMMANDTIMELIMIT && moveCommandQueue.Count >= 1)
        {
            //캐릭터 이동
            //move();

            Debug.Log("이동 : " + moveCommandQueue.Dequeue());
            moveTime = 0.0f;
            if (moveCommandQueue.Count == 0)
            {
                isMoveInput = false;
            }
        }
    }

    private void CheckActionInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InputActionCommand(KeyCode.Q);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            InputActionCommand(KeyCode.W);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InputActionCommand(KeyCode.E);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            InputActionCommand(KeyCode.R);
        }
    }
    private void CheckMoveInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            InputMoveCommand(KeyCode.LeftArrow);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            InputMoveCommand(KeyCode.RightArrow);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            InputMoveCommand(KeyCode.UpArrow);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            InputMoveCommand(KeyCode.DownArrow);
        }
    }

    private void CheckSkill()
    {
        int moveCount = moveCommandQueue.Count;
        int actionCount = actionCommandQueue.Count;

        int commandResult = 0;

        for (int k = 0; k < moveCount; k++)
        {
            int command = moveCommandQueue.Dequeue();
            commandResult += command;
            moveCommandQueue.Enqueue(command);
        }

        for (int i = 0; i < actionCount; i++)
        {
            int command = actionCommandQueue.Dequeue();
            commandResult += command;
            actionCommandQueue.Enqueue(command);
        }

        for (int j = 0; j < skillCommandCount; j++)
        {
            if (commandResult == skillCommandList[j])
            {
                moveCommandQueue.Clear();
                actionCommandQueue.Clear();
                actionCommandQueue.Enqueue(commandResult);

                Debug.Log(j + "번 스킬 커맨드 입력 커맨드 값 : " + skillCommandList[j]);
            }
        }

    }
}

/*
 * 커맨드 순서대로 진행해야함 (큐)
 * 연속적으로 입력될 경우 입력을 모두 받아 하나의 기술로서 사용해야함 (if 를 통해 해당 커맨드 체크)
 * 입력되지 않을 경우 단순 기술이 나와야함 (시간 경과 확인 후 데큐)
 * 일정 시간 내로 연속적인 입력을 했을 시 하나의 기술이 될 수 있는지를 체크해야함 - 기술이 될 수 없다면 단순 기술로 나와야함 ( 시간 경과를 통해 입력을 받을 시 연산)
 * 
 */