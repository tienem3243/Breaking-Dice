using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// State machine and visual controller
/// </summary>
public enum BattleState { START, PLAYERTURN, ENERMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public CardDisplay cardBase;
    public CharacterClass[] playerChar, EnermyChar;
    public Image[] EffectField1, EffectField2;
    public Transform[] cardPlace1, cardPlace2;
    public Transform cardSpawn;
    public BattleState battleState;
    public GameObject screenBlocking;
    public Queue<Race> atkHandlerQueue;
    private void Start()
    {
        battleState = BattleState.START;
        atkHandlerQueue = new Queue<Race>();
        StartCoroutine(ChangeBattleState(BattleState.START));
    }
    private void Update()
    {
        if (atkHandlerQueue.Count==2)
        {
            Debug.Log("handle");
            atkHandlerQueue.Clear();
        }
    }
    /*State Machine*/
    public IEnumerator ChangeBattleState(BattleState state)
    {
        battleState = state;
        switch (battleState)
        {
            case BattleState.START:

                Debug.Log("Battle Start!");
                StartCoroutine(InitBattle());
                //calculate turn 
                //TODO need calculate not hardset
                StartCoroutine(ChangeBattleState(BattleState.PLAYERTURN));
                break;

            case BattleState.PLAYERTURN:
                screenBlocking.SetActive(false);
                Debug.Log("Your Turn!");

                break;
            case BattleState.ENERMYTURN:
                screenBlocking.SetActive(true);
                Debug.Log("Enermy Turn!");
                yield return new WaitForSeconds(2f);
                StartCoroutine(ChangeBattleState(BattleState.PLAYERTURN));
                break;
            case BattleState.LOST:
                Debug.Log("You Lost!");

                break;
            case BattleState.WON:
                Debug.Log("You Win!");

                break;
        }
        yield return new WaitForSeconds(2f);
    }


 
    /*Visual */
    public void PassButton()
    {
        StartCoroutine(ChangeBattleState(BattleState.ENERMYTURN));
    }
    public void TargetAbleHandler(FieldEffect field, TargetAble target, int SlotOfOwner, Color color)
    {
        ResetTargetField();
        switch (target)
        {
            case TargetAble.enermy:
                TargetFieldVisual(field, EffectField2, color);
                break;
            case TargetAble.player:
                TargetFieldVisual(field, EffectField1, color);
                break;
            case TargetAble.all:
                TargetFieldVisual(field, EffectField1, color);
                TargetFieldVisual(field, EffectField2, color);
                break;
            case TargetAble.self:
                SetColorField(color, EffectField1[SlotOfOwner], 1);
                break;

        }

    }
    public void TargetFieldVisual(FieldEffect field, Image[] EffectField, Color color)
    {

        switch (field)
        {
            case FieldEffect.front:
                //todo use new function shorter by devine them to 2 array font and back
                SetColorField(color, EffectField[0], 1f);
                SetColorField(color, EffectField[2], 1f);
                break;
            case FieldEffect.back:
                SetColorField(color, EffectField[1], 1f);
                SetColorField(color, EffectField[3], 1f);
                break;
            case FieldEffect.all:
                SetColorField(color, EffectField[0], 1f);
                SetColorField(color, EffectField[1], 1f);
                SetColorField(color, EffectField[2], 1f);
                SetColorField(color, EffectField[3], 1f);
                break;
        }
    }

    //reset target field visual

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
    }
    public IEnumerator InitBattle()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(InitPlayer());
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(InitEnermy());
    }

    //set up place of player and enermy
    public IEnumerator InitPlayer()
    {
        for (int i = 0; i <= playerChar.Length - 1; i++)
        {
            cardBase.Char = playerChar[i].gameObject;
            var card = Instantiate(cardBase, cardSpawn.transform);
            EffectField1[i] = card.GetComponentInChildren<Image>();
            card.GetComponent<CardDisplay>().onboardSlot = i;
            card.transform.position = cardSpawn.position;
            StartCoroutine(moveCard(cardPlace1[i].position, card.gameObject));
            yield return new WaitForSeconds(0.1f);
        }
    }
    //need merg to init player
    public IEnumerator InitEnermy()
    {
        for (int i = 0; i <= EnermyChar.Length - 1; i++)
        {

            cardBase.Char = EnermyChar[i].gameObject;
            var card = Instantiate(cardBase, cardSpawn.transform);
            EffectField2[i] = card.GetComponentInChildren<Image>();
            card.GetComponent<CardDisplay>().onboardSlot = i;
            card.GetComponent<CardDisplay>().abilityField[0].raycastTarget = false;
            card.GetComponent<CardDisplay>().abilityField[1].raycastTarget = false;
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
