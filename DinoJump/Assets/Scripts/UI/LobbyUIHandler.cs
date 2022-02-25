using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LobbyUIHandler : MonoBehaviour
{
    [SerializeField] GameObject scrollView;
    [SerializeField] UnityEngine.UIElements.Button readyButton;
    [SerializeField] Text LobbyCodeText;
    [SerializeField] Text playersText;
    // Start is called before the first frame update
    void Start()
    {
        SetLobbyCode();
    }

    void Update()
    {
        FillScrollView();
    }

    public void OnPlayerReadyClick()
    {
        var player = GameManager.Instance.PlayerList.FirstOrDefault();
        player.playerState = PlayerState.Ready;
    }

    void FillScrollView()
    {
        if (GameManager.Instance != null && GameManager.Instance.PlayerList != null)
        {
            foreach (var player in GameManager.Instance.PlayerList)
            {
                playersText.text += player.gameObject.name + Environment.NewLine;
                //scrollView.GetComponent<ScrollView>().Add(new VisualElement() { name = "asd" });
            }
        }
    }

    void SetLobbyCode()
    {
        if (GameManager.Instance != null)
        {
            LobbyCodeText.text = GameManager.Instance.LobbyCode;
        }
    }
}
