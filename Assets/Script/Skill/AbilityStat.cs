using UnityEngine;

public enum FieldEffect { front, back, all }
public enum TargetAble { enermy, player, all, self }
public enum AbilityType {buff,heal,debuff,atk}
public enum StatEffect { atk,spd,health,nothing}
public enum MoveCard { right,left,up,down,not}
[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 1)]
public class AbilityStat :ScriptableObject
{

    [SerializeField] int diceCost,targetCount;
    [SerializeField] string skillName;
    [SerializeField] string descript;
    [SerializeField] int abilityPower;
    [SerializeField] FieldEffect field;
    [SerializeField] TargetAble target;
    [SerializeField] AbilityType abilityType=AbilityType.atk;
    [SerializeField] StatEffect statEffect=StatEffect.nothing;


 
    public int DiceCost { get => diceCost; set => diceCost = value; }
    public int TargetCount { get => targetCount; set => targetCount = value; }
    public string SkillName { get => skillName; set => skillName = value; }
    public string Descript { get => descript; set => descript = value; }
    public int AbilityPower { get => abilityPower; set => abilityPower = value; }
    public FieldEffect Field { get => field; set => field = value; }
    public TargetAble Target { get => target; set => target = value; }
    public AbilityType AbilityType { get => abilityType; set => abilityType = value; }
    public StatEffect StatEffect { get => statEffect; set => statEffect = value; }

}