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
    public bool faceUp = true;
    public bool canPlay = true;

    void Start()
    {
        pos = this.transform.position;
        bouncePos = pos + bounceVec;
        ogPos = pos;
        playPos = bouncePos;
        selName = this.name;

        sm = FindObjectOfType<SelPuzzleManager>();
    }

    void Update()
    {
        //canPlay = gm.canPlay;
    }

    public bool wasMouseOver()
    {
        return isMouseOver;
    }

    public void move(Vector3 inMovePos)//make gradual
    {
        this.transform.position = inMovePos;
        pos = inMovePos;
        bouncePos = pos;
        bouncePos.y += bounceHeight;
        bouncePos.z += bounceHeight;
    }

    public void play()
    {
        //add to played in gm
        //move up
        move(playPos);
        //set not playable
        isSelectable = false;

        //gm.checkSolution(this);
    }

    public void reset()
    {
        move(ogPos);
        isSelectable = true;
    }

    public void flip()//change this to be more gradual
    {
        if (faceUp)
        {
            this.transform.RotateAround(transform.position, Vector3.up, 180);
            
        }
        else
        {
            this.transform.RotateAround(transform.position, Vector3.up, -180);
            
        }
        faceUp = !faceUp;
    }

    void OnMouseOver()
    {
        if (isSelectable)
        {
            //bounce on hover            
            this.transform.position = bouncePos;
            bounced = true;

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
