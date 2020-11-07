using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform edgeParticles;
    //public static int remainingPieces = 25;
    public static float timeBonus = 120;
    int countdownSpeed;
    public static int wrongClicks = 0;
    public static int correctPlacement;
    public int numPieces;
    public static GameObject[] placeholders;
    private bool correctOrientation = false;
    public static GameObject[] pieces;
    public int numPiecesOrient;
  


    // Start is called before the first frame update
    void Start()
    {
        pieces = GameObject.FindGameObjectsWithTag("Pieces");
        numPieces = 25;
        correctPlacement = 0; 
        countdownSpeed = 3;
        placeholders = GameObject.FindGameObjectsWithTag("Placeholders");
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (((correctPlacement < numPieces) && (correctOrientation == false)) || ((correctPlacement == numPieces) && (correctOrientation == false)))
        
        if ((correctPlacement == numPieces) && (correctOrientation == true))//((correctPlacement == 1) && (correctOrientation == false))
        {
             foreach (GameObject i in placeholders)
             {
                Instantiate(edgeParticles, i.transform.position, edgeParticles.rotation);

             }
           
            Invoke("EndGame", 1.5f);
        }
        else
        {
            GameObject.Find("TimerText").GetComponent<Timer>().UpdateTime();
            timeBonus -= Time.deltaTime / countdownSpeed;

        }

        CheckRotation();
    }

    void EndGame()
    {
            SceneManager.LoadScene("LevelCompletion");
        
    }
   
    void CheckRotation()
    {
        foreach (GameObject i in pieces)
        {
            if ((i.GetComponent<Transform>().eulerAngles.z <= 2 && i.GetComponent<Transform>().eulerAngles.z >= -2) && (i.GetComponent<MovePiece>().alreadyUsed == false))
            {
                numPiecesOrient++;
                i.GetComponent<MovePiece>().alreadyUsed = true;
            }
            if ((i.GetComponent<MovePiece>().alreadyUsed == true) && (i.GetComponent<Transform>().eulerAngles.z > 2 || i.GetComponent<Transform>().eulerAngles.z < -2))
            {
                numPiecesOrient -= 1;
                i.GetComponent<MovePiece>().alreadyUsed = false;
            }
        }
        if (numPieces == numPiecesOrient)
        {
            correctOrientation = true;
        }
    }

    

}
