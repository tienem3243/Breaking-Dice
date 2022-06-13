using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public BattleSystem battleSystem;
    [SerializeField] public GameObject Char;
    [SerializeField] public Image[] abilityField;
    [SerializeField] public Transform charStand;
    [SerializeField] public TextMesh cardName, atk, hp,spd, ability1, ability2;
    [SerializeField] public int onboardSlot; 
    [SerializeField] public Image diceCost1, diceCost2, itemSlotCount, IconOfClass;

    Class character;
    private void Start()
    {
        InitCard();
        battleSystem = FindObjectOfType<BattleSystem>();
        Instantiate(character.gameObject, charStand);
    }
   
    public void InitCard()
    {
        //set up sprite
        character = Char.GetComponent<Class>();
        Sprite[] costList = Resources.LoadAll<Sprite>("Sprites/Dice/DiceStyle1");
        Sprite[] itemSlotList = Resources.LoadAll<Sprite>("Sprites/BaseCard/ItemSlot");
        Sprite charClass = Resources.Load<Sprite>("Sprites/Class/" + character.Classname);
        //set up stat
        cardName.text = character.Classname;
        atk.text = character.Dame.ToString();
        hp.text = character.Hp.ToString();
        spd.text = character.Speed.ToString();
        //set up ability name
        ability1.text = character.AbilityList[0].Name;
        ability2.text = character.AbilityList[1].Name;
       
        //set item slot
        if (character.Items.Length != 0)
        {
            itemSlotCount.sprite = itemSlotList[character.Items.Length];
        }
        //set cost
        if (character.AbilityList.Length != 0)
        {
            diceCost1.sprite = costList[character.AbilityList[0].DiceCost];
            diceCost2.sprite = costList[character.AbilityList[1].DiceCost];
        }
        //set icon class
        IconOfClass.sprite = charClass;
        //set field color base on type of ability
        for (int i = 0; i < character.AbilityList.Length; i++)
        {
            abilityField[i].color = SetFieldColor(character.AbilityList[i].AbilityType);
        }

    }
    //set color by ability type TODO
    public static Color SetFieldColor(AbilityType type)
    {
        Color color;
        switch (type)
        {
            case AbilityType.atk:

                if (ColorUtility.TryParseHtmlString("#c55050", out color))
                    return color;
                break;
            case AbilityType.buff:
                if (ColorUtility.TryParseHtmlString("#ed7934", out color))
                    return color;
                break;
            case AbilityType.debuff:
       
                if (ColorUtility.TryParseHtmlString("#ae2ed2", out color))
                    return color;
                break;
            case AbilityType.heal:
                if (ColorUtility.TryParseHtmlString("#1dce49", out color))
                    return color;
                break;
        }
        return Color.white;
    }
    public void AbilityUse(int skillSlot)
    {
        FieldEffect field= character.AbilityList[skillSlot].Field;
        TargetAble target = character.AbilityList[skillSlot].Target;
        Color color = SetFieldColor(character.AbilityList[skillSlot].AbilityType);
        battleSystem.VisualFieldEffect(field, target,onboardSlot,color);

    }
    public void AbilityResetTarget()
    {
        battleSystem.ResetTargetField();
    }

}
 