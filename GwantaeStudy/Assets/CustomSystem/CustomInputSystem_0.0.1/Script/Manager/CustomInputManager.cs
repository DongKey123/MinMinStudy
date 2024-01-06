using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputManager
{
    private static CustomInputManager CustomInputMgr = null;
    public static CustomInputManager Instance
    {
        get
        {
            if (CustomInputMgr == null)
            {
                CustomInputMgr = new CustomInputManager();
            }

            return CustomInputMgr;
        }
    }
    private BaseTouchController touchController;

    public delegate void OnTouchDelegate();
    public OnTouchDelegate onTouchDele;

    public void ChangeTouchSystem(BaseTouchController _instance)
    {
        touchController = _instance;
        onTouchDele = touchController.OnTouch;
    }

    public void OnTouch()
    { 
        onTouchDele?.Invoke();
    }



    public void CombienAllTouchDelegate(BaseTouchController.TouchDelegate _beganTouchDele,
                                        BaseTouchController.TouchDelegate _movedTouchDele,
                                        BaseTouchController.TouchDelegate _endedTouchDele,
                                        BaseTouchController.TouchDelegate _stationaryTouchDele)
    {
        touchController.touchDelegateArr[(int)TouchPhase.Began] += _beganTouchDele;
        touchController.touchDelegateArr[(int)TouchPhase.Moved] += _movedTouchDele;
        touchController.touchDelegateArr[(int)TouchPhase.Ended] += _endedTouchDele;
        touchController.touchDelegateArr[(int)TouchPhase.Stationary] += _stationaryTouchDele;
    }
    public void CombienBeganTouchDelegate(BaseTouchController.TouchDelegate _beganTouchDele)
    {
        touchController.touchDelegateArr[(int)TouchPhase.Began] += _beganTouchDele;
    }
    public void CombienMovedTouchDelegate(BaseTouchController.TouchDelegate _movedTouchDele)
    {
        touchController.touchDelegateArr[(int)TouchPhase.Moved] += _movedTouchDele;
    }
    public void CombienEndedTouchDelegate(BaseTouchController.TouchDelegate _endedTouchDele)
    {
        touchController.touchDelegateArr[(int)TouchPhase.Ended] += _endedTouchDele;
    }
    public void CombienStationaryTouchDelegate(BaseTouchController.TouchDelegate _stationaryTouchDele)
    {
        touchController.touchDelegateArr[(int)TouchPhase.Stationary] += _stationaryTouchDele;
    }


    public void RemoveAllTouchDelegate()
    {
        int count = touchController.touchDelegateArr.Length;
        BaseTouchController.TouchDelegate[] delegateArr = touchController.touchDelegateArr;
        for (int i =0; i < count; i++)
        {
            delegateArr[i] = null;
        }
    }
    public void RemoveBeganTouchDelegate(BaseTouchController.TouchDelegate _beganTouchDele)
    {
        touchController.touchDelegateArr[(int)TouchPhase.Began] -= _beganTouchDele;
    }
    public void RemoveMovedTouchDelegate(BaseTouchController.TouchDelegate _movedTouchDele)
    {
        touchController.touchDelegateArr[(int)TouchPhase.Moved] -= _movedTouchDele;
    }
    public void RemoveEndedTouchDelegate(BaseTouchController.TouchDelegate _endedTouchDele)
    {
        touchController.touchDelegateArr[(int)TouchPhase.Ended] -= _endedTouchDele;
    }
    public void RemoveStationaryTouchDelegate(BaseTouchController.TouchDelegate _stationaryTouchDele)
    {
        touchController.touchDelegateArr[(int)TouchPhase.Stationary] -= _stationaryTouchDele;
    }


}
