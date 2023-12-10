using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioSource audioSource;
    public bool playOnLoad = true;
    private bool isMuted = true;

    void Start()
    {
        audioSource.Play();
    	if (!playOnLoad)
    	{
    	    audioSource.Pause();
    	}
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        ToggleAudio(isMuted);
    }

    public void ToggleAudio(bool isMuted)
    {
        if (isMuted)
        {
             audioSource.Pause();
        }
        else
        {
             audioSource.UnPause();
        }
    }

    public void OnMouseDown()
    {
        ToggleMute();
    }
}
