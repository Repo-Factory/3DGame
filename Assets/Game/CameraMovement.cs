using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float moveSpeed = 5.0f; // Speed of camera movement
    float rotateSpeed = 100.0f; // Speed of camera rotation

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Camera Movement
        float horizontalTranslation = 0;
        float depthTranslation = 0;

        if (Input.GetKey(KeyCode.A))
            horizontalTranslation -= 1;
        if (Input.GetKey(KeyCode.D))
            horizontalTranslation += 1;
        if (Input.GetKey(KeyCode.W))
            depthTranslation += 1;
        if (Input.GetKey(KeyCode.S))
            depthTranslation -= 1;

        Vector3 moveDirection = new Vector3(horizontalTranslation, 0.0f, depthTranslation);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Camera Rotation
        float horizontalRotation = 0;
        float verticalRotation = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            horizontalRotation -= 1;
        if (Input.GetKey(KeyCode.RightArrow))
            horizontalRotation += 1;
        if (Input.GetKey(KeyCode.UpArrow))
            verticalRotation -= 1;
        if (Input.GetKey(KeyCode.DownArrow))
            verticalRotation += 1;

        Vector3 rotation = new Vector3(0, horizontalRotation * rotateSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation);
    }
}
