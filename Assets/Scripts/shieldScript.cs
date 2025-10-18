using UnityEngine;

public class shieldScript : MonoBehaviour
{
    public SpriteRenderer shieldSpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldSpriteRenderer != null)
        {
            shieldSpriteRenderer.enabled = !shieldSpriteRenderer.enabled;
        }
 
    }
}
