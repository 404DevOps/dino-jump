using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public List<PlayerData> PlayerList {get; private set;}
    public bool isGameActive;
    public static GameManager Instance { get; private set; }
    public float Score = 0f;
    public string LobbyCode;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }

        //isGameActive = true;
        Instance = this;

        DontDestroyOnLoad(gameObject);

        UpdatePlayerList();        
    }

    internal void NewLobby(string code)
    {
        LobbyCode = code;
        SceneManager.LoadScene(1);
    }

    internal void JoinLobby(string code)
    {
        LobbyCode = code;
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        //if all players ready
        isGameActive = true;
        //SceneManager.LoadScene(2);
    }

    //public void AddNewPlayer(string name, Color color)
    //{
    //    PlayerData newPlayer = new PlayerData();
    //    newPlayer.Name = name;
    //    newPlayer.Color = color;
    //    newPlayer.playerState = PlayerState.NotReady;
    //    PlayerList.Add(newPlayer);

    //    Debug.Log("Player Added");
    //}

    public void GameOver()
    {
        isGameActive = false;
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            UpdatePlayerList();
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        float pos = GetHighestPlayerPosition() + 4.0f;
        var currentHeight = pos * 10;
        if (currentHeight > Score)
        {
            Score = Mathf.Round( pos * 10);
        }
    }

    public float GetHighestPlayerPosition()
    {
        //if (PlayerList?.Count < 1)
        //{
        //    return 0;
        //}
        //else 
        //{
        //    return PlayerList.Max(m => m.transform.position.y);
        //}
        var player = GameObject.Find("Player");
        if (player != null)
        {
            return player.transform.position.y;
        }
        else
        {
            return 0;

        }
    }

    void UpdatePlayerList()
    {
        ////empty the list to not get duplicates
        //PlayerList = new List<PlayerData>();

        ////find all players
        //var list = FindObjectsOfType<PlayerController>();
        //foreach (var item in list)
        //{
        //    //add to global list
        //    PlayerList.Add(item.GetComponent<PlayerData>());
        //}
        //if (PlayerList?.Count < 1)
        //{
        //    //GameOver();
        //}
    }
}
