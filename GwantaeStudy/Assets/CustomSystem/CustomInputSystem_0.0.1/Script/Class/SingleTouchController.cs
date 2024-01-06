using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTouchController : BaseTouchController
{
    public override void OnTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
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
