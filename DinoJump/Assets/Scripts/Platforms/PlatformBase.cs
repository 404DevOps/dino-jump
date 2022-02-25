using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBase : MonoBehaviour
{
    private void Update()
    {
        var deathBoxY = GameObject.FindGameObjectWithTag("DeathBox").transform.position.y;

        if (transform.position.y < (deathBoxY - 2))
        {
            Destroy(gameObject);
        }
    }
}
