using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTouchController : MonoBehaviour
{
    [Header("Debug Test")]
    [SerializeField] private Text touchText;
    [SerializeField] private Toggle isMultiTouchToggle;
    [SerializeField] private GameObject[] touchObjects;

    private CustomInputManager inputMgr;

    private void Awake()
    {
        inputMgr = CustomInputManager.Instance;
    }

    private void Start()
    {
        isMultiTouchToggle.onValueChanged.AddListener(OnClickToggle);
        OnClickToggle(false);
    }

    private void Update()
    {
        inputMgr?.OnTouch();
    }


    private void OnClickToggle(bool _isMulti)
    {
        Debug.Log(_isMulti);

        inputMgr.ChangeTouchSystem(_isMulti ? new MultiTouchController() : new SingleTouchController());

        inputMgr.RemoveAllTouchDelegate();

        if (_isMulti)
        {
            inputMgr.CombienAllTouchDelegate(BeganMultiTouch, MovedMultiTouch, EndedMultiTouch, StationaryMultiTouch);
        }
        else
        {
            inputMgr.CombienAllTouchDelegate(BeganSingleTouch, MovedSingleTouch, EndedSingleTouch, StationarySingleTouch);
        }
    }


    private void BeganSingleTouch(Touch _touch)
    {
        touchObjects[0].transform.position = _touch.position;
        touchObjects[0].SetActive(true);
    }
    private void MovedSingleTouch(Touch _touch)
    {
        touchText.text = _touch.position.ToString();
        touchObjects[0].transform.position = _touch.position;
    }
    private void StationarySingleTouch(Touch _touch)
    {
        touchObjects[0].transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }
    private void EndedSingleTouch(Touch _touch)
    {
        touchText.text = "Touch Ended";
        touchObjects[0].transform.localScale = new Vector3(1, 1, 1);
        touchObjects[0].SetActive(false);
    }


    private void BeganMultiTouch(Touch _touch)
    {
        int idx = _touch.fingerId;
        touchObjects[idx].transform.position = _touch.position;
        touchObjects[idx].SetActive(true);
    }
    private void MovedMultiTouch(Touch _touch)
    {
        touchObjects[_touch.fingerId].transform.position = _touch.position;
    }
    private void StationaryMultiTouch(Touch _touch)
    {
        touchObjects[_touch.fingerId].transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }
    private void EndedMultiTouch(Touch _touch)
    {
        touchObjects[_touch.fingerId].transform.localScale = new Vector3(1, 1, 1);
        touchObjects[_touch.fingerId].SetActive(false);
    }

}
