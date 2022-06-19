using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    [SerializeField] private string classname;
    [SerializeField] private Skill[] abilityList;
    [SerializeField] int hp, dame, speed;
    [SerializeField] Item[] items;
   
    public CharacterClass()
    {
    }
    public CharacterClass(string classname, Skill[] abilityList, int hp, int dame, int speed, Item[] items)
    {
        this.classname = classname;
        this.abilityList = abilityList;
        this.hp = hp;
        this.dame = dame;
        this.speed = speed;
        this.items = items;
    }

    public string Classname { get => classname; set => classname = value; }
    public Skill[] AbilityList { get => abilityList; set => abilityList = value; }
    public int Hp { get => hp; set => hp = value; }
    public int Dame { get => dame; set => dame = value; }
    public Item[] Items { get => items; set => items = value; }
    public int Speed { get => speed; set => speed = value; }
  
}
