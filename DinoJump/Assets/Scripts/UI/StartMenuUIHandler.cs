using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartMenuUIHandler : MonoBehaviour
{
    Button startGameButton;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startGameButton = root.Q<Button>("start-game-button");
        startGameButton.clicked += StartGame;
    }

    public void StartGame()
    {
        Debug.Log("Start Game Clicked");
        GameManager.Instance.NewGame();
    }
}
