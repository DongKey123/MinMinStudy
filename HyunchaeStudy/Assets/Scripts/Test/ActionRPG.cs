using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	13.	액션 RPG의 경우 (던파/철권/스트리트 파이트 등) 커맨드를 입력 받아 기술을 실행하는 로직들을 이용한다. 커맨드를 입력받아 최종 동작을 실행시키는 로직을 작성하시오 [25점]

public class ActionRPG : MonoBehaviour
{
    private Queue<int> commandQueue = new Queue<int>(5);

    private const float COMMANDTIMELIMIT = 0.5f;
    private float curTime;

    private int[] skillCommandList = { 333, 334, 328};
    private int skillCommandCount;
    private bool isInput = false;

    private void Awake()
    {
        skillCommandCount = skillCommandList.Length;
    }

    public void InputCommand(KeyCode _commandNum)
    {
        if(commandQueue.Count == 0)
        {
            isInput = true;
            curTime = 0.0f;
        }


        commandQueue.Enqueue((int)_commandNum);

    }

    private void PlayCommand()
    {
        Debug.Log(commandQueue.Dequeue());

        if(commandQueue.Count == 0)
        {
            isInput = false;
            curTime = 0.0f;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            InputCommand(KeyCode.Q);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            InputCommand(KeyCode.W);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InputCommand(KeyCode.E);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            InputCommand(KeyCode.R);
        }

        if (isInput)
        {
            curTime += Time.deltaTime;
        }

        if (curTime >= COMMANDTIMELIMIT && commandQueue.Count >= 1)
        {
            CheckSkill();
            PlayCommand();

            curTime = 0.0f;
        }
    }

    private void CheckSkill()
    {
        int count = commandQueue.Count;

        Debug.Log(count);

        //세 개 이상의 커맨드를 입력했을 시 특정 기술이 나올 수 있다
        if(count >= 3)
        {
            int commandResult = 0;
            for(int i = 0; i < count; i++)
            {
                int command = commandQueue.Dequeue();
                commandResult += command;
                commandQueue.Enqueue(command);
            }

            for(int j = 0; j< skillCommandCount;j++)
            {
                if(commandResult == skillCommandList[j])
                {
                    commandQueue.Clear();
                    commandQueue.Enqueue(commandResult);
                }
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