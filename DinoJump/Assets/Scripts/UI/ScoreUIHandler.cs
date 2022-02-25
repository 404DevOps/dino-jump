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
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }
}
