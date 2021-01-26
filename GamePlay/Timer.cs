using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.GamePlay
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] Text timeText;
        float _currentTime = 0;
        float startingTime = 60f;
        [SerializeField] Text p1Goals;
        [SerializeField] Text p2Goals;
        [SerializeField] Text p1Winner;
        [SerializeField] Text p2Winner;
        [FormerlySerializedAs("WinnerScore")] [SerializeField] Text winnerScore;
        [SerializeField] Text suddenDeath;
        GameObject _replay;
        public static bool GameOver = false;
    

        // Start is called before the first frame update
        void Start()
        {
            _currentTime = startingTime;
            _replay = GameObject.FindGameObjectWithTag("PlayAgain");
            _replay.SetActive(false);
        }
        IEnumerator StartDelay()
        {
        
            yield return new WaitForSeconds(5f);

        
            p1Winner.text = "";
            p2Winner.text = "";
            winnerScore.text = "";

        
            _replay.SetActive(true);
        


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
        
            if (_currentTime < 0)
            {
                GameOver = true;
                timeText.text = "Timer: 0";
                if (Camera.main is { })
                {
                    Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
                    if (Input.GetMouseButtonDown(0) && hit.collider.CompareTag("PlayAgain"))
                    {
                        GameOver = false;
                        SceneManager.LoadScene(1);
                    }
                }
            }
            if (_currentTime >= -1)
            {
                _currentTime -= 1 * Time.deltaTime;
                timeText.text = "Timer: " + _currentTime.ToString("0");
               }
            
            if(_currentTime.ToString("0") == "0")
            {
                Int32.TryParse(p1Goals.text, out var convertedGoalsP1 );
                Int32.TryParse(p2Goals.text, out var convertedGoalsP2);
                int player1Goals = convertedGoalsP1;
                int Player2Goals = convertedGoalsP2;
                if(player1Goals > Player2Goals)
                {
                    p1Winner.text = "Player 1 Wins!";
                    winnerScore.text = player1Goals.ToString() + " - " + Player2Goals.ToString();
                    StartCoroutine(StartDelay());
                }
                if (Player2Goals > player1Goals)
                {
                    p2Winner.text = "Player 2 Wins!";
                    winnerScore.text = Player2Goals.ToString() + " - " + player1Goals.ToString();
                    StartCoroutine(StartDelay());
                }
                if (player1Goals == Player2Goals)
                {
                    _currentTime = 30f;
                    suddenDeath.text = "Extra Time!";
                    StartCoroutine(ExtraTime());

                }


            }
        
        }
    }
}
