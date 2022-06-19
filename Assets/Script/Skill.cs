using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FieldEffect { front, back, all }
public enum TargetAble { enermy, player, all, self }
public enum AbilityType {buff,heal,debuff,atk,move}
[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 1)]
public class Skill :ScriptableObject
{
    [SerializeField] int diceCost,targetCount,power;
    [SerializeField] string skillName;
    [SerializeField] string descript;
    [SerializeField] FieldEffect field;
    [SerializeField] TargetAble target;
    [SerializeField] AbilityType abilityType;

    public int DiceCost { get => diceCost; set => diceCost = value; }
    public int TargetCount { get => targetCount; set => targetCount = value; }
    public string SkillName { get => skillName; set => skillName = value; }
    public string Descript { get => descript; set => descript = value; }
    public FieldEffect Field { get => field; set => field = value; }
    public TargetAble Target { get => target; set => target = value; }
    public AbilityType AbilityType { get => abilityType; set => abilityType = value; }
    public virtual void Use() { }
}
