using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookGameManager : MonoBehaviour
{

    public List<Selectable> Answers = new List<Selectable>();
    public SelPuzzleManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<SelPuzzleManager>();
        startRound();//maybe place on click
    }

    public void EvaluateRound(bool didWin)
    {
        if (didWin)//find sol so this is called and riddle evaled
        {
            //correct
            Invoke("loadEndScreen", 1f);
        }
        else
        {
            //incorrect
            sm.resetPlayed();
            startRound();
        }
    }

    public void startRound()
    {
        //add the anwsers to the sm
        for (int i = 0; i < Answers.Count; i++)
        {
            sm.Answers.Add(Answers[i]);
        }
    }

    private void loadEndScreen()
    {
        SceneManager.LoadScene("Win Scene");
    }
}
