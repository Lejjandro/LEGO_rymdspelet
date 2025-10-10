using System;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class playerScript : MonoBehaviour
{
    //Player speed
    public float playerSpeed = 1f;
    //Player bullet
    public GameObject laserBullet;
    //Player bullet colldown
    private int counter = 0;
    private bool canShoot = true;
    //Player heath
    private int playerHealth = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0f, -4f, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        //player movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }

        //player laser
        if (Input.GetKeyDown(KeyCode.Space) && canShoot == true)
        {
            Instantiate(laserBullet, this.transform.position + new Vector3(0,0.7f,0), this.transform.rotation);
            //Player bullet colldown
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
        //player health
        playerHealth--;
        Debug.Log("player Health:" + playerHealth);
        if (playerHealth < 1)
        {
            Destroy(gameObject);
        }
    }


  
    
}