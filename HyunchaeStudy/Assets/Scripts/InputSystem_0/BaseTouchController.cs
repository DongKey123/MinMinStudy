using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTouchController
{
    public delegate void touchDelegate(Touch _touch);

    protected touchDelegate onTouchDelegate;

    public touchDelegate GetOnTouchDele() => onTouchDelegate;

    public void SetDelegate(touchDelegate _touchDele)
    {
        onTouchDelegate = _touchDele;
    }

    public abstract void OnTouch();
}
