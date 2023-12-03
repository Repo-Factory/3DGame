using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelPuzzleGameManager : MonoBehaviour
{
    private static int riddleNum = 5;

    public int riddlesToSolve = 3;
    public int curRiddleIndex = -1;

    public TextMeshPro comText;

    public List<string> riddles = new List<string>(riddleNum);
    public List<Selectable> solutionCards = new List<Selectable>(riddleNum);
    public List<TextMeshPro> riddlePlaces;

    public List<string> selectedRiddles;
    public List<Selectable> selectedSol;

    public SelPuzzleManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<SelPuzzleManager>();

        startRound();
    }

    public void startRound()
    {
        //clear selected lists
        if (selectedRiddles.Count > 0 )
        {
            selectedRiddles.Clear();
        }
        if (selectedSol.Count > 0)
        {
            selectedSol.Clear();
        }

        //Add all riddles to slected
        selectedRiddles.AddRange(riddles);
        selectedSol.AddRange(solutionCards);

        //set all text location text to null
        for (int i = 0; i < riddlePlaces.Count; i++)
        {
            riddlePlaces[i].text = "";
        }

        //remove non selected riddles
        for (int i = 0; i < (riddles.Count - riddlesToSolve); i++)
        {
            curRiddleIndex = Random.Range(0, selectedRiddles.Count - 1);

            selectedRiddles.RemoveAt(curRiddleIndex);
            selectedSol.RemoveAt(curRiddleIndex);
        }

        //create array and fill with 3 rand nums to randomize riddle loc
        List<int> indexes = new List<int>(riddlePlaces.Count);
        for(int i = 0; i < riddlePlaces.Count; i++)
        {
            indexes.Add(i);
        }

        for (int i = 0; i < (riddlePlaces.Count - riddlesToSolve); i++)
        {
            indexes.RemoveAt(Random.Range(0, indexes.Count - 1));
        }

        //add the anwsers to the sm and display the riddles
        for (int i = 0; i < selectedRiddles.Count; i++)
        {
            sm.Answers.Add(selectedSol[i]);
            //display riddle
            riddlePlaces[indexes[i]].text = riddles[i];
        }
    }

    public void EvaluateRound(bool didWin)
    {
        if (curRiddleIndex >= 0)//insure riddle has be selected to check against
        {
            //replace with 
            if (didWin)//find sol so this is called and riddle evaled
            {
                //correct
                comText.text = "Look Up";
                BroadcastMessage("setTextToRiddle");
            }
            else
            {
                //incorrect
                comText.text = "Wrong";

                Invoke("resetRound", 2f);
            }
        }
    }

    public void resetRound()
    {
        //reset selriddles and sel cards list
        
        sm.resetPlayed();

        comText.text = "Select those accused";

        //reset riddle
        startRound();
    }
}
