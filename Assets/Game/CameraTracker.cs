using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform cameraOrientation;
    void Update()
    {
        this.transform.position = cameraPosition.position;
        this.transform.rotation = cameraOrientation.rotation;
    }
}
