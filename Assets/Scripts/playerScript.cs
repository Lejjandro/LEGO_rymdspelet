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
    private Vector3 move = new Vector3(0,0,0);
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
        //!!!!!!PROBLEM OM JAG TRYCKER 2 KEY SAMTID DEN STANNAR INTE!!!!!!!
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move += Vector3.right;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move -= Vector3.right;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move += Vector3.left;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move -= Vector3.left;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            move += Vector3.up;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            move -= Vector3.up;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            move += Vector3.down;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            move -= Vector3.down;
        }
        Debug.Log(move);
        move = move.normalized;

        
        transform.Translate(move * playerSpeed *  Time.deltaTime);

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
        GameObject.Find("Player").GetComponent<playerLifes>().life -= 1;
        Debug.Log("player Health:" + playerHealth);
    }


  
    
}