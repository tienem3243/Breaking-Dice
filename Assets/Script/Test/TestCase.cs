using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCase : MonoBehaviour
{
    public GameObject a;

    [ContextMenu("test")]
    public void test()
    {
        a.GetComponent<Race>();
        Debug.Log(a);
    }
}
