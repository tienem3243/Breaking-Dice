using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Class, Human
{
    [SerializeField] int shield;
    //dame receiver form each type monster, or dame type
    public void hit(Moster m,int dame)
    {
        m.hitBy(this,dame);
       
     }

   
    public void TakeDame(int dame)
    {
        //descreesing dame by shield
        Hp -= dame-shield;
    }
    public void setHp(int hp)
    {
        Hp = hp;
    }
    public int getHp()
    {
        return Hp;
    }

}
