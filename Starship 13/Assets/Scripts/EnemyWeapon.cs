using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    GameObject bulletPrefab;
    Transform firePoint;
    public float fireRate = 10;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 1 / fireRate) return;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        timer = 0;
    }
}
