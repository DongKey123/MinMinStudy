using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchEnded : ITouchHandler
{
    public void OnTouchEnded(Vector2 touchPos);
}
