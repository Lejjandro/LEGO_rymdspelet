using System.Collections;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    public SpriteRenderer shieldSpriteRenderer;

    public int counter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        StartCoroutine(ShieldAnimation());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ShieldAnimation()
    {
        while (true)
        {

            if (shieldSpriteRenderer != null)
            {
                shieldSpriteRenderer.enabled = !shieldSpriteRenderer.enabled;
                yield return new WaitForSeconds(0.2f);
                
                
            }
        }
        yield return null;
    }
}
