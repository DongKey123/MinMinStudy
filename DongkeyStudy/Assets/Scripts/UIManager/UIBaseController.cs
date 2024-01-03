using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(GraphicRaycaster))]
public abstract class UIBaseController : MonoBehaviour , IPanel
{
    public virtual void Initialize()
    {
        canvas = this.GetComponent<Canvas>();
        raycaster = this.GetComponent<GraphicRaycaster>();
    }


    protected Canvas canvas;
    protected GraphicRaycaster raycaster;
    
    //Todo: Internal 로 UIManager에서만 접근 하도록 해야 할 거 같은데
    public virtual void Show()
    {
        canvas.enabled = true;
        raycaster.enabled = true;
    }

    public virtual void Back()
    {
    }

    public virtual void Hide()
    {
        canvas.enabled = false;
        raycaster.enabled = false;
    }

    public virtual bool IsShow()
    {
        return canvas.enabled; 
    }

    public void SetSortingOrder(int order)
    {
        canvas.sortingOrder = order;
    }

    public virtual void UpdateUI()
    {

    }

}
