using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_ingamecanvas : Singleton<Sc_ingamecanvas>
{
    [SerializeField] private GameObject InGameGUI;
    [SerializeField] private GameObject InGameMenu;
    [SerializeField] private GameObject Playerobj;
    [SerializeField] private PlayerHealth playerHealth;
    public Timer timersc;


    private bool isActive_InGameMenu = false;
    void Start()
    {
        InGameGUI = this.transform.GetChild(0).gameObject;
        InGameMenu = this.transform.GetChild(1).gameObject;

        isActive_InGameMenu = false;
        InGameMenu.SetActive(isActive_InGameMenu);

        Playerobj = GameObject.FindWithTag("Player");
        if (Playerobj!=null)

        {
            playerHealth = Playerobj.GetComponent<PlayerHealth>();
            this.SetPlayerGUIobjects();
        }
        else
        {

            Debug.LogError("InGameCanvas Script Error -> Player Object bulunamadý ");
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")||Input.GetKeyDown(KeyCode.P))
        {
            InGameMenu_Continue();
        }
    }


    public void InGameMenu_Continue()
    {

        if (isActive_InGameMenu==false)

        {
            isActive_InGameMenu = true;
            Time.timeScale = 0;
        }
        else
        {
            isActive_InGameMenu = false;
            Time.timeScale = 1;
        }
        InGameMenu.SetActive(isActive_InGameMenu);
    }

    public void InGameMenu_Load()
    {


    }

    public void InGameMenu_Save()
    {
      /*  if (Playerobj != null && playerHealth != null)
        {
            SaveLoad.SaveData(playerHealth);
        }
        else
        {
            Debug.Log("No pLAYER Obj & Script");
        }
       
     */
    }

    public void InGameMenu_EXIT()
    {

        Application.Quit();
    }

    public void setPlayer(GameObject Playerobj)
    {


    }

    public void SetPlayerGUIobjects()
    {
        Playerobj= GameObject.FindWithTag("Player");

        if (Playerobj!=null)
        {


            if (InGameGUI==null|| InGameMenu==null)
            {
                InGameGUI = this.transform.GetChild(0).gameObject;
                InGameMenu = this.transform.GetChild(1).gameObject;
            }
            //ScPlayerController=Playerobj.GetComponent<ScPlayerController>();
            // GameObject

            //timersc = Playerobj.GetComponent<Timer>();
            Timer timersc;

            GameObject TimerGo = GameObject.FindWithTag("Timemanager");
            if (TimerGo==null)
            {
                Debug.LogError("timergoeriþilemedi");
            }
            timersc = TimerGo.GetComponent<Timer>();
            timersc.SetGUIObjectTimer(TimerGo);
            timersc.SetTimerText(InGameGUI.transform.GetChild(1).gameObject);
            Playerobj.GetComponent<ScPlayerController>().SetParaText(InGameGUI.transform.GetChild(3).gameObject);
            
        }
        else
        {
            Debug.LogError("InGameCanvas Script Error -> Player Object bulunamadý ");
        }

    }
}
