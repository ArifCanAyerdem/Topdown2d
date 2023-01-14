using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class Sc_GameMenager : Singleton<Sc_GameMenager>
{
    [SerializeField] private GameObject PlayerPrefab;
    private GameObject Player;
    private ScPlayerController playerController;
    

    // [SerializeField] private GameObject CanvasPrefab;
    [SerializeField] private GameObject IngameCanvasPrefab;
    //Sound Manager
    [SerializeField] public GameObject SoundManagerPrefab;
    private GameObject SndManager;

    [SerializeField] private GameObject TimerPrefeb;

    private GameObject TimerGoo;
    private Timer timerr;




    // private GameObject InGameGUI;
    private GameObject Canvas;
    private Sc_ingamecanvas InGameCanvasScript;

    ScPlayerController pxdata;

    private bool StartAtBegginig = false;

    Scene currentScene;
    void Start()
    {
      currentScene = SceneManager.GetActiveScene();

        Player = Instantiate(PlayerPrefab,new Vector3(0,0,0),Quaternion.identity);
        playerController = Player.GetComponent<ScPlayerController>();

        TimerGoo = Instantiate(TimerPrefeb, new Vector3(0, 0, 0), Quaternion.identity);
        timerr = TimerGoo.GetComponent<Timer>();
        // Canvas=Instantiate(CanvasPrefab,, new Vector3(0, 0, 0), Quaternion.identity);
        // Canvas =InGameGUI.transform.GetChild(0).gameObject;
        Canvas =Instantiate(IngameCanvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        InGameCanvasScript = Canvas.GetComponent<Sc_ingamecanvas>();
        InGameCanvasScript.SetPlayerGUIobjects();


        
        //  pxdata = new ScPlayerController();
        // playerController.setPlayeData(pxdata);

        SndManager = Instantiate(SoundManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        
      

        if (currentScene.buildIndex==0)
        {
            Player.SetActive(false);
            Canvas.SetActive(false);
        }

    }

    // Update is called once per frame

    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
       //  Player.SetActive(true);
        // Canvas.SetActive(true);
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        if (SndManager == null)
        { SndManager = GameObject.FindWithTag("Soundmanager"); }

        if (SndManager != null)
        {
            SndManager.GetComponent<SoundManager>().changeMusicOnLevel();
        }
        else
        { Debug.LogError("Error Sound Manager not Found"); }

        GameObject cinemachine = GameObject.FindWithTag("cinemachine");
        if (cinemachine!=null)
        {
            Debug.Log("cinemachinee");

            if (Player==null)
            {
                Player = GameObject.FindWithTag("Player");
                Debug.Log("gamemanagernulll");
            }
            CinemachineVirtualCamera vcam = cinemachine.GetComponent<CinemachineVirtualCamera>();
            vcam.Follow = Player.transform;


        }


    }
    void Update()
    {
        
    }
    public void MainMenuStart()
    {
        StartAtBegginig = true;
        SceneManager.LoadScene(1);

        Player.SetActive(true);
        Canvas.SetActive(true);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    public void MainMenuLoad()
    {

        //active player gui
        Player.SetActive(true);
        Canvas.SetActive(true);

        //Load operations

          Player.SetActive(true);
          Canvas.SetActive(true);
          if (pxdata!=null)
         {
             SceneManager.LoadScene(pxdata.getPlayerSceneId());
              SceneManager.sceneLoaded += OnSceneLoaded;
         
    }
    }

    public void LoadNextScene()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex+1);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
}
