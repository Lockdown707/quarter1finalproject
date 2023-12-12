using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreDisplayText;
    public TextMeshProUGUI gameOverText;
    public SpawnManager spawner;
    public SpawnManager spawnerTop;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Restart"))
        { 
            RestartGame();
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        spawner.isSpawning = false; 
        spawnerTop.isSpawning = (false);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
