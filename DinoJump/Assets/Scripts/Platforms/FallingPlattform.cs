using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FallingPlattform : PlatformBase
{
    private Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            Debug.Log("Collision from Top");
            StartCoroutine(FallingCountdown());
        }    
    }

    private IEnumerator FallingCountdown()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.AddComponent<Rigidbody2D>();
    }
}
