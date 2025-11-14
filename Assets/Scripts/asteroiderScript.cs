using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class asteroiderScript : MonoBehaviour
{
    // Asteroid speed
    // Asteroid hastighet
    public float speed;

    public int roll;
    public GameObject PowerUp1;
    public GameObject PowerUp2;
    public GameObject PowerUp3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Asteroid movement
        // Asteroid rörelse
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 5.5f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player is hit by the enemy it takes damage.
        // Om spelaren träffas av fiender tar den skada.
        if (other.tag == "Player")
        {
            other.transform.GetComponent<playerScript>().TakeDamage();
            Debug.Log("hit:" + other);
        }
        // Om fiander träffas player den förstör sig.
        // If enemy hit the player it gets destroyed.
        if (other.tag == "Player")
        {
            On_Destroy();
        }
        if (other.tag == "laserBullet")
        {
            On_Destroy();
        }
    }
    private void On_Destroy()
    {
        roll = Random.Range(0, 1);
        if (roll <= 35)
        {

            roll = Random.Range(0, 4);
            if (roll == 1)
            {
                Instantiate(PowerUp1, this.transform.position, this.transform.rotation);
                GameObject.Find("PowerUpShild");
            }
            else if (roll == 2)
            {
                Instantiate(PowerUp2, this.transform.position, this.transform.rotation);
                GameObject.Find("PowerUpSpeedBoost");
            }
            else if (roll == 3)
            {
                Instantiate(PowerUp3, this.transform.position, this.transform.rotation);
                GameObject.Find("PowerUp2xPoints");
            }
        }
        scoreManager.instance.AddPoits(5);
        GameObject.Find("EnemySpawner").GetComponent<spawnScript>().asteroidercounter -= 1;
        Destroy(gameObject);
    }
}