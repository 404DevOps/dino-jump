using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 5f;//10.6f;

    [SerializeField] private List<GameObject> platformPrefab;
    private int lastPlatformSpawned;
    private float spawnPosY = -4.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameActive)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        //if (GameManager.Instance.PlayerList != null)
        //{
            //if (GameManager.Instance.PlayerList.Any(m => m.gameObject.transform.position.y > spawnPosY - 6))
            if(GameObject.Find("Player").transform.position.y > spawnPosY -10)
            {
                spawnPosY += 2.0f;
                float spawnPosX = Random.Range(-spawnRange, spawnRange);
                int randomPlat = Random.Range(0, platformPrefab.Count);

                while (randomPlat != 0 && randomPlat == lastPlatformSpawned)
                {
                    randomPlat = Random.Range(0, platformPrefab.Count);
                }
                //Select Random Prefab from List
                Instantiate(platformPrefab[randomPlat], new Vector2(spawnPosX, spawnPosY), platformPrefab[randomPlat].transform.rotation);

                lastPlatformSpawned = randomPlat;
            }
        //}
    }
}
