using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScHandGun : MonoBehaviour
{
    float shootTimer=2f;
    /*bool canShoot = true;

    private void Update()
    {
        shootTimer = shootTimer - Time.deltaTime;
    }
    */

    [SerializeField] GameObject BulletGO;

    [SerializeField] private Transform bulletSpawnPoint;


    public void shoot(float angle)
    {
        Vector3 positionBullet = bulletSpawnPoint.position;
        Quaternion rotationBullet = Quaternion.Euler(0, 0, BulletGO.transform.eulerAngles.z+angle);
        GameObject bullet = Instantiate(BulletGO,positionBullet,rotationBullet);

        bullet.GetComponent<ScHandGunBullet>().shootBullet(angle);
        CinemachineShake.Instance.ShakeCamera(1f, .1f);
    }
}
