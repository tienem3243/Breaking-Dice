using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, ENERMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public CardDisplay cardBase;
    public GameObject cardBag1, cardBag2;
    public GameObject[] playerChar, EnermyChar;
    public Image[] EffectField1, EffectField2;
    public Transform[] cardPlace1, cardPlace2;
    public Transform cardSpawn;
    public BattleState battleState;
    private void Start()
    {
        battleState = BattleState.START;
        ChangeBattleState(BattleState.START);
    }

    public void ChangeBattleState(BattleState state)
    {
        battleState = state;
        switch (battleState)
        {
            case BattleState.START:
                Debug.Log("Battle Start!");
                StartCoroutine(InitBattle());
                //calculate turn 
                //TODO need calculate not hardset
                ChangeBattleState(BattleState.PLAYERTURN);
                break;

            case BattleState.PLAYERTURN:
                Debug.Log("Your Turn!");

                break;
            case BattleState.ENERMYTURN:
                Debug.Log("Enermy Turn!");

                break;
            case BattleState.LOST:
                Debug.Log("You Lost!");

                break;
            case BattleState.WON:
                Debug.Log("You Win!");

                break;
        }
    }

    public void AbilityUse(FieldEffect field, TargetAble target, int SlotOfOwner)
    {
        ResetTargetField();
        switch (target)
        {
            case TargetAble.enermy:
                TargetHandle(field,EffectField2);
                break;
            case TargetAble.player:
                TargetHandle(field,EffectField1);
                break;
            case TargetAble.all:
                TargetHandle(field,EffectField1);
                TargetHandle(field,EffectField2);
                break;
            case TargetAble.self:
                SetColorField(Color.green, EffectField1[SlotOfOwner], 1);
                break;

        }

    }
    public void TargetHandle(FieldEffect field, Image[] EffectField)
    {

        switch (field)
        {
            case FieldEffect.front:
                //todo use new function shorter
                SetColorField(Color.red, EffectField[0], 1f);
                SetColorField(Color.red, EffectField[2], 1f);
                break;
            case FieldEffect.back:
                SetColorField(Color.red, EffectField[1], 1f);
                SetColorField(Color.red, EffectField[3], 1f);
                break;
            case FieldEffect.all:
                SetColorField(Color.red, EffectField[0], 1f);
                SetColorField(Color.red, EffectField[1], 1f);
                SetColorField(Color.red, EffectField[2], 1f);
                SetColorField(Color.red, EffectField[3], 1f);
                break;
        }
    }
    public void ResetTargetField()
    {
        if (EffectField1.Length > 0)
            for (int i = 0; i < EffectField1.Length; i++)
            {
                SetColorField(Color.white, EffectField1[i], 1f);
            }
        if (EffectField2.Length > 0)
            for (int i = 0; i < EffectField2.Length; i++)
            {
                SetColorField(Color.white, EffectField2[i], 1f);

            }
    }
    public void SetColorField(Color color, Image image, float alpha)
    {
        image.color = new Color(color.r, color.g, color.b, alpha);
        Debug.Log(color.a);
    }
    public IEnumerator InitBattle()
    {
        StartCoroutine(InitPlayer());
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(InitEnermy());
    }

    //set up place of player and enermy
    public IEnumerator InitPlayer()
    {
        for (int i = 0; i <= playerChar.Length - 1; i++)
        {
            cardBase.Char = playerChar[i];
            var card = Instantiate(cardBase, cardBag1.transform);
            EffectField1[i] = card.GetComponentInChildren<Image>();
            card.GetComponent<CardDisplay>().onboardSlot = i;
            card.transform.position = cardSpawn.position;
            StartCoroutine(moveCard(cardPlace1[i].position, card.gameObject));
            yield return new WaitForSeconds(0.1f);
        }
    }
    public IEnumerator InitEnermy()
    {
        for (int i = 0; i <= EnermyChar.Length - 1; i++)
        {

            cardBase.Char = EnermyChar[i];
            var card = Instantiate(cardBase, cardBag2.transform);
            EffectField2[i] = card.GetComponentInChildren<Image>();
            card.GetComponent<CardDisplay>().onboardSlot = i;
            card.transform.position = cardSpawn.position;
            StartCoroutine(moveCard(cardPlace2[i].position, card.gameObject));
            yield return new WaitForSeconds(0.1f);
        }
    }

    //move card function
    public IEnumerator moveCard(Vector3 des, GameObject card)
    {

        while (des != card.transform.position)
        {
            card.transform.position = Vector2.MoveTowards(card.transform.position, des, Time.deltaTime * 200f);
            yield return null;
        }
    }

}
