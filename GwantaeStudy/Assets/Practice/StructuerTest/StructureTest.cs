using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATest
{
    public ATest(int _aa)
    {
        aa = _aa;
    }
    public int aa;
}
public class StructureTest : MonoBehaviour
{
    private int[] intarr = new int[3] {1,2,3};
    private ATest[] classarr = new ATest[3] { new ATest(1), new ATest(2), new ATest(3) };

    // Start is called before the first frame update
    void Start()
    {
        int a = intarr[2];
        a = 4;
        Debug.Log(intarr[2]);

        ATest atest = classarr[2];
        Debug.Log(classarr[0].aa);
        Debug.Log(classarr[1].aa);
        Debug.Log(classarr[2].aa);

        Debug.Log(atest.aa);
        atest.aa = 5;

        Debug.Log(classarr[0].aa);
        Debug.Log(classarr[1].aa);
        Debug.Log(classarr[2].aa);
    }

}
