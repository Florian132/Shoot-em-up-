using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1;
    public int BulletsNumber = 1;
    //private int ShootedBullets = 0;
    private float timer;
    public int bulletSpread;

    BossBehaviour bossRef;


    public float bulletSpeed = 2f;

    private void Start()
    {
        //90 + (180 / bulletsNumber) * bulletPos;
        //bulletSpread = 10 - (BossHealth / 2)
        bossRef = FindObjectOfType<BossBehaviour>();
    }

    // update is called once per frame
    void Update()
    {
        //while (BulletsNumber != ShootedBullets)
        //{
            timer += Time.deltaTime;
            if (timer < 1 / fireRate) return;

        bulletSpread = (10 - (bossRef.health / 2)) +1;

        for (int i = 1; i < bulletSpread; i++)
            {
                ShootBullet((180/bulletSpread) * i);
            }

            //ShootedBullets++;
            timer = 0;
        //}
    }



    private void ShootBullet(int angle)
    {
       GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation = Quaternion.Euler(0,0,90 + angle));
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        
    }
}
