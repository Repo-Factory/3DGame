using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ouija : MonoBehaviour
{
    public string answer = "";
    public GameObject textObject;
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

    public void SetOuija(Ouija ouija)
    {
        this.ouija = ouija;
    }

    void OnMouseDown()
    {
        string keyName = transform.name;

        if (keyName == "Yes")
        {
            SubmitAnswer(ouija.answer);
        }
        else if (keyName == "No")
        {
            ouija.answer = "";
            Debug.Log("Cleared Answer");
        }
        else
        {
            Debug.Log("Clicked On: " + keyName);
            ouija.answer = string.Concat(ouija.answer, keyName);
        }
    }

    public void SubmitAnswer(string word)
    {
        Debug.Log("Word is: " + word);
    }
}
