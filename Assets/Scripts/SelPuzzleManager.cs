using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelPuzzleManager : MonoBehaviour
{
    public bool canPlay = true;

    public List<Selectable> Answers = new List<Selectable>();
    public List<Selectable> Played = new List<Selectable>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToPlayed(Selectable selectable)
    {
        Played.Add(selectable);
        selectable.play();

        if (Played.Count == Answers.Count)
        {
            checkSolutions();
        }
    }

    public void resetPlayed()
    {
        for (int i = Played.Count - 1; i >= 0; i--)
        {
            Played[i].reset();
            Played.RemoveAt(i);
            Answers.RemoveAt(i);
        }
        canPlay = true;
    }

    public void checkSolutions()
    {
        if (Played.Count == Answers.Count)
        {
            canPlay = false;
            bool wasSolved = checkSolution(Played[0], Answers[0]);
            for (int i = 1; i < Played.Count; i++)
            {
                wasSolved = wasSolved && checkSolution(Played[i], Answers[i]);
            }

            BroadcastMessage("EvaluateRound", wasSolved);//wont work exactly since need the solved to be false at some point
        }
    }

    public bool checkSolution(Selectable selectable, Selectable answer)
    {
        if (Equals(selectable.selName, answer.selName))
        {
            //correct guess
            return true;
        }
        else
        {
            //incorrect
            return false;
        }
    }
}
