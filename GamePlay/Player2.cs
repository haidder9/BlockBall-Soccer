using UnityEngine;

namespace Scenes.GamePlay
{
    public class Player2 : MonoBehaviour
    {
        float _moveSpeed;
        [SerializeField] private LayerMask platformsLayerMask;
        [SerializeField] private LayerMask platformsLayerMask2;
        private Rigidbody2D _rb;
        private BoxCollider2D _boxCollider2D;

        private void Awake()
        {
            _rb = transform.GetComponent<Rigidbody2D>();
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        }

        void Update()
        {
        
            if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
            {
                float jumpVelocity = 13f;
                _rb.velocity = Vector2.up * jumpVelocity;

            }
            HandleMovement();

        }

        private bool IsGrounded()
        {
            var bounds = _boxCollider2D.bounds;
            RaycastHit2D raycastHit2d = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .05f, platformsLayerMask);
            return raycastHit2d.collider != null;
        }

        private void HandleMovement()
        {
            _moveSpeed = 7f;
            if (Input.GetKey(KeyCode.DownArrow))
            {
                _rb.velocity = new Vector2(0, (_rb.velocity.y - (_moveSpeed/6)));
            }
            if (Input.GetKey(KeyCode.LeftArrow))  {
                _rb.velocity = new Vector2(-_moveSpeed, _rb.velocity.y);
            } else {
                if (Input.GetKey(KeyCode.RightArrow))  {
                    _rb.velocity = new Vector2(+_moveSpeed, _rb.velocity.y);
                } 
                else {
                    _rb.velocity = new Vector2(0, _rb.velocity.y);
                }
                

            }
            
        }





    }
}
