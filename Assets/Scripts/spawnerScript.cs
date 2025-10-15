using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject enemyShip;
    public int enemyCounter;
    private GameObject player;
    public GameObject asteroider;
    public GameObject enemyShip2;
    public int asteroidercounter;
    private int spawnShip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(enemyspawner());
        StartCoroutine(asteroiderspawner());
        StartCoroutine(enemy2spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator enemyspawner()
    {
        while (true)
        {
            if (enemyCounter < 3 && GameObject.Find("Player") != null)
            {
                int rull;
                rull = Random.Range(0, 1);
                if (rull = 0)
                {
                    spawnShip = enemyShip;
                }
                else
                {

                }
                    Instantiate(enemyShip, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
                enemyCounter++;
                yield return new WaitForSeconds(5);
            }
            else yield return null;
        }
    }
    IEnumerator asteroiderspawner()
    {
        while (true)
        {
            if (asteroidercounter < 3 && GameObject.Find("Player") != null)
            {
                Instantiate(asteroider, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(1,20));
            }
            else yield return null;
        }
    }
}