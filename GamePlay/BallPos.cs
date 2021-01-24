using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPos : MonoBehaviour
{
    Vector2 originalPos;
    Quaternion originalRotation;
    private int CrossbarHit = 10;
    private int CrossbarHit2 = 10;


    void Start()
    {
        originalPos = transform.position;
        originalRotation = transform.rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "goal" || collision.gameObject.tag == "goal2")
        {
            gameObject.transform.position = originalPos;
            gameObject.transform.rotation = originalRotation;

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Crossbar")
        {
            
            CrossbarHit -= 1;
            if (CrossbarHit < 0)
            {
                gameObject.transform.position = originalPos;
                gameObject.transform.rotation = originalRotation;
                CrossbarHit = 10;
            }
        }
        if (collision.gameObject.tag == "Crossbar1")
        {

            CrossbarHit2 -= 1;
            if (CrossbarHit2 < 0)
            {
                gameObject.transform.position = originalPos;
                gameObject.transform.rotation = originalRotation;
                CrossbarHit2 = 10;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
