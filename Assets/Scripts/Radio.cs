using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isMuted = true;

    void Start()
    {
        audioSource.Play();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        ToggleAudio(isMuted);
    }

    public void ToggleAudio(bool isMuted)
    {

        audioSource.mute = isMuted;
    }

    public void OnMouseDown()
    {
        ToggleMute();
    }
}
