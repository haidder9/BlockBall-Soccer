using UnityEngine;

namespace Scenes.GamePlay
{
    public class BallPos : MonoBehaviour
    {
        Vector2 _originalPos;
        Quaternion _originalRotation;
        private int _crossbarHit = 10;
        private int _crossbarHit2 = 10;


        void Start()
        {
            var transform1 = transform;
            _originalPos = transform1.position;
            _originalRotation = transform1.rotation;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("goal") || collision.gameObject.CompareTag("goal2"))
            {
                var o = gameObject;
                o.transform.position = _originalPos;
                o.transform.rotation = _originalRotation;

            }
        
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Crossbar"))
            {
            
                _crossbarHit -= 1;
                if (_crossbarHit < 0)
                {
                    var o = gameObject;
                    o.transform.position = _originalPos;
                    o.transform.rotation = _originalRotation;
                    _crossbarHit = 10;
                }
            }
            if (collision.gameObject.CompareTag("Crossbar1"))
            {

                _crossbarHit2 -= 1;
                if (_crossbarHit2 < 0)
                {
                    var o = gameObject;
                    o.transform.position = _originalPos;
                    o.transform.rotation = _originalRotation;
                    _crossbarHit2 = 10;
                }
            }
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
