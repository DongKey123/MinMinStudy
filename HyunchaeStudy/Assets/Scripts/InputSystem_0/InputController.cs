using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private InputManager inputManager;

    private bool isSingleTouch = true;

    [SerializeField] private Button isSingleButton;
    [SerializeField] private GameObject[] touchImages;
    private TextMeshProUGUI[] touchTexts;
    private TextMeshProUGUI isSingleText;

    private void Awake()
    {
        inputManager = InputManager.instance;

        isSingleText = isSingleButton.GetComponentInChildren<TextMeshProUGUI>();
        isSingleButton.onClick.AddListener(OnClickSwapBtn);

        int imagesLength = touchImages.Length;

        touchTexts = new TextMeshProUGUI[imagesLength];

        for(int i = 0; i < imagesLength; i++)
        {
            touchTexts[i] = touchImages[i].GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        inputManager.SwapTouchCtrl(new SingleTouchController());
        inputManager.SetDelegate(OnTouch);
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            inputManager.OnTouch();
        }
    }

    private void OnClickSwapBtn()
    {
        isSingleTouch = !isSingleTouch;
        BaseTouchController touchController;

        if(isSingleTouch)
        {
            isSingleText.text = "Single";
            touchController = new SingleTouchController();
        }
        else
        {
            isSingleText.text = "Multi";
            touchController = new MultiTouchController();
        }

        inputManager.SwapTouchCtrl(touchController);
        inputManager.SetDelegate(OnTouch);
    }

    private void OnTouch(Touch _touch)
    {
        int touchIndex = _touch.fingerId;
            if (_touch.phase == TouchPhase.Ended)
            {
                touchImages[touchIndex].SetActive(false);
                return;
            }
            else if (_touch.phase == TouchPhase.Began)
            {
                touchImages[touchIndex].SetActive(true);
            touchImages[touchIndex].transform.position = _touch.position;
            touchTexts[touchIndex].text = touchIndex + "\n" + _touch.position;
        }
            else if(_touch.phase == TouchPhase.Moved)
        {
            touchImages[touchIndex].transform.position = _touch.position;
            touchTexts[touchIndex].text = touchIndex + "\n" + _touch.position;
        }
        
    }
}
