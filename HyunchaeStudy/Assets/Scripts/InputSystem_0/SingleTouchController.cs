using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTouchController : BaseTouchController
{
    int singleTouchIndex = 0;

    public override void OnTouch()
    {
        Touch touch = Input.GetTouch(singleTouchIndex);

        onTouchDelegate.Invoke(touch);
    }

}
