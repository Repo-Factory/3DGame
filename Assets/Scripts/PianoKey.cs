using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKey : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isMuted = true;

    public void ToggleMute()
    {
        isMuted = !isMuted;
        ToggleAudio(isMuted);
    }

    public void ToggleAudio(bool isMuted)
    {
        if (isMuted)
        {
            StopAudio();
        }
        else
        {
            audioSource.Play();
            Invoke("StopAudio", .8f);
        }
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void OnMouseDown()
    {
        ToggleMute();
    }
}
