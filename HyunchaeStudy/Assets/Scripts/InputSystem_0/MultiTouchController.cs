using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouchController : BaseTouchController
{
    public override void OnTouch()
    {
        int touchCount = Input.touchCount;

        for(int i = 0; i < touchCount; i ++)
        {
            Touch touch = Input.GetTouch(i);
            onTouchDelegate.Invoke(touch);
        }
    }
}
