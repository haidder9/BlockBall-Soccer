using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    [SerializeField] Text timeText;
    float currentTime = 0;
    float startingTime = 60f;
    [SerializeField] Text p1Goals;
    [SerializeField] Text p2Goals;
    [SerializeField] Text p1Winner;
    [SerializeField] Text p2Winner;
    [SerializeField] Text WinnerScore;
    [SerializeField] Text suddenDeath;
    GameObject Replay;
    public static bool GameOver = false;
    

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        Replay = GameObject.FindGameObjectWithTag("PlayAgain");
        Replay.SetActive(false);
    }
    IEnumerator StartDelay()
    {
        
        yield return new WaitForSeconds(5f);

        
        p1Winner.text = "";
        p2Winner.text = "";
        WinnerScore.text = "";

        
        Replay.SetActive(true);
        


        // if ()
        //{

        //}
    }
    IEnumerator ExtraTime()
    {
        yield return new WaitForSeconds(5f);
        suddenDeath.text = "";

        
    }



    // Update is called once per frame
    void Update()
    {   
        
        if (currentTime < 0)
        {
            GameOver = true;
            timeText.text = "Timer: 0";
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            if (Input.GetMouseButtonDown(0) && hit.collider.tag == "PlayAgain")
            {
                GameOver = false;
                SceneManager.LoadScene(1);
            }
        }
        if (currentTime >= -1)
        {
            currentTime -= 1 * Time.deltaTime;
            timeText.text = "Timer: " + currentTime.ToString("0");
            Debug.Log(GameOver);
        }
        if(currentTime.ToString("0") == "0")
        {
            int convertedGoalsP1 = 0;
            int convertedGoalsP2 = 0;

            Int32.TryParse(p1Goals.text, out convertedGoalsP1 );
            Int32.TryParse(p2Goals.text, out convertedGoalsP2);
            int Player1Goals = convertedGoalsP1;
            int Player2Goals = convertedGoalsP2;
            if(Player1Goals > Player2Goals)
            {
                p1Winner.text = "Player 1 Wins!";
                WinnerScore.text = Player1Goals.ToString() + " - " + Player2Goals.ToString();
                StartCoroutine(StartDelay());
            }
            if (Player2Goals > Player1Goals)
            {
                p2Winner.text = "Player 2 Wins!";
                WinnerScore.text = Player2Goals.ToString() + " - " + Player1Goals.ToString();
                StartCoroutine(StartDelay());
            }
            if (Player1Goals == Player2Goals)
            {
                currentTime = 30f;
                suddenDeath.text = "Extra Time!";
                StartCoroutine(ExtraTime());

            }


        }
        
    }
}
