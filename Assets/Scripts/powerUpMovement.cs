using System.Collections;
using UnityEngine;

public class powerUpMovement : MonoBehaviour
{
    public float speed;
    private Vector3 movement = Vector3.zero;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(powerUp_Movement());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement.normalized * speed * Time.deltaTime);

        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 5.5f, 0);
        }
    }
    IEnumerator powerUp_Movement()
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
}   
