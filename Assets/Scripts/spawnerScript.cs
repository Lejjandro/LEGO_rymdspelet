using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    // Enemy spawning
    // Fiende spawnning
    public GameObject enemyShip;
    public int enemyCounter;
    public GameObject enemyShip2;
    private GameObject spawnShip;

    // Reference to the player object
    // Referens till spelaren objekt
    private GameObject player;
    
    // Asteroid spawning
    // Asteroid spawnning
    public GameObject asteroider;
    public int asteroidercounter;

    public GameObject powerUpShild;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Starting the coroutines for spawning enemies and asteroids
        // Startar korutiner för att spawna fiender och asteroider
        StartCoroutine(enemyspawner());
        StartCoroutine(asteroiderspawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator enemyspawner()
    {
        // Spawning enemies
        // Spawnar fiender
        while (true)
        {
            
            if (enemyCounter < 3 && GameObject.Find("Player") != null)
            {
                // Randomly spawns either enemyShip or enemyShip2
                // Slumpar fram antingen enemyShip eller enemyShip2
                int rull;
                rull = Random.Range(0, 2);
                if (rull == 0)
                {
                    spawnShip = enemyShip;
                }
                else
                {
                    spawnShip = enemyShip2;
                }
                    Instantiate(spawnShip, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);

                enemyCounter++;

                yield return new WaitForSeconds(5);
            }
            else yield return null;
        }
    }
    IEnumerator asteroiderspawner()
    {
        // Spawning asteroids
        // Spawnar asteroider
        while (true)
        {
            if (asteroidercounter < 1 && GameObject.Find("Player") != null)
            {
                Instantiate(asteroider, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
                asteroidercounter++;
                yield return new WaitForSeconds(Random.Range(1,20));
            }
            else yield return null;
        }
    }
}