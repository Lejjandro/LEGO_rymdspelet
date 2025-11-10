using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class enemyScript : MonoBehaviour
{

    public float speed;

    public int roll;
    public GameObject PowerUp1;
    public GameObject PowerUp2;
    public GameObject PowerUp3;

    private Vector3 movement = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(enemyMovement());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement.normalized * speed * Time.deltaTime);
    }
    // Enemy movement
    // Fiende rörelse
    IEnumerator enemyMovement()
    {
        while (true)
        {
            int rull = 0;
            while (rull == 0)
            {
                rull = Random.Range(-1, 2);
            }

            movement.x = rull;
            movement.y = -1;
            yield return new WaitForSeconds(1);
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
            On_Destroy();
        }

        // If enemy hit the player it gets destroyed.
        // Om fiander träffas player den förstör sig.
        if (other.tag == "Player")
        {
            On_Destroy();
        }
    }
    private void On_Destroy()
    {
        roll = Random.Range(0, 101);
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
        scoreManager.instance.AddPoits(10);
        GameObject.Find("EnemySpawner").GetComponent<spawnScript>().enemyCounter -= 1;
        Destroy(gameObject);
    }
}