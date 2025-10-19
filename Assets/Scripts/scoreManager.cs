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
    // UI element för poäng och highscore
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    
    // Current score and highscore values
    // Nuvarande poäng och highscore värden
    int score = 0;
    int highScore = 0;
    
    // Time required to hold R to reset highscore
    // Tid som krävs för att hålla in R för att återställa highscore
    private float resetHoldTimer = 3f;
    private float resetTimer = 0f;

    // Double points status and timer
    // Status för dubbel poäng och timer    
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
        // Ladda highscore från PlayerPrefs
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    void Update()
    {
        // Reset highscore if R is held for resetHoldTimer seconds
        // Återställ highscore om R hålls intryckt i resetHoldTimer sekunder
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
    // Aktivera dubbel poäng för en specificerad varaktighet
    public void ActivateDoublePoints(float duration)
    {
        doublePoints = true;
        dublePointsTimer = duration;
        Debug.Log("Double Points activated!");
    }

    private void FixedUpdate()
    {
        // Handle double points timer
        // Hantera timer för dubbel poäng
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
        // Uppdatera färg på poängtext baserat på status för dubbel poäng
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
        // Lägg till poäng till poängsumman
        score += amount;
        scoreText.text = "SCORE: " + score.ToString();

        // Double points effect
        // Dubbel poäng effekt
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
    // Återställ highscore till 0
    public void ResetHighsocre()
    {
        highScore = 0;
        PlayerPrefs.SetInt("highscore", 0);
        highscoreText.text = "HIGHSCORE: " + highScore.ToString();
    }
}