using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour
{
    [Header("Inscribed")]

    //Gameplay
    private Vector3 ogPos;
    private bool bounced = false;
    private bool isMouseOver = false;

    private SelPuzzleManager sm;

    public Vector3 pos;
    public Vector3 bounceVec;//vector to store the amount the object will bounce
    public Vector3 bouncePos;
    public Vector3 playPos;
    public float bounceHeight = 0.25f;

    public string selName;
    public bool isSelectable = true;

    public AudioSource audioSource;
    public AudioClip moveSound;
    public float volume = 1f;

    void Start()
    {
        pos = this.transform.position;
        bouncePos = pos + bounceVec;
        ogPos = pos;
        playPos = bouncePos;
        selName = this.name;

        sm = FindObjectOfType<SelPuzzleManager>();
    }

    public bool wasMouseOver()
    {
        return isMouseOver;
    }

    public void move(Vector3 inMovePos)
    {
        this.transform.position = inMovePos;
        pos = inMovePos;
        bouncePos = pos + bounceVec;
    }

    public void play()
    {
        //move up
        move(playPos);
        //set not playable
        isSelectable = false;
    }

    public void reset()
    {
        move(ogPos);
        isSelectable = true;
    }

    void OnMouseOver()
    {
        if (isSelectable && Time.timeScale == 1)//added time conditional to prevent player interaction during pause
        {
            //bounce on hover            
            this.transform.position = bouncePos;
            bounced = true;

            if(!isMouseOver)
            {
                audioSource.PlayOneShot(moveSound, volume);
            }

            isMouseOver = true;
            
            //play if clicked
            if(Input.GetMouseButtonDown(0) && sm.canPlay)
            {
                sm.addToPlayed(this);
            }
        }
        else
        {
            isMouseOver = false;
        }
        
    }

    void OnMouseExit()
    {
        if (isSelectable)
        {
            if (bounced)
            {
                this.transform.position = pos;
                bounced = false;
            }
        }
        isMouseOver = false;
    }
}
