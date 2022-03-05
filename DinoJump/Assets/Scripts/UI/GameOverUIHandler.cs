using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUIHandler : MonoBehaviour
{
    Label scoreText;
    Label rankText;
    Button backToLobby;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        scoreText = root.Q<Label>("score-text");
        rankText = root.Q<Label>("rank-text");
        backToLobby = root.Q<Button>("return-lobby-button");
        backToLobby.clicked += OnReturnToLobbyClick;

        scoreText.text = "Score: " + GameManager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReturnToLobbyClick()
    {
        GameManager.Instance.Score = 0;
        SceneManager.LoadScene(1);
    }
}
