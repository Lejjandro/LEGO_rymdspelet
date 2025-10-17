using UnityEngine;

public class laserBullet : MonoBehaviour
{
    public float bulletSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Destroy laser bullet after 5 seconds
        // F�rst�r laser bullet efter 5 sekunder
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // Laser bullet movement
        // Laser bullet r�relse
        transform.Translate(Vector3 .up * bulletSpeed * Time.deltaTime);
    }

    // If laser bullet hit anything it gets destroyed.
    // Om laser bullet tr�ffar n�got f�rst�rs den.
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}