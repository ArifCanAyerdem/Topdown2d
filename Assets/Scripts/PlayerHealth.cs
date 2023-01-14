using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    public Slider slider;
    [SerializeField] public float health = 100f;
    [SerializeField] private float maxHealth = 100f;

    private float timer;
    [SerializeField]private float timerMax = 2f;
    [SerializeField] private float healAmount = 10f;

    private bool isPlayerEntered = false;
    private bool healingState = false;

    public Gradient gradient;
    public Image fill;

    public PlayerHealth() { }
    public PlayerHealth(PlayerHealth playerCopyData) { }

    public void setPlayerData(PlayerHealth playerCopyData) {


       slider=playerCopyData.slider;
      health = playerCopyData.health;
      maxHealth = playerCopyData.maxHealth;

        timer = playerCopyData.timer;
        timerMax = playerCopyData.timerMax;
      healAmount = playerCopyData.healAmount;

     isPlayerEntered = playerCopyData.isPlayerEntered;
     healingState = playerCopyData.healingState;

        gradient = playerCopyData.gradient;
        fill = playerCopyData.fill;

}

    public void SetMaxHealth(float health)
    {
        
        slider.value = health;
        fill.color = gradient.Evaluate(1f);

    }
    
    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Start()
    {
        health = maxHealth;
        SetMaxHealth(maxHealth);

        timer = timerMax;
    }

    private void Update()
    {
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
        fill.color = gradient.Evaluate(slider.normalizedValue);



        if (Input.GetButton("Fire1") || isPlayerEntered == true)
        {
            if (healingState == false) healingState = true;
            {

            }
            if (healingState==true)
            {
                HealPlayer();
            }
        }

    }


    private void HealPlayer()
    {
        timer = timer - Time.deltaTime;
        if (timer<=0f)
        {
            timer = timerMax;
            health += healAmount;
        }

    }






    public void UpdateHealth(float mod)
    {

        health += mod;

        if (health>maxHealth)
        {
            health = maxHealth;

        }else if (health <= 0)
        {
            health = 0f;
           
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KirmiziPot")
        {

          
            isPlayerEntered = true;
          

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "KirmiziPot")
        {
            isPlayerEntered = false;
        }
    }


  /*  public ScPlayerController getPlayerData()
    {
        return PlayerHealth  ;

    }


    */
}
