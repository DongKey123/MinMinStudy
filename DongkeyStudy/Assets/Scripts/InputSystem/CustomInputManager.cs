using System;
using UnityEngine;

public class CustomInputManager
{
    public bool isMultiTouch = false;

    public delegate void OnTouchHandler(Vector2 pos);
    public event OnTouchHandler OnSingleTouchBegin;
    public event OnTouchHandler OnSingleTouchMoved;
    public event OnTouchHandler OnSingleTouchEnded;

    public delegate void OnMultiTouchHandler(int index,Vector2 pos);
    public event OnMultiTouchHandler OnMultiTouchBegin;
    public event OnMultiTouchHandler OnMultiTouchMoved;
    public event OnMultiTouchHandler OnMultiTouchEnded;

    public SingleTouchModule singleTouchModule = null;
    public MultiTouchModule multiTouchModule = null;

    private static CustomInputManager customInputManager;
    public static CustomInputManager Instance
    {
        get
        {
            if (customInputManager == null)
            {
                customInputManager = new CustomInputManager();
            }
            return customInputManager;
        }

    }

    private CustomInputManager()
    {
        Initialize();
    }

    private void Initialize()
    {
        singleTouchModule = new SingleTouchModule();
        singleTouchModule.handler = ProcessSingleTouch;
        multiTouchModule = new MultiTouchModule();
        multiTouchModule.handler = ProcessMultiTouch;
    }

    public void Process()
    {
        if(isMultiTouch)
        {
            multiTouchModule.Process();
        }
        else
        {
            singleTouchModule.Process();
        }
    }

    private void ProcessSingleTouch(BaseTouchModule.TouchData touchData)
    {
        if(touchData.phase == TouchPhase.Began)
        {
            OnSingleTouchBegin?.Invoke(touchData.touchPos);
        }
        else if (touchData.phase == TouchPhase.Moved)
        {
            OnSingleTouchMoved?.Invoke(touchData.touchPos);
        }
        else if (touchData.phase == TouchPhase.Ended)
        {
            OnSingleTouchEnded?.Invoke(touchData.touchPos);
        }
    }

    private void ProcessMultiTouch(BaseTouchModule.TouchData[] touchData)
    {
        int count = touchData.Length;

        for (int i =0; i < count; i++)
        {
            if (touchData[i].phase == TouchPhase.Began)
            {
                OnMultiTouchBegin?.Invoke(i, touchData[i].touchPos);
            }
            else if (touchData[i].phase == TouchPhase.Moved)
            {
                OnMultiTouchMoved?.Invoke(i, touchData[i].touchPos);
            }
            else if (touchData[i].phase == TouchPhase.Ended)
            {
                OnMultiTouchEnded?.Invoke(i, touchData[i].touchPos);
            }
        }
        
    }
}
