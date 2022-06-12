using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public BattleSystem battleSystem;
    [SerializeField] public GameObject Char;
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
        IconOfClass.sprite = charClass;
    }
    public void AbilityUse(int slot)
    {
        FieldEffect field= character.AbilityList[slot].Field;
        TargetAble target = character.AbilityList[slot].Target;
        battleSystem.AbilityUse(field, target,onboardSlot);

    }
    public void AbilityResetTarget()
    {
        battleSystem.ResetTargetField();
    }

}
 