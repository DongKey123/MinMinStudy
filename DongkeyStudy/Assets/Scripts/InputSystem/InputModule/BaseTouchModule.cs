using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTouchModule
{
    public struct TouchData
    {
        public TouchPhase phase;
        public Vector2 touchPos;
    }

    public virtual void Initialize()
    {

    }

    public virtual void Process()
    {
        
    }
}
