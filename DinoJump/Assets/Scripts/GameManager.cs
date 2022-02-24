using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float spawnRange = 5.0f;//10.6f;

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private GameObject ScoreText;
    [SerializeField] private GameObject DeathBox;

    public static List<GameObject> PlayerList {get; private set;}

    public static bool isGameActive;
    public static GameManager Instance { get; private set; }
    private float spawnPosY = -4.0f;
    private float score = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }

        isGameActive = true;
        Instance = this;

        UpdatePlayerList();
        SpawnPlatform();
        
    }

    public void GameOver()
    {
        isGameActive = false;
        GameOverText.SetActive(true);
        //Show EndScreen
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerList();
        SpawnPlatform();
        UpdateScore();
    }

    void UpdateScore()
    {
        float pos = GetHighestPlayerPosition() + 4.0f;
        var currentHeight = pos * 10;
        if (currentHeight > score)
        {
            score = Mathf.Round( pos * 10);
        }
        
        ScoreText.GetComponent<Text>().text = "Score: " + score + "m";
    }

    public float GetHighestPlayerPosition()
    {
        if (PlayerList?.Count < 1)
        {
            return 0;
        }
        else 
        {
            return PlayerList.Max(m => m.transform.position.y);
        }
    }

    void UpdatePlayerList()
    {
        //empty the list to not get duplicates
        PlayerList = new List<GameObject>();

        //find all players
        var list = FindObjectsOfType<PlayerController>();
        foreach (var item in list)
        {
            //add to global list
            PlayerList.Add(item.gameObject);
        }
        if (PlayerList?.Count < 1)
        {
            GameOver();
        }
    }

    void SpawnPlatform()
    {
        if (PlayerList.Any(m => m.gameObject.transform.position.y > spawnPosY - 6))
        {
            spawnPosY += 2.0f;
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            //Select Random Prefab from List
            Instantiate(platformPrefab, new Vector2(spawnPosX, spawnPosY), platformPrefab.transform.rotation);
        }
    }
}
