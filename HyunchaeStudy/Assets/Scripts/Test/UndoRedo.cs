using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	14.	데이터 Undo / Redo를 실행하는 로직을 작성하시오 [10점]

public class UndoRedo : MonoBehaviour
{
    private Stack<int> undoStack = new Stack<int>(10);
    private Stack<int> redoStack = new Stack<int>(10);

    public void InputKey(KeyCode _keyCode)
    {
        
        Debug.Log("Input : " + _keyCode + " " + (int)_keyCode);

        undoStack.Push((int)_keyCode);
    }

    public void Undo()
    {
        if(undoStack.Count == 0)
        {
            Debug.Log("UndoStack is Empty");
            return;
        }

        int undoData = undoStack.Pop();

        Debug.Log("Undo " + (KeyCode)undoData + " " + undoData);

        if(undoStack.Count >= 1)
        {
            Debug.Log("Cur Data : " + (KeyCode)undoStack.Peek() + " "+ undoStack.Peek());
        }
        else
        {
            Debug.Log("Cur Data is Null");
        }

        redoStack.Push(undoData);
    }


    public void Redo()
    {
        if(redoStack.Count == 0)
        {
            Debug.Log("RedoStack is Empty");
            return;
        }

        int redoData = redoStack.Pop();

        Debug.Log("Redo " + (KeyCode)redoData + " " + redoData);

        Debug.Log("Cur Data : " + (KeyCode)redoData + " " + redoData);

        undoStack.Push(redoData);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InputKey(KeyCode.Q);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            InputKey(KeyCode.W);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InputKey(KeyCode.E);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            InputKey(KeyCode.R);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Undo();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Redo();
        }
    }
}
