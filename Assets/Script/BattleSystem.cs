using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BattleState { START, PLAYERTURN, ENERMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public CardDisplay cardBase;
    public GameObject cardBagPlace;
    public GameObject[] playerChar, EnermyChar;
    public Transform[] cardPlace1, cardPlace2;
    public Transform cardSpawn;
    public BattleState battleState;
    private void Start()
    {
        battleState = BattleState.START;
        StartCoroutine(InitPlayer());

    }

    public void BattleManager()
    {
        switch (battleState)
        {
            case BattleState.START:
                Debug.Log("Battle Start!");
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
    public void PlayerTurn()
    {
        //do some thing

    }
    public void EnermyTurn()
    {

    }


    //set up place of player and enermy
    public IEnumerator InitPlayer()
    {
        for (int i = 0; i <= playerChar.Length - 1; i++)
        {
            cardBase.Char = playerChar[i];
            var card = Instantiate(cardBase, cardBagPlace.transform);
            card.transform.position = cardSpawn.position;
            StartCoroutine(moveCard(cardPlace1[i].position, card.gameObject));
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(InitEnermy());
    }
    public IEnumerator InitEnermy()
    {
        for (int i = 0; i <= EnermyChar.Length - 1; i++)
        {

            cardBase.Char = EnermyChar[i];

            var card = Instantiate(cardBase, cardBagPlace.transform);
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
