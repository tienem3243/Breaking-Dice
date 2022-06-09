using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCase : MonoBehaviour
{
    public  Class character;
    public Moster Oponent;

    [ContextMenu("test")]
    public void test()
    {
        character.gameObject.GetComponent<Wizard>().hit(Oponent,3);
        Debug.Log(character.name+" attack"+Oponent.name);
    }
}
