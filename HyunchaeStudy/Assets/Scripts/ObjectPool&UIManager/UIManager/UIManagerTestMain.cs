using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerTestMain : MonoBehaviour
{
    private UIManager uiManager = UIManager.instance;

    private string onefilePath = "Prefabs/UIOne";
    private string twofilePath = "Prefabs/UITwo";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            uiManager.Show<UIOne>(onefilePath);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            uiManager.Show<UITwo>(twofilePath);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            uiManager.Hide();
        }
    }
}
