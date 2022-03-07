using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUIHandler : MonoBehaviour
{
    Label scoreText;
    Button backToLobby;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        scoreText = root.Q<Label>("score-text");
        backToLobby = root.Q<Button>("start-new-game-button");
        backToLobby.clicked += StartNewGame;

        scoreText.text = "Score: " + GameManager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(0);
    }
}
