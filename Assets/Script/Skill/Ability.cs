using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] ILivingEntity holder;
    AbilityStat ability;
    public string AbilityUse(CharacterClass target)
    {
        switch (ability.AbilityType)
        {
            case AbilityType.buff:
                target.Buff(ability.StatEffect, ability.AbilityPower);
                return "buff";
            case AbilityType.heal:
                target.Buff(ability.StatEffect, ability.AbilityPower);//du thua merg to buff
                return "heal";

            case AbilityType.debuff:
                target.Buff(ability.StatEffect, -ability.AbilityPower);
                return "debuff";

            case AbilityType.atk:
                holder.hit(target, ability.AbilityPower);
                return "atk";

        }

        return "ability used";
    }
}
