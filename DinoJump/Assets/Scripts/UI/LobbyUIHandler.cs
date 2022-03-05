using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class LobbyUIHandler : MonoBehaviour
{
    Button readyButton;
    Label lobbyCodeText;
    VisualElement playersList;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        readyButton = root.Q<Button>("ready-button");
        lobbyCodeText = root.Q<Label>("lobby-code");
        playersList = root.Q<VisualElement>("player-list");

        var label1 = new Label("Player1");
        label1.AddToClassList("player-list-label");

        var label2 = new Label("Player2");
        label2.AddToClassList("player-list-label");

        playersList.Add(label1);
        playersList.Add(label2);

        readyButton.clicked += OnPlayerReadyClick;

        SetLobbyCode();
    }

    void Update()
    {
        FillScrollView();
    }

    public void OnPlayerReadyClick()
    {
        GameManager.Instance.StartGame();
        gameObject.SetActive(false);
        //var player = GameManager.Instance.PlayerList.FirstOrDefault();
        //player.playerState = PlayerState.Ready;
    }

    void FillScrollView()
    {
        //if (GameManager.Instance != null && GameManager.Instance.PlayerList != null)
        //{
        //    foreach (var player in GameManager.Instance.PlayerList)
        //    {
        //        playersText.text += player.gameObject.name + Environment.NewLine;
        //        //scrollView.GetComponent<ScrollView>().Add(new VisualElement() { name = "asd" });
        //    }
        //}
    }

    void SetLobbyCode()
    {
        if (GameManager.Instance != null)
        {
            lobbyCodeText.text = GameManager.Instance.LobbyCode;
        }
    }
}
