using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBehavior : MonoBehaviour
{
    public AuxilaryView auxView;

    void OnMouseDown()
    {
        //communicates click on collider to aux view and allows to change view
        auxView.toggleView();
    }
}