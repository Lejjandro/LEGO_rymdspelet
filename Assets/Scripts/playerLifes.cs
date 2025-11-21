using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class playerLifes : MonoBehaviour
{
    public gameManagerScript gameManager;

    public int life;
    public GameObject[] Lifes;
    // Update is called once per frame
    void Update()
    {
        // Check player life and destroy life icons accordingly
        // Kolla spelarens liv och förstör livs ikoner därefter
        if (life < 1)
        {
            Destroy(Lifes[0].gameObject);
            gameManager.GameOver();
            Destroy(gameObject);
        }
        else if (life < 2)
        {
            Destroy(Lifes[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(Lifes[2].gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        // Reduce player life by damage
        // Minska spelarens liv med damage
        life -= damage;
    }
}