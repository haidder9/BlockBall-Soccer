using UnityEngine;

namespace Scenes.GamePlay
{
    public class Trigger : MonoBehaviour
    {
        public float moveSpeed;
        private Rigidbody2D _rb;
        private CircleCollider2D _circleCollider2D;
     
        private void Awake()
        {
            _rb = transform.GetComponent<Rigidbody2D>();
            _circleCollider2D = transform.GetComponent<CircleCollider2D>();
        }



        public AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
            {
                audioSource.Play();
            }
            if (collision.collider.gameObject.CompareTag("ExtraHit2"))
            {
                moveSpeed = -18f;
                _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);


            }
            if (collision.collider.gameObject.CompareTag("ExtraHit1"))
            {
                moveSpeed = +18f;
                _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);

            }
            if (collision.collider.gameObject.CompareTag("Crossbar"))
            {
                _rb.velocity = new Vector2(-7, 15);
            }
            if (collision.collider.gameObject.CompareTag("Crossbar1"))
            {
                _rb.velocity = new Vector2(7, 15);
            }


        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("goal") || collision.gameObject.CompareTag("goal2"))
            {
                _rb.velocity = new Vector2(0, 0);
                _rb.angularVelocity = 0;
            }
        }



    }
}