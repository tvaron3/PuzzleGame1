using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingPiecesText : MonoBehaviour
{

    
    private GameObject U;
    private GameObject D;
    public string uText;
    public string dText;
    public int numPiecesAbove;
    public int numPiecesBelow;
    

    void Start()
    {
        
        U = GameObject.Find("remainingPiecesU");
        D = GameObject.Find("remainingPiecesD");
        uText = "More pieces above";
        dText = "More pieces below";
        D.GetComponent<TextMesh>().text = dText;
        U.GetComponent<TextMesh>().text = uText;




    }




    void Update()
    {


        
       if (MovePiece.moved == true)
        {
            PiecesAboveOrBelow();
            ChangeText();
            ResetEva();
            MovePiece.moved = false;
        }
        
    }

     public void PiecesAboveOrBelow()
     { 
        foreach (GameObject i in GameController.pieces)
        {
            if  ((i.GetComponent<Transform>().position.y > 16) && (i.GetComponent<MovePiece>().pieceStatus == "idle") && (i.GetComponent<MovePiece>().pieceAbove == false))
            {
                numPiecesAbove++;
                i.GetComponent<MovePiece>().pieceAbove = true;
            }
            
            

            if ((i.GetComponent<Transform>().position.y < -25) && (i.GetComponent<MovePiece>().pieceStatus == "idle") && (i.GetComponent<MovePiece>().pieceBelow == false))
            {
                numPiecesBelow++;
                i.GetComponent<MovePiece>().pieceBelow = true;
            }
            
            
        }
        
     }
    void ChangeText()
    {
        if (numPiecesAbove > 0)
        {
            
            uText = "More pieces above";
            U.GetComponent<TextMesh>().text = uText;
        }
        else
        {
            uText = "";
            U.GetComponent<TextMesh>().text = uText;
        }
        if (numPiecesBelow > 0)
        {
            
            dText = "More pieces below";
            D.GetComponent<TextMesh>().text = dText;
        }
        else
        {
            dText = "";
            D.GetComponent<TextMesh>().text = dText;
        }
    }
    void ResetEva()
    {
        
        numPiecesAbove = 0;
        numPiecesBelow = 0;
        foreach (GameObject i in GameController.pieces)
        {
            i.GetComponent<MovePiece>().pieceAbove = false;
            i.GetComponent<MovePiece>().pieceBelow = false;
        }
    }
}


