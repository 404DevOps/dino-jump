using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartMenuUIHandler : MonoBehaviour
{
    TextField playerNameInput;
    TextField lobbyCodeInput;
    Button newLobbyButton;
    Button joinLobbyButton;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        playerNameInput = root.Q<TextField>("player-name-text");
        lobbyCodeInput = root.Q<TextField>("lobby-code-text");
        newLobbyButton = root.Q<Button>("new-lobby-button");
        joinLobbyButton = root.Q<Button>("join-lobby-button");

        newLobbyButton.clicked += NewLobby;
        joinLobbyButton.clicked += NewLobby;
    }

    public void NewLobby()
    {
        if (playerNameInput.text != null)
        {
            AddPlayer();
            string code = "NEWLOBBY";
            GameManager.Instance.NewLobby(code);
            
        }
    }

    public void JoinLobby()
    {
        if (lobbyCodeInput.text != null && playerNameInput != null)
        {
            AddPlayer();
            //GameManager.Instance.PlayerList.Add(new PlayerData());
            GameManager.Instance.JoinLobby(lobbyCodeInput.text);
        }
    }

    void AddPlayer()
    {
        //GameManager.Instance.AddNewPlayer(playerNameInput.text, new Color());
    }
}
