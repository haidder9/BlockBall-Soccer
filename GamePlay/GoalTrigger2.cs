using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.GamePlay
{
    public class GoalTrigger2 : MonoBehaviour
    {
        [FormerlySerializedAs("P1Goals")] public int p1Goals = 0;
        public Text scoreText;
        private float _penaltyTimer;
        [FormerlySerializedAs("P2Penalty")] [SerializeField] Text p2Penalty;
        [FormerlySerializedAs("P2Penalty2")] [SerializeField] Text p2Penalty2;

        void Start()
        {
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball") && Timer.GameOver == false )
            {
                p1Goals++;
                scoreText.text = p1Goals.ToString();
            }
            _penaltyTimer = 3f;
        }
        public void OnTriggerStay2D(Collider2D collision)
        {
       
            if (collision.gameObject.CompareTag("Player2"))
            {
           
                _penaltyTimer -= Time.deltaTime;
            }
            if (collision.gameObject.CompareTag("Player2") && Timer.GameOver == false && _penaltyTimer < 0)
            {
            
                p1Goals++;
                _penaltyTimer = 3f;
                p2Penalty.text = "1 Point Penalty for Staying";
                p2Penalty2.text = "in your Goal too Long!";
                scoreText.text = p1Goals.ToString();
                StartCoroutine(ExtraTime());

            }
        }
        IEnumerator ExtraTime()
        {
            yield return new WaitForSeconds(3f);
            p2Penalty.text = "";
            p2Penalty2.text = "";


        }


        void Update()
        {
       
        }
    }
}
