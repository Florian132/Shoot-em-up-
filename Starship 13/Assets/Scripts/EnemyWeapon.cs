using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 10;
    public int BulletsNumber = 1;
    private int ShootedBullets = 0;
    private float timer;

    void Update()
    {
        while (BulletsNumber != ShootedBullets)
        {
            timer += Time.deltaTime;
            if (timer < 1 / fireRate) return;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            ShootedBullets++;
            timer = 0;
        }
    }
}
