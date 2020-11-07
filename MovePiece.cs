 using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MovePiece : MonoBehaviour
{


    // also have a sound when piece is placed in correct spot

    public KeyCode placePiece;
    public KeyCode returntoinv;
    public string pieceStatus;
    public string checkPlacement = "";
    public Vector2 invPos;
    public Sprite stage2Image;
    public static int totalScore;
    public int yDiff;
    public float randomNum;
    private int maxInvPos = 25;
    private int minInvPos = 0;
    public float randomYLoc;
    private int maxRot = 3;
    private int minRot = 0;
    public int randomRot;
    public int startRot;
    public bool alreadyUsed = false;
    public  bool pieceAbove = false;
    public  bool pieceBelow = false;
    public static bool moved = false;


    /*void Awake()
    {
        RandomPosition();
        RandomRotation();
    }
*/
    void Start()
    {
        invPos = transform.position;
      //RandomPosition();
        //RandomRotation();

        pieceStatus = "idle";
        totalScore = 0;
        /*if (MainMenu.whichlevel == 2)
        {
            GetComponent< SpriteRenderer >().sprite = stage2Image;
        }
        */


    }

    void RandomRotation()
    {
        randomRot = Random.Range(minRot, maxRot);
        startRot = (90 * randomRot);
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, startRot);
    }
 
    /*void RandomPosition() // makes sure pieces in inventory aren't always in the same position
    {

        randomNum = Random.Range(minInvPos, maxInvPos);
        randomYLoc = 118.68f - 10 * randomNum;
        invPos = new Vector2(invPos.x, 118.68f - 10 * randomNum);
        gameObject.transform.position = invPos;


    }
\*

    /*void OnTriggerEnter2D(Collider2D other) // two pieces in inventory are not on top of eachother
    {
        while (other.gameObject.transform.position == gameObject.transform.position)
        {
            RandomPosition();
        }

    }
*/
    void Update()
    {

        invControl();

        if (pieceStatus == "pickedup")
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
            RotatePiece();
        }

        if ((Input.GetKeyDown(placePiece)) && (pieceStatus == "pickedup"))
        {
            checkPlacement = "y";
        }
        else
        {
            checkPlacement = "n"; // might delete later
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        /*if ((other.gameObject.name == gameObject.name) && (checkPlacement == "y"))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 0;
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            Instantiate(edgeParticles, other.gameObject.transform.position, edgeParticles.rotation);
            checkPlacement = "n"; // may be redundant
            // GetComponent<SpriteRenderer>().color = new Color(1, 1, 1,1);
            totalScore += 10;
            GameController.remainingPieces -= 1;

        } the code so that you can only place the piece in the correct spot
      */

        /*if ((other.gameObject.name != gameObject.name) && (checkPlacement == "y"))
        {
           // GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f); makes when placed in wrong spot a lighter shade
            checkPlacement = "n";
            totalScore -= 2;
            GameController.wrongClicks += 1;
        }
       */
       if (other.gameObject.tag != "Pieces")
        {
            if ((other.gameObject.name != gameObject.name) && (checkPlacement == "y")) // should make a sound when placed
            {
                if ((transform.eulerAngles.z < 0.01 && transform.eulerAngles.z >= 0) || (transform.eulerAngles.z < 185 && transform.eulerAngles.z >= 178) || (transform.eulerAngles.z > -185 && transform.eulerAngles.z <= -178))
                {
                    GetComponent<Renderer>().sortingOrder = 0;
                    transform.position = other.gameObject.transform.position;
                    pieceStatus = "locked";
                    checkPlacement = "n"; // may be redundant
                                          // GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f); makes when placed in wrong spot a lighter shade

                    totalScore -= 2;
                    GameController.wrongClicks += 1;
                }

            }

            if ((other.gameObject.name == gameObject.name) && (checkPlacement == "y"))
            {
                if ((transform.eulerAngles.z < 0.01 && transform.eulerAngles.z >= 0) || (transform.eulerAngles.z < 185 && transform.eulerAngles.z >= 178) || (transform.eulerAngles.z > -185 && transform.eulerAngles.z <= -178))
                {
                    GetComponent<Renderer>().sortingOrder = 0;
                    transform.position = other.gameObject.transform.position;
                    pieceStatus = "correct";
                    checkPlacement = "n"; // may be redundant
                                          // GetComponent<SpriteRenderer>().color = new Color(1, 1, 1,1);
                    totalScore += 10;
                    GameController.correctPlacement++;
                }


            }
            if (other.gameObject.transform.position == gameObject.transform.position)
            {
                if((transform.eulerAngles.z < 0.01 && transform.eulerAngles.z >= 0) || (transform.eulerAngles.z < 185 && transform.eulerAngles.z >= 178) || (transform.eulerAngles.z > -185 && transform.eulerAngles.z <= -178))
                {
                    other.GetComponent<BoxCollider2D>().enabled = false;
                }

            }

        }





    }
    void OnMouseDown()
    {
        if (pieceStatus == "correct")
        {
            GameController.correctPlacement -= 1;

        }
        foreach (GameObject i in GameController.placeholders)
        {
            if(i.transform.position == transform.position)
            {
                i.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        pieceStatus = "pickedup";
        checkPlacement = "n";
        GetComponent<Renderer>().sortingOrder = 10;

    }

    void invControl()
    {
        if (yDiff < 110)
        {

            if ((Input.GetAxis("Mouse ScrollWheel") > 0) && (pieceStatus == "idle"))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 100f);
                invPos = transform.position;

                moved = true;

            }
        }
        if (yDiff > -100)
        {
            if ((Input.GetAxis("Mouse ScrollWheel") < 0) && (pieceStatus == "idle"))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 100f);
                invPos = transform.position;

                moved = true;
            }
        }
        if ((Input.GetKeyDown(returntoinv)) && (pieceStatus == "pickedup"))
        {
            transform.position = invPos;
            pieceStatus = "idle";

        }

    }
    void RotatePiece()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 90);

        }
    }


}
