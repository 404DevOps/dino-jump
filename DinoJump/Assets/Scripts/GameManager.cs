using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float Score { get; private set;}
    public bool isGameActive;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (isGameActive)
        {
            UpdateScore();
        }
    }
    public void NewGame()
    {
        Score = 0f;
        isGameActive = true;
        SceneManager.LoadScene(1);  
    }

    public void GameOver()
    {
        isGameActive = false;
        SceneManager.LoadScene(2);
    }

    void UpdateScore()
    {
        float pos = GetHighestPosition(); //+ 4.0f;
        var currentHeight = pos * 10;
        if (currentHeight > Score)
        {
            Score = Mathf.Round( pos * 10);
        }
    }

    public float GetHighestPosition()
    {
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
}
