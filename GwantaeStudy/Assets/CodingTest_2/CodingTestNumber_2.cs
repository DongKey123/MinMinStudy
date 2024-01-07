using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 데이터 Undo / Redo를 실행하는 로직을 작성하시오

public class CodingTestNumber_2 : MonoBehaviour
{
    private int tempData = 1;
    private UndoRedoController undoRedoController;

    private void Awake()
    {
        undoRedoController = new UndoRedoController();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Debug.Log("add temp data");
            undoRedoController.AddData(tempData);
            tempData++;
            Debug.Log("Show now data = " + undoRedoController.ShowLastData());
        }
        if (Input.GetKeyDown("u"))
        {
            Debug.Log("undo data");
            undoRedoController.Undo();
            Debug.Log("Show now data = " + undoRedoController.ShowLastData());
        }
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("redo data");
            undoRedoController.Redo();
            Debug.Log("Show now data = " + undoRedoController.ShowLastData());
        }
    }
}

public class UndoRedoController
{
    private Stack<int> undoStack = null;
    private Stack<int> redoStack = null;

    public UndoRedoController()
    {
        undoStack = new Stack<int>();
        redoStack = new Stack<int>();
    }

    public void AddData(int _data)
    {
        undoStack.Push(_data);
        redoStack.Clear();
    }

    public void Undo()
    {
        if(undoStack.Count == 0)
        {
            Debug.Log(" you dont Undo dataStack is null");
            return;
        }

        redoStack.Push(undoStack.Pop());
    }

    public void Redo()
    {
        if (redoStack.Count == 0)
        {
            Debug.Log(" you dont Redo dataStack is null");
            return;
        }

        undoStack.Push(redoStack.Pop());
    }

    public int ShowLastData()
    {
        return undoStack.Peek();
    }
}
