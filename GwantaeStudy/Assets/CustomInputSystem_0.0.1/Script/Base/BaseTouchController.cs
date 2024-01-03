using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTouchController
{
    public delegate void TouchDelegate(Touch _touch);
    public TouchDelegate[] touchDelegateArr = new TouchDelegate[5];
    private TouchDelegate beganTouchDele;
    private TouchDelegate movedTouchDele;
    private TouchDelegate stationaryTouchDele;
    private TouchDelegate endedTouchDele;
    private TouchDelegate cancledTouchDele;

    public BaseTouchController()
    {
        touchDelegateArr[(int)TouchPhase.Began] = beganTouchDele;
        touchDelegateArr[(int)TouchPhase.Moved] = movedTouchDele;
        touchDelegateArr[(int)TouchPhase.Stationary] = stationaryTouchDele;
        touchDelegateArr[(int)TouchPhase.Ended] = endedTouchDele;
        touchDelegateArr[(int)TouchPhase.Canceled] = cancledTouchDele;
    }

    public abstract void OnTouch();
}
