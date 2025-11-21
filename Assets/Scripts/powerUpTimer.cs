using UnityEngine;
using UnityEngine.UI;

public class powerUpTimer : MonoBehaviour
{
    public Slider poweruptimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        poweruptimer.value -= 1 * Time.deltaTime;
    }
}
