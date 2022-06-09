using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{
    [SerializeField] private string classname;
    [SerializeField] private Skill[] abilityList;
    [SerializeField] int hp;
    [SerializeField] int dame;
    [SerializeField] Item[] items;

    public string Classname { get => classname; set => classname = value; }
    public Skill[] AbilityList { get => abilityList; set => abilityList = value; }
    public int Hp { get => hp; set => hp = value; }
    public int Dame { get => dame; set => dame = value; }
    public Item[] Items { get => items; set => items = value; }
}
