using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// Dislay all of public infomation of card and slot on the board
/// </summary>
public class CardDisplay : MonoBehaviour
{
    [SerializeField] public BattleSystem battleSystem;
    [SerializeField] public GameObject Char;
    [SerializeField] public Image[] abilityField, diceCost;
    [SerializeField] public Transform charStand;
    [SerializeField] public TextMesh cardName, atk, hp, spd, ability1, ability2;
    [SerializeField] public int onboardSlot;
    [SerializeField] public Image itemSlotCount, IconOfClass;
    [SerializeField] public GameObject ChosenEffect;
    CharacterClass character;
    Race race;
    private void Start()
    {
        InitCard();
        race = Char.GetComponent<Race>();
        battleSystem = FindObjectOfType<BattleSystem>();
        Char = Instantiate(character.gameObject, charStand);
    }

    [ContextMenu("InitCard")]
    public void InitCard()
    {
        //set up sprite
        character = Char.gameObject.GetComponent<CharacterClass>();
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
            diceCost[0].sprite = costList[character.AbilityList[0].DiceCost];
            diceCost[1].sprite = costList[character.AbilityList[1].DiceCost];
        }
        //set icon class
        IconOfClass.sprite = charClass;
        //set field color base on type of ability
        for (int i = 0; i < character.AbilityList.Length; i++)
        {
            abilityField[i].color = SetFieldColor(character.AbilityList[i].AbilityType);
        }

    }
    //set color by ability type TODO--> actualy can use dictionary
    public static Color SetFieldColor(AbilityType type)
    {
        Color color;
        switch (type)
        {
            case AbilityType.atk:
                //if code color exist
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
        FieldEffect field = character.AbilityList[skillSlot].Field;
        TargetAble target = character.AbilityList[skillSlot].Target;
        Color color = SetFieldColor(character.AbilityList[skillSlot].AbilityType);
        battleSystem.TargetAbleHandler(field, target, onboardSlot, color);

    }
    public void AbilityResetTarget()
    {
        battleSystem.ResetTargetField();

    }
    public void OnEnterMouse(bool enable)
    {


        ChosenEffect.SetActive(enable);
    }
    public void OnChosen()
    {

        if (Char != null &&battleSystem != null) 
        {
            battleSystem.atkHandlerQueue.Enqueue(race);

        }
    }

}
