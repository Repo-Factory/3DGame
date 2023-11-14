using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairView : MonoBehaviour
{
    public Camera mainCamera;
    public Camera pianoCamera;

    private void Start()
    {
        pianoCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pianoCamera.enabled)
        {
            togglePianoView();
        }
    }

    private void OnMouseDown()
    {
        togglePianoView();
    }

    private void togglePianoView()
    {
        mainCamera.enabled = !mainCamera.enabled;
        pianoCamera.enabled = !pianoCamera.enabled;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
