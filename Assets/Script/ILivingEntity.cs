using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILivingEntity 
{
    void hit(ILivingEntity m, int bonusDame);//stat +bonus dame=realdame deal
    void hit(CharacterClass m, int bonusDame);
    public void hitBy(int dame);
}
public interface IMonster
{
    void hitBy(Warrior warrior,int dame);//just end dame taken
    void hitBy(Wizard wizard, int dame);
}

public interface IStatChange{
    public void Buff(StatEffect stat,int power);

    public void Debuff(StatEffect stat,int power);

}