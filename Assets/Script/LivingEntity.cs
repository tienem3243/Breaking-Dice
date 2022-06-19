using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LivingEntity 
{
    void hit(Moster m,int dameBonus);
    void hit(LivingEntity m, int dameBonus);


    public void TakeDame(int dame);
}
public interface Monster
{
    void hitBy(Warrior warrior,int dame);
    void hitBy(Wizard wizard, int dame);
}
