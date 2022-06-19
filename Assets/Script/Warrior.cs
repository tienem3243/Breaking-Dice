using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : CharacterClass, ILivingEntity
{
    [SerializeField] int shield;
    //dame receiver form each type monster, or dame type
    public void hit(Moster m,int dame)
    {
        m.hitBy(this,dame);
       
     }
    public void hit(ILivingEntity m, int dame)
    {
        m.hitBy(dame);
    }

    public void hitBy(int dame)
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

    public void hit(CharacterClass m, int dame)//just human race
    {
        m.Hp -= Atk;
    }
}
