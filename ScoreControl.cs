using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject generalScore;
    private GameObject tB;
    private GameObject time;

    void Start()
    {
        generalScore = GameObject.Find("Score");
        tB = GameObject.Find("TimeBonus");
        time = GameObject.Find("Time");
        GetComponent<Renderer>().sortingOrder = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.timeBonus <= 0)
        {
            GameController.timeBonus = 0;
        }
        GetComponent<TextMesh>().text = "Total Score: " + Mathf.RoundToInt(MovePiece.totalScore + GameController.timeBonus).ToString();
        generalScore.GetComponent<TextMesh>().text = "Score: " + Mathf.RoundToInt(MovePiece.totalScore).ToString();
        tB.GetComponent<TextMesh>().text = "Bonus for time: " + Mathf.RoundToInt(GameController.timeBonus).ToString();
        time.GetComponent<TextMesh>().text = "Time: " + Timer.timerText;
    }
}
