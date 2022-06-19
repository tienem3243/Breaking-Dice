using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : CharacterClass, LivingEntity
{
    [SerializeField] int shield;
    //dame receiver form each type monster, or dame type
    public void hit(Moster m,int dame)
    {
        dame += this.Dame;
        m.hitBy(this,dame);
       
     }
    public void hit(LivingEntity m, int dame)
    {
        m.TakeDame(dame);
    }

    public void TakeDame(int dame)
    {
        int realdame = dame - shield;
        //descreesing dame by shield
        Debug.Log("Warrior take: " + dame + " reduced by shield: " + shield+" real damage: "+realdame);
        Hp -= realdame;
        Hp = Mathf.Clamp(Hp,0,100);//needfixed
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
