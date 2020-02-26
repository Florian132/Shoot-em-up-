using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;
    public float fireRate = 10;
    public int BulletsNumber = 1;
    private int ShootedBullets = 0;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        while (BulletsNumber != ShootedBullets)
        {
            timer += Time.deltaTime;
            if (timer < 1 / fireRate) return;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            ShootedBullets++;
            timer = 0;
        }
    }
}
