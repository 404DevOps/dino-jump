using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float spawnRange = 10.6f;

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private GameObject DeathBox;

    public static bool isGameActive;

    

    public static GameManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }

        isGameActive = true;

        Instance = this;

        float spawnPosY = -4.0f;
        float spawnPosX = 0f;
        for (int i = 0; i < 3; i++)
        {
            spawnPosY += 2.0f;
            spawnPosX = Random.Range(-spawnRange, spawnRange);
            SpawnPlatform(spawnPosX, spawnPosY);
        }
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
        RemoveLowPlatforms();
    }

    private void RemoveLowPlatforms()
    {
        var platforms = FindObjectsOfType<PlatformBase>();
        foreach (var platform in platforms) 
        {
            if (platform.transform.position.y < DeathBox.transform.position.y)
            { 
                Destroy(platform.gameObject);
            }
        }
    }

    void SpawnPlatform(float spawnPosX, float spawnPosY)
    {
        //Select Random Prefab from List
        Instantiate(platformPrefab, new Vector2(spawnPosX, spawnPosY), platformPrefab.transform.rotation);
    }
}
