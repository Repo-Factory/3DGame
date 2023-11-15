using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxilaryView : MonoBehaviour
{
    public Camera mainCamera;
    public Camera auxilaryCamera;

    private void Start()
    {
        auxilaryCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && auxilaryCamera.enabled)
        {
            togglePianoView();
        }
    }

    private void OnMouseDown()
    {
        if (mainCamera.enabled)
        {
            togglePianoView();
        }
    }

    private void togglePianoView()
    {
        mainCamera.enabled = !mainCamera.enabled;
        auxilaryCamera.enabled = !auxilaryCamera.enabled;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
