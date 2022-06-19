using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : CharacterClass, ILivingEntity
{
    [SerializeField] string Charname = "wizard";
    [SerializeField]int magicForce;
    [SerializeField] string passive = "Magic Force: Deal addition damage equal Dice point";

    public string Charname1 { get => Charname; set => Charname = value; }

    public void hit(ILivingEntity m, int realDame)//all race
    {
        //adding dame
        
        realDame +=this.Atk+ magicForce;
        m.hitBy(realDame);
        Debug.Log(Charname + " deal bonus " + magicForce + " total: " +realDame);
    }

    public void hit(CharacterClass m, int dame)//just human race
    {
        m.Hp -= Atk;
    }

    public void hitBy(int dame)
    {
       Hp -= dame;
    }
}
