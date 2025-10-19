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
    
    // Current score and highscore values
    // Nuvarande po�ng och highscore v�rden
    int score = 0;
    int highScore = 0;
    
    // Time required to hold R to reset highscore
    // Tid som kr�vs f�r att h�lla in R f�r att �terst�lla highscore
    private float resetHoldTimer = 3f;
    private float resetTimer = 0f;

    // Double points status and timer
    // Status f�r dubbel po�ng och timer    
    private bool doublePoints;
    public float dublePointsTimer = 0f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doublePoints = false;

        // Load highscore from PlayerPrefs
        // Ladda highscore fr�n PlayerPrefs
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    void Update()
    {
        // Reset highscore if R is held for resetHoldTimer seconds
        // �terst�ll highscore om R h�lls intryckt i resetHoldTimer sekunder
        if (Input.GetKey(KeyCode.R))
        {
            resetTimer += Time.deltaTime;
            if (resetTimer >= resetHoldTimer)
            {
                ResetHighsocre();
                resetTimer = 0f;
            }
        }
    }

    // Activate double points for a specified duration
    // Aktivera dubbel po�ng f�r en specificerad varaktighet
    public void ActivateDoublePoints(float duration)
    {
        doublePoints = true;
        dublePointsTimer = duration;
        Debug.Log("Double Points activated!");
    }

    private void FixedUpdate()
    {
        // Handle double points timer
        // Hantera timer f�r dubbel po�ng
        if (doublePoints)
        {
            dublePointsTimer -= Time.fixedDeltaTime;
            if (dublePointsTimer <= 0f)
            {
                doublePoints = false;
                Debug.Log("Double Points deactivated!");
            }
        }

        // Update score text color based on double points status
        // Uppdatera f�rg p� po�ngtext baserat p� status f�r dubbel po�ng
        if (doublePoints)
        {
            scoreText.color = Color.yellow;
        }
        else
        {
            scoreText.color = Color.white;
        }
    }

    public void AddPoits(int amount)
    {

        // Add points to score
        // L�gg till po�ng till po�ngsumman
        score += amount;
        scoreText.text = "SCORE: " + score.ToString();

        // Double points effect
        // Dubbel po�ng effekt
        if (doublePoints)
        {
            amount *= 2;
            Debug.Log("Double points active! Points gained: " + amount);
        }

        // Check and update highscore
        // Kontrollera och uppdatera highscore
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    // Reset highscore to 0
    // �terst�ll highscore till 0
    public void ResetHighsocre()
    {
        highScore = 0;
        PlayerPrefs.SetInt("highscore", 0);
        highscoreText.text = "HIGHSCORE: " + highScore.ToString();
    }
}