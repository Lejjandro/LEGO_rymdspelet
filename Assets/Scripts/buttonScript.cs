using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restargame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Game Restarted");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Main Menu Loaded");
    }
}
