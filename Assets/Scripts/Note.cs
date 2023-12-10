using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject notePrefab;
    void Start()
    {
        notePrefab.SetActive(false);        
    }
    public void Activate()
    {
        notePrefab.SetActive(true);
    }
}
