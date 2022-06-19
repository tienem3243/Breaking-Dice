using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Race 
{
    void hit(Moster m,int dame);
    void hit(Race m, int dame);


    public void TakeDame(int dame);
}
public interface Monster
{
    void hitBy(Warrior warrior,int dame);
    void hitBy(Wizard wizard, int dame);
}
