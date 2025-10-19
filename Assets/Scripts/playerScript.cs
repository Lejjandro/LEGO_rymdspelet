using System;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class playerScript : MonoBehaviour
{
    // Player speed
    public float playerSpeed = 5f;
    
    // Player bullet
    public GameObject laserBullet;
    
    // Player bullet colldown
    private int counter = 0;
    private bool canShoot = true;

    // Player movement
    private Vector3 move = new Vector3(0,0,0);

    // Player sprites
    private SpriteRenderer spriteRenderer;
    public Sprite player;
    public Sprite playerRight;
    public Sprite playerLeft;
    public Sprite playerDamage;
    public Sprite playerDamage2;
    public Sprite playerDamageRight;
    public Sprite playerDamageRight2;
    public Sprite playerDamageLeft;
    public Sprite playerDamageLeft2;

    // Player Health
    public int playerHealth = 3;

    GameObject shield;

    private bool speedBoostActive = false;
    private float speedBoostTimer = 0f;
    public float speedBoostDuration = 5f;
    private float normalSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shield = transform.Find("Shield").gameObject;
        DeactivateShild();

        transform.position = new Vector3(0f, -4f, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();

        normalSpeed = playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        // Player movement
        // Player rörelse
        // !!!!chat GPT har fixat detta vissa till lärare!!!!
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        Vector3 move = new Vector3(moveX, moveY, 0f).normalized;

        transform.Translate(move * playerSpeed * Time.deltaTime);

        // Speed boost timer
        // Hastighetsökning timer
        if (speedBoostActive)
        {
            speedBoostTimer -= Time.deltaTime;
            if (speedBoostTimer <= 0f)
            {
                speedBoostActive = false;
                playerSpeed = normalSpeed;
                Debug.Log("Speed Boost deactivated!");
            }
        }

        // Player sprites change based on movement direction
        // Spelar sprites ändras baserat på rörelseriktning
        if (moveX < 0) 
        { 
            spriteRenderer.sprite = playerLeft;
        }
        else if (moveX > 0) 
        {
            spriteRenderer.sprite = playerRight;
        }
        else 
        {
            spriteRenderer.sprite = player;
        }

        // Player damage sprites based on health
        // Spelar skada sprites baserat på hälsa
        if (playerHealth == 2)
        {
            spriteRenderer.sprite = playerDamage;
        }
        else if (playerHealth == 1)
        {
            spriteRenderer.sprite = playerDamage2;
        }

        if (playerHealth == 2 && moveX > 0)
        {
            spriteRenderer.sprite = playerDamageRight;
        }
        else if (playerHealth == 2 && moveX < 0)
        {
            spriteRenderer.sprite = playerDamageLeft;
        }

        // Player laser
        // Spelare laser
        if (Input.GetKeyDown(KeyCode.Space) && canShoot == true)
        {
            // Instantiate laser bullet
            // Instansiera laser bullet
            Instantiate(laserBullet, this.transform.position + new Vector3(0,0.7f,0), this.transform.rotation);

            // Player bullet colldown
            // Spelar bullet colldown
            canShoot = false;
            counter = 0;
        }
        if (counter > 200)
        {
            counter = 0;
            canShoot = true;
        }

    }

    // Shield methods
    // Sköld metoder
    public void ActivateShild()
    {
        shield.SetActive(true);
    }

    public void DeactivateShild()
    {
        shield.SetActive(false);
    }

    public bool IsShieldActive()
    {
        return shield.activeSelf;
    }
    // Speed boost method
    // Hastighetsökning metod
    public void ActivateSpeedBoost(float duration)
    {
        if (!speedBoostActive)
        {
            speedBoostActive = true;
            playerSpeed += 2;
        }
        speedBoostTimer = speedBoostDuration;
        Debug.Log("Speed Boost activated!");

    }


    public void TakeDamage()
    {
        // Shield hit detection
        // Sköld träff detektion
        if (GetComponent<playerScript>().IsShieldActive())
        {
            GetComponent<playerScript>().DeactivateShild();
            Debug.Log("Shield hit!");
            return;
        }
        // Player health
        // Spelar hälsa
        playerHealth--;
        GameObject.Find("Player").GetComponent<playerLifes>().life -= 1;
        Debug.Log("player Health:" + playerHealth);
    }

    // Power-up collision detection
    // Power-up kollision detektion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        powerUps powerUp = collision.GetComponent<powerUps>();

        if (powerUp != null && powerUp.activateshield)
        {
            ActivateShild();
            scoreManager.instance.AddPoits(20);
            Destroy(collision.gameObject);
        }

        if (powerUp != null && powerUp.speedBoost)
        {
            ActivateSpeedBoost(speedBoostDuration);
            scoreManager.instance.AddPoits(20);
            Destroy(collision.gameObject);
        }

        if (powerUp != null && powerUp.doublePoints)
        {
            scoreManager.instance.ActivateDoublePoints(10f);
            scoreManager.instance.AddPoits(20);
            Destroy(collision.gameObject);
        }
    }




}