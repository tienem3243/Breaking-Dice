using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BattleState { START, PLAYERTURN, ENERMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public CardDisplay cardBase;
    public GameObject[] playerChar,EnermyChar;
    public Transform cardPlace1,cardPlace2;
    public BattleState battleState;
    private void Start()
    {
        battleState = BattleState.START;
        SetUpBattle();
    }
    public void SetUpBattle()
    {
        for(int i=0;i<playerChar.Length-1;i++)
        {
            
            cardBase.Char = playerChar[i];
            Instantiate(cardBase, cardPlace1);
        }
        for(int i = 0; i < playerChar.Length - 1; i++)
        {
            cardBase.Char = EnermyChar[i];
            Instantiate(cardBase, cardPlace2);
        }
        

    }
}
