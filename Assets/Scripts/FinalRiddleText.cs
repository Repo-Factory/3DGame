using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalRiddleText : MonoBehaviour
{
    public string riddle;
    public TextMeshPro FinalRiddle;

    public void setTextToRiddle()
    {
        FinalRiddle.text = riddle;
    }
}
