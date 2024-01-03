using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTouchModule : BaseTouchModule
{
    public delegate void OnTouchHandler(TouchData data);

    public OnTouchHandler handler;

    private TouchData touchData;

    public override void Initialize()
    {
        base.Initialize();
    }


    public override void Process()
    {
        base.Process();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchData.phase = touch.phase;
            touchData.touchPos = touch.position;

            handler?.Invoke(touchData);
        }
    }
}
