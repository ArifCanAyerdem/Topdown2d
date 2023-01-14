using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScPlayerController : Singleton<ScPlayerController>
{
    private float h_Input;
    private float v_Input;
    private Rigidbody2D playerRB;
    public Text Text;
    public int para;
   
    private float weaponAngle = 0f;

    private GameObject WeaponObj;

    [SerializeField]private float movementSpeed = 5.0f;
    public float weaponAwayRadius = 1f;

    private bool isWeaponEquipped;
    //Animator
    Animator p_Animator;
    private int sceneId = 1;
    public int getPlayerSceneId() { return this.sceneId; }


    private bool isIdle;
    private bool isWalkingX;
    private bool isWalkingY;
    private bool isWalking;
    private void Awake()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
        p_Animator = this.GetComponent<Animator>();
        isWeaponEquipped = false;

        isIdle = true;
        isWalkingX = false;
        isWalkingY = false;
        isWalking = false;
        
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    void ApplyMovement()
    {

        playerRB.velocity = new Vector2(h_Input * movementSpeed, v_Input*movementSpeed);
    }
    void CheckInput()
    {

       h_Input= Input.GetAxis("Horizontal");
        v_Input = Input.GetAxis("Vertical");

        if (h_Input > 0.01f || h_Input < -0.01f)
        {
            isIdle = false;
            isWalkingX = true;
            isWalking = true;
            p_Animator.SetBool("Isidleee", isIdle);
            p_Animator.SetBool("Bool_isWalking", isWalking);
            //p_Animator.SetBool("Bool_MovementX",isWalkingX);
            p_Animator.SetFloat("MoveX", h_Input);
        }
        if (v_Input > 0.01f || v_Input < -0.01f)
        {
            isIdle = false;
            isWalkingY = true;
            isWalking = true;
            p_Animator.SetBool("Isidleee", isIdle);
            p_Animator.SetBool("Bool_isWalking", isWalking);
            //p_Animator.SetBool("Bool_MovementY",isWalkingY);
            p_Animator.SetFloat("MoveY", v_Input);
        }
        if (h_Input < 0.01f && h_Input > -0.01f)
        {
            isWalkingX = false;
            //p_Animator.SetBool("Bool_MovementX",isWalkingX);
        }
        if (v_Input < 0.01f && v_Input > -0.01f)
        {
            isWalkingY = false;
            //p_Animator.SetBool("Bool_MovementY",isWalkingY); 
        }
        if (isIdle == false && isWalkingX == false && isWalkingY == false)
        {
            isWalking = false;
            //Debug.Log("Idle True State");
            isIdle = true;
            p_Animator.SetBool("Bool_isWalking", isWalking);
            p_Animator.SetBool("Isidleee", isIdle);

            StartCoroutine(WaitForIdleAnimation());

        }




        if (WeaponObj!=null && isWeaponEquipped==true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePos - this.transform.position; //WeaponObj.transform.position;
            float angle = Vector2.SignedAngle(Vector2.right, direction);
            weaponAngle = angle;
           // Debug.Log("Angle:"+angle+"-Rad:"+(angle*Mathf.PI/180));
            WeaponObj.transform.position = new Vector2(this.gameObject.transform.position.x+weaponAwayRadius*Mathf.Cos(angle * Mathf.PI / 180), this.gameObject.transform.position.y + weaponAwayRadius * Mathf.Sin(angle * Mathf.PI / 180));
            WeaponObj.transform.eulerAngles = new Vector3(0,0,angle);
        }
        if (isWeaponEquipped==true && Input.GetButtonDown("Fire1"))
        {
            if (WeaponObj != null)
            {
                WeaponObj.GetComponent<ScHandGun>().shoot(weaponAngle);
            }
            else {Debug.LogError("Error:" + WeaponObj);}




        }




    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isWeaponEquipped==false && col.CompareTag("Weapon"))
        {
            //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            WeaponObj = col.gameObject;
            col.transform.parent = this.gameObject.transform;
            col.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x+weaponAwayRadius, this.gameObject.transform.position.y-0.15f);
            isWeaponEquipped = true;
        }
        if (col.gameObject.tag=="Orb")
        {
            Destroy(col.gameObject);
            para += 1;
            Text.text = para.ToString();
        }

        
    }

    public void SetParaText(GameObject pp)
    {

        Text =pp.GetComponent<Text>();
    }
    //Coroutine for Changing Idle Animation
    IEnumerator WaitForIdleAnimation()
    {
        yield return new WaitForSeconds(0.1f);
       // Debug.Log("1 Sec");
        p_Animator.SetBool("Isidleee", false);
    }
}
