using System;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class playerScript : MonoBehaviour
{
    // Player speed
    public float playerSpeed = 1f;
    
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
    public Sprite playerRigth;
    public Sprite playerLeft;
    public Sprite playerDamage;

    // Player Health
    public int playerHealth = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0f, -4f, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        // Player sprites change based on movement direction
        // Spelar sprites ändras baserat på rörelseriktning
        if (moveX < 0) { 
            spriteRenderer.sprite = playerLeft;
        }
        else if (moveX > 0) {
            spriteRenderer.sprite = playerRigth;
        }
        else {
            spriteRenderer.sprite = player;
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
    public void TakeDamage()
    {
        // Player health
        // Spelar hälsa
        playerHealth--;
        GameObject.Find("Player").GetComponent<playerLifes>().life -= 1;
        Debug.Log("player Health:" + playerHealth);
    }


  
    
}