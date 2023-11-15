using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ouija : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            BoxCollider collider = child.GetComponent<BoxCollider>();
            collider.gameObject.AddComponent<LetterClickHandler>();
        }
    }
}

public class LetterClickHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        // Get the letter associated with this collider
        char letter = transform.name[0];

        // Do something with the letter, for example, print it
        Debug.Log("Clicked on letter: " + letter);
    }
}
