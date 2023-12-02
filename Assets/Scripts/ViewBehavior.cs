using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBehavior : MonoBehaviour
{//this script will be used to move the collider of the bookcase if not better solution can be found
    public Camera mainCamera;
    public BoxCollider bookcCaseCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!mainCamera.enabled)
        {

        }
        //bookcCaseCollider.gameObject.SetActive(mainCamera.enabled);
    }

    private void OnMouseDown()
    {
        if (!mainCamera.enabled)
        {
            
        }

        Debug.Log("ON click reging");
    }
}
