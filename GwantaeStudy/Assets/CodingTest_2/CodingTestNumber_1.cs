using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 13.	액션 RPG의 경우 (던파/철권/스트리트 파이트 등) 커맨드를 입력 받아 기술을 실행하는 로직들을 이용한다. 커맨드를 입력받아 최종 동작을 실행시키는 로직을 작성하시오 [25점]

public class CodingTestNumber_1 : MonoBehaviour
{
    private PlayerComendController playerComendController;

    private void Awake()
    {
        playerComendController = new PlayerComendController();
    }
    private void Start()
    {
        Debug.Log("Plaese push key qwer");
    }
    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            playerComendController.PushKey1();
        }
        if (Input.GetKeyDown("w"))
        {
            playerComendController.PushKey2();
        }
        if (Input.GetKeyDown("e"))
        {
            playerComendController.PushKey3();
        }
        if (Input.GetKeyDown("r"))
        {
            playerComendController.PushKey4();
        }
        if (Input.GetKeyDown("a"))
        {
            playerComendController.ComendCarculate();
            Debug.Log("comend value is = " + playerComendController.GetComend());
            playerComendController.ClearComendBitFlag();
        }
    }
}

public enum EKEY_BIT_FLAG
{
    key1 = 0x01 << 1,
    key2 = 0x01 << 2,
    key3 = 0x01 << 3,
    key4 = 0x01 << 4,
}
public class PlayerComendController
{
    private int comendBitFlag = 1;
    private int bitMask = 0x01 << 0;
    private Queue<int> comendQueue = new Queue<int>();

    public void PushKey1()
    {
        Debug.Log("you pushed 1 key");
        comendQueue.Enqueue((int)EKEY_BIT_FLAG.key1);
    }

    public void PushKey2()
    {
        Debug.Log("you pushed 2 key");
        comendQueue.Enqueue((int)EKEY_BIT_FLAG.key2);
    }

    public void PushKey3()
    {
        Debug.Log("you pushed 3 key");
        comendQueue.Enqueue((int)EKEY_BIT_FLAG.key3);
    }

    public void PushKey4()
    {
        Debug.Log("you pushed 4 key");
        comendQueue.Enqueue((int)EKEY_BIT_FLAG.key4);
    }

    public void ComendCarculate()
    {
        int count = comendQueue.Count;
        int fristValue = 0;
        for(int i =0; i < count; i++)
        {
            if(i == 0)
            {
                fristValue = comendQueue.Dequeue();
                Debug.Log("frist push key value = " + fristValue);
                comendBitFlag |= fristValue;
                Debug.Log("comend value = " + comendBitFlag);
            }
            else
            {
                comendBitFlag |= comendQueue.Dequeue();
                Debug.Log("comend value = " + comendBitFlag);
            }
        }

        comendBitFlag = comendBitFlag << fristValue;
    }

    public int FindFristKey()
    {
        int counter = 0;
        while (true)
        {
            counter++;
            comendBitFlag = comendBitFlag >> 1;
            // 비트마스크와 값이 동일해 졌을 때 counter의 숫자로 첫 번째 커맨드가 뭔지 판별한다.
        }
    }

    public int GetComend()
    {
        return comendBitFlag;
    }

    public void ClearComendBitFlag()
    {
        comendBitFlag = 1;
    }
}
