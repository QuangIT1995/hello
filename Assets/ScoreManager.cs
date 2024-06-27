using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public TextMeshProUGUI gameOverText;
    public GameObject winnerPanel;
    public TextMeshProUGUI winnerText;
    public int score = 0;
    public int scoreLimit = 40;
    public float countdownTime = 30f; // Set the countdown time to 30 seconds
    private bool isGameActive;
    private float currentTime;

    public GameObject player;
    public GameObject gemSpawn;
    public GameObject minusSpawn;
    public GameObject multiplySpawn;
    public GameObject extendTimeSpawn;
    public GameObject speedBoostSpawn;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreText();

        isGameActive = true;
        gameOverPanel.SetActive(false); // Ensure the Game Over panel is hidden at the start
        winnerPanel.SetActive(false);
        currentTime = countdownTime;
        StartCoroutine(CountdownTimer());
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimeText(float currentTime)
    {
        int seconds = Mathf.FloorToInt(currentTime);
        timeText.text = "Time: " + seconds.ToString();
    }

    IEnumerator CountdownTimer()
    {
        while (currentTime > 0)
        {
            if (isGameActive)
            {
                currentTime -= Time.deltaTime;
                UpdateTimeText(currentTime);
                yield return null;
            }
        }

        // Ensure the time displays as 0 when the countdown ends
        UpdateTimeText(0);
        EndGame();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();

        if(score >= scoreLimit) 
        {
            WinGame();
        }
    }

    public void MinusScore(int amount) 
    {
        score -= amount;
        UpdateScoreText();
    }

    public void MultipleScore(int amount)
    {
        if(score >= 0) 
        {
            score *= amount;
            UpdateScoreText();
        }
    }

    public void ExtendTime(float amount)
    {
        currentTime += amount;
        UpdateTimeText(currentTime);
    }

    public void EndGame()
    {
        isGameActive = false;
        gameOverPanel.SetActive(true); // Show the Game Over panel
        gameOverText.text = "Game over\nFinal Score: " + score;
        // Add any additional game over logic here (e.g., disable player movement)
        player.SetActive(false);
        gemSpawn.SetActive(false);
        minusSpawn.SetActive(false);
        multiplySpawn.SetActive(false);
        extendTimeSpawn.SetActive(false);
        speedBoostSpawn.SetActive(false);
        Debug.Log("Game Over!");
    }

    public void WinGame() 
    {
        winnerPanel.SetActive(true);
        winnerText.text = "Congrantulation!";
        player.SetActive(false);
        gemSpawn.SetActive(false);
        minusSpawn.SetActive(false);
        multiplySpawn.SetActive(false);
        extendTimeSpawn.SetActive(false);
        speedBoostSpawn.SetActive(false);
    }
}
