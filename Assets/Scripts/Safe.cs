using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    bool safeOpen = false;
    public AudioSource openEffect;
    public Key key;
    public GameObject safeDoor;
    public GameObject binaryPaper;
    public Camera mainCamera;
    public Camera auxilaryCamera;

    private void Start()
    {
        binaryPaper.SetActive(false);
        auxilaryCamera.enabled = false;

    }

    private void OnMouseDown()
    {
        if (key.pickedUp && !safeOpen)
        {
            OpenSafe();
            openEffect.Play();
        }

        if (safeOpen)
        {
            if (mainCamera.enabled)
            {
                toggleView();
            }
        }
    }
    
    void OpenSafe()
    {
        safeDoor.transform.rotation = Quaternion.Euler(0, 270, 0);
        binaryPaper.SetActive(true);
        safeOpen = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && auxilaryCamera.enabled)
        {
            toggleView();
        }
    }

    private void toggleView()
    {
        mainCamera.enabled = !mainCamera.enabled;
        auxilaryCamera.enabled = !auxilaryCamera.enabled;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
