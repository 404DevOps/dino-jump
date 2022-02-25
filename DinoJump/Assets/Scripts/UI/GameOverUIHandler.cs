using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIHandler : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text rankText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReturnToLobbyClick()
    {
        SceneManager.LoadScene(1);
    }
}
