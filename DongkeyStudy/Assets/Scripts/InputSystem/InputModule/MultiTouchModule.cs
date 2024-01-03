using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouchModule : BaseTouchModule
{
    public delegate void OnTouchHandler(TouchData[] data);

    public OnTouchHandler handler;

    private TouchData[] touchData;

    public override void Process()
    {
        base.Process();

        int touchCount = Input.touchCount;

        touchData = new TouchData[touchCount];

        if (touchCount > 0)
        {
            for( int i = 0; i < touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Began)
                    Debug.Log($"{touch.phase}"+i);
                touchData[i].phase = touch.phase;
                touchData[i].touchPos = touch.position;
            }
            handler?.Invoke(touchData);
        }
    }
}
