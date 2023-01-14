using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahnePortal : MonoBehaviour
{
    GameObject GameManager;
    int currentsceneID;
     void Start()
    {
        currentsceneID = SceneManager.GetActiveScene().buildIndex;
        GameManager = GameObject.FindWithTag("GM");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            // SceneManager.LoadScene(currentsceneID+ 1);
            GameManager.GetComponent<Sc_GameMenager>().LoadNextScene();
        }
    }
}
