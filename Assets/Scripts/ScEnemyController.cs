using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScEnemyController : MonoBehaviour
{


    private Transform playerPos;
    public float speed;
    public int healt;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    public GameObject blood;
    [SerializeField] private GameObject Orb;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            playerPos.position,
            speed * Time.deltaTime);
        if (healt <= 0)
        {
            Instantiate(Orb, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {


                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            healt--;
           
            Destroy(collision.gameObject, 0.3f);
            Instantiate(blood, transform.position, Quaternion.identity);

        }
        

    }


}
