using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIHandler : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    void Update()
    {
        Debug.Log("Score Update in UIHandler");
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }
}
