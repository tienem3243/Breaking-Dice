using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 1)]
public class Skill :ScriptableObject
{
    [SerializeField] int diceCost;
    [SerializeField] string skillName;
    [SerializeField] string descript;

    public int DiceCost { get => diceCost; set => diceCost = value; }
    public string Name { get => name; set => name = value; }
    public string Descript { get => descript; set => descript = value; }
}
