using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject keyPrefab;
    public bool pickedUp = false;
    void Start()
    {
        keyPrefab.SetActive(false);        
    }

    void OnMouseDown()
    {
        pickedUp = true;
        MoveKeyToInventory();
    }

    public void Activate()
    {
        keyPrefab.SetActive(true);
    }

    void MoveKeyToInventory()
    {
        Destroy(keyPrefab);
    }
}

