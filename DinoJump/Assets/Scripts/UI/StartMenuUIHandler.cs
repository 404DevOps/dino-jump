using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUIHandler : MonoBehaviour
{
    [SerializeField] InputField playerNameInput;
    [SerializeField] InputField lobbyCodeInput;

    void Start()
    {
    }

    public void NewLobby()
    {
        if (playerNameInput != null)
        {
            AddPlayer();
            string code = "NEWLOBBY";
            GameManager.Instance.NewLobby(code);
            
        }
    }

    public void JoinLobby()
    {
        if (lobbyCodeInput != null && playerNameInput != null)
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
