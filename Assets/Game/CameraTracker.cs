using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public Transform playerPosition;
    public Transform playerOrientation;
    public bool attachedToPlayer = true;
    void Update()
    {
        if (attachedToPlayer)
        {
            this.transform.position = playerPosition.position;
            this.transform.rotation = playerOrientation.rotation;
        }
    }
}

