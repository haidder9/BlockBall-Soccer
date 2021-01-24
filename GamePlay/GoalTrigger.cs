using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger : MonoBehaviour
{
    public int P2Goals = 0;
    public Text scoreText2;
    private float PenaltyTimer;
    [SerializeField] Text P1Penalty;
    [SerializeField] Text P1Penalty2;

    void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && Timer.GameOver == false)
        {
            P2Goals++;
            scoreText2.text = P2Goals.ToString();
        }
        PenaltyTimer = 3f;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            PenaltyTimer -= Time.deltaTime;
        }
        if (collision.gameObject.tag == "Player" && Timer.GameOver == false && PenaltyTimer < 0)
        {

            P2Goals++;
            PenaltyTimer = 3f;
            P1Penalty.text = "1 Point Penalty for Staying";
            P1Penalty2.text = "in your Goal too Long!";
            scoreText2.text = P2Goals.ToString();
            StartCoroutine(ExtraTime());

        }
    }
    IEnumerator ExtraTime()
    {
        yield return new WaitForSeconds(3f);
        P1Penalty.text = "";
        P1Penalty2.text = "";


    }


    void Update()
    {

    }
}
