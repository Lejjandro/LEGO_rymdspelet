using UnityEngine;

public class backGroundScript : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translation: Vector3. down * speed);
        if (transform.position.y < -20f)
        {
            transform.position = startPosition;
        }
    }
}
