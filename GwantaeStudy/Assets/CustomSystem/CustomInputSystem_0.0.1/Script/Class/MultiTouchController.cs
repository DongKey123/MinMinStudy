using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouchController : BaseTouchController
{
    public override void OnTouch()
    {
        int touchCount = Input.touchCount;
        for (int i = 0; i < touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            TouchPhase touchPhase = touch.phase;

            touchDelegateArr[(int)touchPhase]?.Invoke(touch);



            //switch (touchPhase)
            //{
            //    case TouchPhase.Began:
            //        beganTouchDele?.Invoke(touch);
            //        break;
            //    case TouchPhase.Moved:
            //        movedTouchDele?.Invoke(touch);
            //        break;
            //    case TouchPhase.Stationary:
            //        stationaryTouchDele?.Invoke(touch);
            //        break;
            //    case TouchPhase.Ended:
            //        endedTouchDele?.Invoke(touch);
            //        break;
            //}
        }
    }
}
