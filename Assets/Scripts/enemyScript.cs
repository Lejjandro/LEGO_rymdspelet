using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy movement
        // Fiende r�relse
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 5.5f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player is hit by the enemy it takes damage.
        // Om spelaren tr�ffas av fiender tar den skada.
        if (other.tag == "Player")
        {
            other.transform.GetComponent<playerScript>().TakeDamage();
            Debug.Log("hit:" + other);
         
        }

        // If enemy get hit by the laser bullet it gets destroyed.
        // Om fiander tr�ffas av laserBullet f�rst�rs den.
        if (other.tag == "laserBullet")
        {
            scoreManager.instance.AddPoits(10);
            Destroy(gameObject);
            GameObject.Find("EnemySpawner").GetComponent<spawnScript>().enemyCounter -= 1;
        }

        // If enemy hit the player it gets destroyed.
        // Om fiander tr�ffas player den f�rst�r sig.
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameObject.Find("EnemySpawner").GetComponent<spawnScript>().enemyCounter -= 1;
        }
    }
}