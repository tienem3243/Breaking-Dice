using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : CharacterClass, LivingEntity
{
    [SerializeField] string Charname = "wizard";
    [SerializeField]int magicForce;
    [SerializeField] string passive = "Magic Force: Deal addition damage equal Dice point";

    public string Charname1 { get => Charname; set => Charname = value; }

    public void hit(Moster m,int dame)
    {
        //adding dame
        dame +=this.Dame+ magicForce;
        m.hitBy(this,dame);
    }
    public void hit(LivingEntity m, int dame)
    {
        //adding dame
        dame +=this.Dame+ magicForce;
        m.TakeDame(dame);
    }
    public void TakeDame(int dame)
    {
       Hp -= dame;
    }
}
