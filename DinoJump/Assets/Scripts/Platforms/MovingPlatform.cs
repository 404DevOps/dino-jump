using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : PlatformBase
{
    float moveBounds = 5.0f;
    float moveSpeed = 4.0f;
    float direction = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        //invert direction once bound is reached
        if (direction > 0 && Mathf.Round(transform.position.x) == moveBounds)
        {
            direction = -1;
        }
        else if(direction < 0 && Mathf.Round(transform.position.x) == -moveBounds)
        {
            direction = 1;
        }

        transform.Translate(Vector2.right * direction * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //make player move with platform when he stands on it
                collision.gameObject.transform.SetParent(this.transform);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //make player move with platform when he stands on it
            collision.gameObject.transform.SetParent(null);
        }
    }
}
