using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private static InputManager inputManager;
    public static InputManager instance
    {
        get
        {
            if(inputManager == null)
            {
                inputManager = new InputManager();
            }

            return inputManager;
        }
    }

    private BaseTouchController touchCtrl;

    public void OnTouch()
    {
        touchCtrl.OnTouch();
    }

    public void SwapTouchCtrl(BaseTouchController _newTouchController)
    {
        touchCtrl = _newTouchController;
    }

    public void SetDelegate(BaseTouchController.touchDelegate _touchDele)
    {
        touchCtrl.SetDelegate(_touchDele);
    }
}
