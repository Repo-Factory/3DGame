using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelPuzzleGameManager : MonoBehaviour
{
    private static int riddleNum = 10;

    public int lives = 3;
    public int points = 0;
    public int pointsToWin = 3;
    public int curRiddleIndex = -1;

    public List<string> riddles = new List<string>(riddleNum);
    /*
     { "Who was murdered?", "Who burried their spouse alive?", 
        "Who beheaded their subjects over white roses?",  "Who did King and his court mock for eternity?",
        "Who was a resurrection man? - tenative", "King of hearts",
        "Queen of Spades", "Queen of Hearts",
        "Joker", "Jack of Spades" }
    */
    public List<Selectable> solutionCards = new List<Selectable>(riddleNum);

    public SelPuzzleManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<SelPuzzleManager>();
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
        curRiddleIndex = Random.Range(0, riddles.Count - 1);
        sm.Answers.Add(solutionCards[curRiddleIndex]);
        //display riddle
    }

    public void EvaluateRound(bool didWin)
    {
        if (curRiddleIndex >= 0)//insure riddle has be selected to check against
        {
            //replace with 
            if (didWin)//find sol so this is called and riddle evaled
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
        sm.resetPlayed();
        
        //reset riddle
        startRound();
    }
}
