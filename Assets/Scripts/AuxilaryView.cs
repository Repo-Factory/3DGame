using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxilaryView : MonoBehaviour
{
    public Camera mainCamera;
    public Camera auxilaryCamera;

    public BoxCollider viewCollider;

    private void Start()
    {
        auxilaryCamera.enabled = false;
        mainCamera.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && auxilaryCamera.enabled)
        {
            toggleView();
        }
    }

    public void toggleView()
    {
        mainCamera.enabled = !mainCamera.enabled;
        auxilaryCamera.enabled = !auxilaryCamera.enabled;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        viewCollider.gameObject.SetActive(mainCamera.enabled);
    }
}
