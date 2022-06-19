using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour,IStatChange
{
    [SerializeField] private string classname;
    [SerializeField] private AbilityStat[] abilityList;
    [SerializeField] int hp, atk, speed;
    [SerializeField] Item[] items;
   
    public CharacterClass()
    {
    }
    public CharacterClass(string classname, AbilityStat[] abilityList, int hp, int dame, int speed, Item[] items)
    {
        this.classname = classname;
        this.abilityList = abilityList;
        this.hp = hp;
        this.atk = dame;
        this.speed = speed;
        this.items = items;
    }

    public string Classname { get => classname; set => classname = value; }
    public AbilityStat[] AbilityList { get => abilityList; set => abilityList = value; }
    public int Hp { get => hp; set => hp = value; }
    public int Atk { get => atk; set => atk = value; }
    public Item[] Items { get => items; set => items = value; }
    public int Speed { get => speed; set => speed = value; }

    public void Buff(StatEffect stat,int power)
    {
        switch (stat)
        {
            case StatEffect.atk:
                Atk += power;
                break;
            case StatEffect.spd:
                Speed += power;
                break;
            case StatEffect.health:
                Hp += power;
                break;
        }
            
        
    }
}
