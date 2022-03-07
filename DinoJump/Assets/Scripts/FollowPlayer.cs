using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var highestPlayerPosition = GameManager.Instance.GetHighestPosition();
        {
            if (highestPlayerPosition > transform.position.y)
            {
                var position = transform.position;
                position.y = highestPlayerPosition;
                transform.position = position;
            }
        }
    }
}

