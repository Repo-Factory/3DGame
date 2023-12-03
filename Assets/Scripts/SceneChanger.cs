using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //this script will be attached to colliders of objects that will transition the player to different scenes
    //set the appropate scene with bools in unity
    public bool toMain = false;
    public bool toAudio = false;
    public bool toCard = false;
    public bool toQueen = false;

    void OnMouseDown()
    {
        if (toMain)
        {
            SceneManager.LoadScene("MainScene");
        }
        else if(toAudio)
        {
            SceneManager.LoadScene("AudioScene");
        }
        else if(toCard)
        {
            SceneManager.LoadScene("Card Riddle");
        }
        else if (toQueen)
        {
            SceneManager.LoadScene("EightQueensPuzzle");
        }
    }
}
