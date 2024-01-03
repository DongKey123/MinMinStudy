using UnityEngine;

public interface ITouchBegin : ITouchHandler
{
    public void OnTocuhBegin(Vector2 touchPos);
}
