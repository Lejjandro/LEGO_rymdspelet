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
        // Fiende r�relse
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 5.5f, 0);
        }

        // If enemy health is less than 1 it gets destroyed and player get points.
        // Om fiende h�lsa �r mindre �n 1 f�rst�rs den och spelaren f�r po�ng.
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
            enemy_2_health -= 1;
        }

        // Om fiander tr�ffas player den f�rst�r sig.
        // If enemy hit the player it gets destroyed
        if (other.tag == "Player")
        {
            enemy_2_health -= 1;
        }
    }
}