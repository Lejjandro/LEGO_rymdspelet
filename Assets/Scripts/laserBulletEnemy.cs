using UnityEngine;

public class laserBulletEnemy : MonoBehaviour
{
    public float BulletSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Destroy laser bullet after 5 seconds
        // Förstör laser bullet efter 5 sekunder
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // Laser bullet movement
        // Laser bullet rörelse
        transform.Translate(Vector3.down * BulletSpeed * Time.deltaTime);
    }

    // If laser bullet hit anything it gets destroyed.
    // Om laser bullet träffar något förstörs den.
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}