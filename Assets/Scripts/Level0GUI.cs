using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level0GUI : MonoBehaviour
{



    int sceneID;
    GameObject GameManagerObj;
    Sc_GameMenager GameManagerSc;
    // Start is called before the first frame update
    void Start()
    {
        sceneID = SceneManager.GetActiveScene().buildIndex;

        GameManagerObj = GameObject.FindWithTag("GM");
        GameManagerSc = GameManagerObj.GetComponent<Sc_GameMenager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void func_exit_button()
    {

        Application.Quit();
    }

    public void func_startNewGame()
    {

        // SceneManager.LoadScene(sceneID+1);
        GameManagerSc.MainMenuStart();
    }
    public void func_Settings()
    {

       // GameManagerSc.MainMenuLoad();
    }

     public void func_loadGame()
    {


    }

    public void func_saveGame()
    {


    }

}
