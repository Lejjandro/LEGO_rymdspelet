using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    // Singleton instance
    // Singleton instans
    public static scoreManager instance;
    // UI elements for score and highscore
    // UI element f�r po�ng och highscore
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    
    int score = 0;
    int highscore = 0;

    private float resetHoldTimer = 3f;
    private float resettimer = 0f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load highscore from PlayerPrefs
        // Ladda highscore fr�n PlayerPrefs
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    void Update()
    {
        // Reset highscore if R is held for resetHoldTimer seconds
        // �terst�ll highscore om R h�lls intryckt i resetHoldTimer sekunder
        if (Input.GetKey(KeyCode.R))
        {
            resettimer += Time.deltaTime;
            if (resettimer >= resetHoldTimer)
            {
                ResetHighsocre();
                resettimer = 0f;
            }
        }
    }

    public void AddPoits(int amount)
    {
        // Add points to score
        // L�gg till po�ng till po�ngsumman
        score += amount;
        scoreText.text = "SCORE: " + score.ToString();

        // Check and update highscore
        // Kontrollera och uppdatera highscore
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    // Reset highscore to 0
    // �terst�ll highscore till 0
    public void ResetHighsocre()
    {
        highscore = 0;
        PlayerPrefs.SetInt("highscore", 0);
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
}