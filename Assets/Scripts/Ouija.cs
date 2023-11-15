using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ouija : MonoBehaviour
{
    public string answer = "";
    public GameObject textObject;
    public Key key;
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
    const string ENTER_KEY = "Yes";
    const string CLEAR_KEY = "No";
    const string CODE = "CSHARP";
    const string BLANK_STRING = "";

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
        if (answer == CODE)
        {
            ouija.key.Activate();
        }
    }
}
