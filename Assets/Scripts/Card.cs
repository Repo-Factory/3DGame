using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [Header("Inscribed")]

    //Gameplay
    private Vector3 ogPos;
    private Vector3 pos;
    private Vector3 bouncePos;
    private Vector3 playPos;
    private bool bounced = false;
    private bool isMouseOver = false;

    private CardRiddleGameManager gm;

    public float bounceHeight = 0.25f;

    public string type;
    public string suit;
    public bool isPlayableCard = true;
    public bool faceUp = true;

    void Start()
    {
        pos = this.transform.position;
        bouncePos = pos;
        ogPos = pos;
        playPos = pos;

        bouncePos.y += bounceHeight;
        bouncePos.z += bounceHeight;

        playPos.x = 4f;
        playPos.z = 6f;

        gm = FindObjectOfType<CardRiddleGameManager>();
    }

    public bool wasMouseOver()
    {
        return isMouseOver;
    }
    
    public string getCardName()
    {
        return (type + " " + suit);
    }

    public void move(Vector3 inMovePos)//make gradual
    {
        this.transform.position = inMovePos;
        pos = inMovePos;
        bouncePos = pos;
        bouncePos.y += bounceHeight;
        bouncePos.z += bounceHeight;
    }

    public void playCard()
    {
        //add card to played in gm
        //move up
        move(playPos);
        //set not playable
        isPlayableCard = false;

        gm.checkSolution(this);
    }

    public void cardReset()
    {
        move(ogPos);
        isPlayableCard = true;
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
        if (isPlayableCard)
        {
            //bounce on hover            
            this.transform.position = bouncePos;
            bounced = true;

            isMouseOver = true;//needed????
            
            //play if clicked
            if(Input.GetMouseButtonDown(0))
            {
                playCard();
            }
        }
        else
        {
            isMouseOver = false;
        }
        
    }

    void OnMouseExit()
    {
        if (isPlayableCard)
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
