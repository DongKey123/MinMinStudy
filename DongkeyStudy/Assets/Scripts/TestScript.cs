using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Stack<int> a = new Stack<int>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < 4; i++)
        {
            a.Push(i);
        }

        var k = a.Peek();
        Debug.Log(k);
        k = 1;
        Debug.Log(k);

        Debug.Log(a.Peek());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
