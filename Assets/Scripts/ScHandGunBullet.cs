using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScHandGunBullet : MonoBehaviour
{
    [SerializeField] public float bulletSpeed;
    [SerializeField] public float bulletDamage;
    [SerializeField] float lifeTime = 2f;
  



    public void shootBullet(float angle)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed*Mathf.Cos(angle*Mathf.PI/180), bulletDamage * Mathf.Sin(angle * Mathf.PI / 180));

       Destroy(this.gameObject,lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            BoxCollider2D m_ObjectCollider = this.gameObject.GetComponent < BoxCollider2D>(); m_ObjectCollider.isTrigger = false;
        }
    }
}
