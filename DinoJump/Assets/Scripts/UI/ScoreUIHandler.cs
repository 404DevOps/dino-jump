using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreUIHandler : MonoBehaviour
{
    private Label scoreText;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        scoreText = root.Q<Label>("score-text");
    }

    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }
}
