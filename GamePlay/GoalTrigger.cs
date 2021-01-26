using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.GamePlay
{
    public class GoalTrigger : MonoBehaviour
    {
        [FormerlySerializedAs("P2Goals")] public int p2Goals = 0;
        public Text scoreText2;
        private float _penaltyTimer;
        [FormerlySerializedAs("P1Penalty")] [SerializeField] Text p1Penalty;
        [FormerlySerializedAs("P1Penalty2")] [SerializeField] Text p1Penalty2;

        void Start()
        {
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball") && Timer.GameOver == false)
            {
                p2Goals++;
                scoreText2.text = p2Goals.ToString();
            }
            _penaltyTimer = 3f;
        }
        public void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag("Player"))
            {

                _penaltyTimer -= Time.deltaTime;
            }
            if (collision.gameObject.CompareTag("Player") && Timer.GameOver == false && _penaltyTimer < 0)
            {

                p2Goals++;
                _penaltyTimer = 3f;
                p1Penalty.text = "1 Point Penalty for Staying";
                p1Penalty2.text = "in your Goal too Long!";
                scoreText2.text = p2Goals.ToString();
                StartCoroutine(ExtraTime());

            }
        }
        IEnumerator ExtraTime()
        {
            yield return new WaitForSeconds(3f);
            p1Penalty.text = "";
            p1Penalty2.text = "";


        }


        void Update()
        {

        }
    }
}
