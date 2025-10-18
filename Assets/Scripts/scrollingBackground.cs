using UnityEngine;

public class scrollingBackground : MonoBehaviour
{
    public float scrollSpeed;

    [SerializeField]
    private Renderer backGroundRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        backGroundRenderer.material.mainTextureOffset += new Vector2(0f, scrollSpeed * Time.deltaTime);
    }
}
