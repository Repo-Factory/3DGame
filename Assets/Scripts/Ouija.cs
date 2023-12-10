using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum State
{ 
    musicKeyPuzzle = 0,
    binaryPuzzle = 1
};

public class Ouija : MonoBehaviour
{
    public string answer = "";
    public Key key;
    public GameObject textObject;
    public State state = State.musicKeyPuzzle;
    private TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        text = textObject.GetComponent<TextMeshPro>();
        foreach (Transform child in transform)
        {
            BoxCollider collider = child.GetComponent<BoxCollider>();
            LetterClickHandler clickHandler = collider.gameObject.AddComponent<LetterClickHandler>();
            clickHandler.SetOuija(this);
        }
    }

    private void Update()
    {
        text.text = answer;
    }
}

public class LetterClickHandler : MonoBehaviour
{
    private Ouija ouija;
    const string BLANK_STRING = "";
    const string ENTER_KEY = "Yes";
    const string CLEAR_KEY = "No";
    const string FIRST_CODE = "CSHARP";
    const string FINAL_CODE = "51192";

    public void SetOuija(Ouija ouija)
    {
        this.ouija = ouija;
    }

    void OnMouseDown()
    {
        string keyName = transform.name;

        if (keyName == ENTER_KEY)
        {
            SubmitAnswer(ouija.answer);
            ouija.answer = BLANK_STRING;
        }
        else if (keyName == CLEAR_KEY)
        {
            ouija.answer = BLANK_STRING;
        }
        else
        {
            ouija.answer = string.Concat(ouija.answer, keyName);
        }
    }

    public void SubmitAnswer(string answer)
    {
        if (answer == FIRST_CODE && ouija.state == State.musicKeyPuzzle)
        {
            ouija.key.Activate();
            ouija.state = State.binaryPuzzle;
        }

        if (answer == FINAL_CODE && ouija.state == State.binaryPuzzle)
        {
            CompleteLevel();
        }
    }

    void CompleteLevel()
    {
        SceneManager.LoadScene("AudioCutscene");
    }
}
