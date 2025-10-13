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
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 5.5f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.GetComponent<playerScript>().TakeDamage();
            Debug.Log("hit:" + other);

        }
        if (other.tag == "laserBullet" && enemy_2_health < 1)
        {
            Destroy(gameObject);
            GameObject.Find("enemySpawner").GetComponent<spawnScript>().enemyCounter -= 1;
        }
        //Om fiander träffas player den förstör sig.
        //if enemy hit the player it gets destroyed
        if (other.tag == "Player" && enemy_2_health < 1)
        {
            Destroy(gameObject);
            GameObject.Find("enemySpawner").GetComponent<spawnScript>().enemyCounter -= 1;
        }
    }
}