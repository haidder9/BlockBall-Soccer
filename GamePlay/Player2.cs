using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private LayerMask platformsLayerMask2;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            float jumpVelocity = 14.5f;
            rb.velocity = Vector2.up * jumpVelocity;

        }
        HandleMovement();

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .05f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

    private void HandleMovement()
    {
        moveSpeed = 8.5f;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0, (rb.velocity.y - (moveSpeed/6)));
        }
        if (Input.GetKey(KeyCode.LeftArrow))  {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        } else {
            if (Input.GetKey(KeyCode.RightArrow))  {
                rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
            } 
        else {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
                

        }
            
    }





}
