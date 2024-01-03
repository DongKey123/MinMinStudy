using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Toggle touchToggle = null;
    [SerializeField] private RectTransform singleTouchObject = null;

    [SerializeField] private RectTransform[] multiTouchObject = null;


    private CustomInputManager customInputMgr = null;

    private List<RectTransform> multiTouchList = new List<RectTransform>();

    private int count = 0;

    private void Awake()
    {
        touchToggle.onValueChanged.AddListener(OnValueChangeToggled);

        customInputMgr = CustomInputManager.Instance;
        customInputMgr.OnSingleTouchBegin += OnSingleTouchBegin;
        customInputMgr.OnSingleTouchMoved += OnSingleTouchMoved;
        customInputMgr.OnSingleTouchEnded += OnSingleTouchEnded;

        customInputMgr.OnMultiTouchBegin += OnMultiTouchBegin;
        customInputMgr.OnMultiTouchMoved += OnMultiTouchMoved;
        customInputMgr.OnMultiTouchEnded += OnMultiTouchEnded;
    }

    

    

    

    private void OnSingleTouchBegin(Vector2 pos)
    {
        singleTouchObject.position = pos;
        singleTouchObject.gameObject.SetActive(true);
    }

    private void OnSingleTouchMoved(Vector2 pos)
    {
        singleTouchObject.position = pos;
    }

    private void OnSingleTouchEnded(Vector2 pos)
    {
        singleTouchObject.position = pos;
        singleTouchObject.gameObject.SetActive(false);
    }


    private void OnMultiTouchBegin(int index, Vector2 pos)
    {
        count++;
        Debug.Log("Count: " + count);
    }

    private void OnMultiTouchMoved(int index, Vector2 pos)
    {
        multiTouchObject[index].position = pos;
    }

    private void OnMultiTouchEnded(int index, Vector2 pos)
    {
        count--;
        Debug.Log("Count: " + count);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        customInputMgr.Process();
    }

    private void OnValueChangeToggled(bool isOn)
    {
        customInputMgr.isMultiTouch = isOn;
        if (isOn)
        {
            singleTouchObject.gameObject.SetActive(false);
        }
        else
        {
            foreach(var obj in multiTouchObject)
            {
                obj.gameObject.SetActive(false);
            }
        }
    }
}
