using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] GameObject Char;
    [SerializeField] Transform charStand;
    [SerializeField] TextMesh cardName, atk, hp, ability1, ability2;
    [SerializeField] Image diceCost1, diceCost2, itemSlotCount, IconOfClass;
   
    private void Start()
    {
        //set up sprite
        var character = Char.GetComponent<Class>();
        Sprite[] costList = Resources.LoadAll<Sprite>("Sprites/Dice/DiceStyle1");
        Sprite[] itemSlotList = Resources.LoadAll<Sprite>("Sprites/BaseCard/ItemSlot");
        Sprite charClass = Resources.Load<Sprite>("Sprites/Class/"+character.Classname);
        //set up stat
        cardName.text = character.Classname;
        atk.text = character.Dame.ToString();
        hp.text = character.Hp.ToString();
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
            diceCost1.sprite = costList[character.AbilityList[0].DiceCost ];
            diceCost2.sprite = costList[character.AbilityList[1].DiceCost ];
        }
        IconOfClass.sprite = charClass;
        Instantiate(character.gameObject, charStand);
    }

}
 