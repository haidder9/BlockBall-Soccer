using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger2 : MonoBehaviour
{
    public int P1Goals = 0;
    public Text scoreText;
    private float PenaltyTimer;
    [SerializeField] Text P2Penalty;
    [SerializeField] Text P2Penalty2;

    void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && Timer.GameOver == false )
        {
            P1Goals++;
            scoreText.text = P1Goals.ToString();
        }
        PenaltyTimer = 3f;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player2")
        {
           
            PenaltyTimer -= Time.deltaTime;
        }
        if (collision.gameObject.tag == "Player2" && Timer.GameOver == false && PenaltyTimer < 0)
        {
            
            P1Goals++;
            PenaltyTimer = 3f;
            P2Penalty.text = "1 Point Penalty for Staying";
            P2Penalty2.text = "in your Goal too Long!";
            scoreText.text = P1Goals.ToString();
            StartCoroutine(ExtraTime());

        }
    }
    IEnumerator ExtraTime()
    {
        yield return new WaitForSeconds(3f);
        P2Penalty.text = "";
        P2Penalty2.text = "";


    }


    void Update()
    {
       
    }
}
