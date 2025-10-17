using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_2_Script : MonoBehaviour
{
    public float speed;
    public int enemy_2_health = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Enemy movement
        // Fiende rörelse
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 5.5f, 0);
        }

        // If enemy health is less than 1 it gets destroyed and player get points.
        // Om fiende hälsa är mindre än 1 förstörs den och spelaren får poäng.
        if (enemy_2_health < 1)
        {
            GameObject.Find("enemySpawner").GetComponent<spawnScript>().enemyCounter -= 1;
            scoreManager.instance.AddPoits(50);
            Destroy(gameObject);
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

        // If enemy get hit by the laser bullet it gets destroyed.
        // Om fiander träffas av laserBullet förstörs den.
        if (other.tag == "laserBullet")
        {
            enemy_2_health -= 1;
        }

        // Om fiander träffas player den förstör sig.
        // If enemy hit the player it gets destroyed
        if (other.tag == "Player")
        {
            enemy_2_health -= 1;
        }
    }
}