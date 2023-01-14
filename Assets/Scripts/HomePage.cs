using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePage : MonoBehaviour
{
    bool isPaused = false;
    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        
    }
}
