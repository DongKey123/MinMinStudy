using UnityEngine;

public interface ITouchMoved : ITouchHandler
{
    public void OnTocuhMoved(Vector2 touchPos);
}
