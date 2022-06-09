using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Class, Human
{
    [SerializeField] string Charname = "wizard";
    [SerializeField]int magicForce;
    [SerializeField] string passive = "Magic Force: Deal addition damage equal Dice point";

    public string Charname1 { get => Charname; set => Charname = value; }

    public void hit(Moster m,int dame)
    {
        //adding dame
        dame += magicForce;
        m.hitBy(this,dame);
    }
    public void TakeDame(int dame)
    {
       Hp -= dame;
    }
}
