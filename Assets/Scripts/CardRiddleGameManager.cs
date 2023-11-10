using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRiddleGameManager : MonoBehaviour
{
    private static int riddleNum = 10;
    private Card playedCard = null;

    public int lives = 3;
    public int points = 0;

    public int pointsToWin = 3;

    public List<string> riddles = new List<string>(riddleNum);
    /*
     { "Who was murdered?", "Who burried their spouse alive?", 
        "Who beheaded their subjects over white roses?",  "Who did King and his Court mock for eternity",
        "Who was a resurrection man? - tenative", "King of hearts",
        "Queen of Spades", "Queen of Hearts",
        "Joker", "Jack of Spades" }
    */

    public List<Card> solutionCards = new List<Card>(riddleNum);

    public int curRiddleIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        //temp
        startRound();
    }

    // Update is called once per frame
    void Update()
    {
        if(points >= pointsToWin)
        {
            //win cond
            Debug.Log("Win");
        }
        else if(lives <= 0)
        {
            //Loss
            Debug.Log("loss");
        }
    }

    //if do start game interface
    public void startGame()
    {
        //hide interface
        startRound();
    }

    public void startRound()
    {
        curRiddleIndex = Random.Range(0, riddleNum - 1);
        //display riddle
    }

    public void checkSolution(Card card)
    {
        if (curRiddleIndex >= 0)//insure riddle has be selected to check against
        {
            playedCard = card;
            if (Equals(card.getCardName(), solutionCards[curRiddleIndex].getCardName()))
            {
                //correct guess
                points++;
            }
            else
            {
                //incorrect
                lives--;

            }
            Invoke("resetRound", 2f);
        }
    }

    public void resetRound()
    {
        riddles.RemoveAt(curRiddleIndex);
        solutionCards.RemoveAt(curRiddleIndex);
        playedCard.cardReset();
        
        //reset riddle
        startRound();
    }
}
