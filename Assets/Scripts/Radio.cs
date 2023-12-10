using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource backgroundMusic = null;
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
             if (backgroundMusic != null)
             {
                 backgroundMusic.UnPause();
       	     }
        }
        else
        {
             audioSource.UnPause();
             if (backgroundMusic != null)
             {
                 backgroundMusic.Pause();
       	     }
        }
        
    }

    public void OnMouseDown()
    {
        ToggleMute();
    }
}
