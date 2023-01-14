using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : Singleton<Timer>
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;
    public GameObject TimerGO;
    void Start()
    {
       // timerText = TimerGO.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        timerText.text = currentTime.ToString("0.0");
       
    }

    public void SetGUIObjectTimer(GameObject g1)
    {
        TimerGO = g1;

    }

    public void SetTimerText(GameObject x)
    {
        timerText = x.GetComponent<TextMeshProUGUI>();
        Debug.Log("settimertext");
    }
}
