using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class asteroiderScript : MonoBehaviour
{
    public float speed;
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
        //Om fiander tr�ffas player den f�rst�r sig.
        //if enemy hit the player it gets destroyed
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameObject.Find("enemySpawner").GetComponent<spawnScript>().enemyCounter -= 1;
        }
        if (other.tag == "laserBullet")
        {
            Destroy(gameObject);
            GameObject.Find("enemySpawner").GetComponent<spawnScript>().enemyCounter -= 1;
        }
    }
}