using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPractice : MonoBehaviour
{
    [Header("Debug Test")]
    [SerializeField] private Text touchText;
    [SerializeField] private Toggle isMultiTouchToggle;
    [SerializeField] private GameObject[] touchObjects;

    private void Update()
    {
        if (isMultiTouchToggle.isOn)
        {
            OnMultiTouch();
        }
        else
        {
            OnSingleTouch();
        }
    }

    private void OnSingleTouch()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                touchText.text = "Touch Began";
                touchObjects[0].transform.position = touch.position;
                touchObjects[0].SetActive(true);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                touchText.text = "Touch Ended";
                touchObjects[0].SetActive(false);
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                touchText.text = touch.position.ToString();
                touchObjects[0].transform.position = touch.position;
            }
        }
    }

    private void OnMultiTouch()
    {
        int touchCount = Input.touchCount;
        if(touchCount > 0)
        {
            for(int i =0; i < touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                int index = touch.fingerId;
                Vector2 pos = touch.position;
                TouchPhase touchPhase = touch.phase;
                GameObject touchObject = touchObjects[index];

                if (touchPhase == TouchPhase.Began)
                {
                    touchObject.transform.position = pos;
                    touchObject.SetActive(true);
                }
                else if(touchPhase == TouchPhase.Moved)
                {
                    touchObject.transform.position = pos;
                }
                else if(touchPhase == TouchPhase.Ended)
                {
                    touchObject.SetActive(false);
                }
            }
        }
    }
}
