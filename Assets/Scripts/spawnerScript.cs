using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject enemyShip;
    private int enemyCounter;
    private GameObject player;
    public GameObject asteroider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(enemyspawner());
        StartCoroutine(asteroiderspawner());
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
                Instantiate (enemyShip, new Vector3(Random.Range(-8,8),7,0), Quaternion.identity);
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
            if (enemyCounter < 3 && GameObject.Find("Player") != null)
            {
                Instantiate(asteroider, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
                yield return new WaitForSeconds(5);
            }
            else yield return null;
        }
    }
}