using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int clipSize = 6;
    private int ammo;
    public float reloadTime = 1f;

    private string ammunition;

    private bool isReloading = false;
    public Text bText;

    BulletsUi bulletsUI;

    private void Start()
    {
        ammo = clipSize;
        bText = GameObject.Find("BulletsText").GetComponent<Text>();
        ammunition = ammo.ToString();

        bulletsUI = GameObject.FindObjectOfType<BulletsUi>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        //Change so the ammo doesn't update every single frame
        ammunition = ammo.ToString();
        bText.text = "Bullets: " + ammunition;
        //
        //Reload if ammo is less or equal to zero
        if (ammo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        //Check if player hits the fire button, if yes then shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletsUI.bulletsDown();
        ammo--;
    }
    IEnumerator Reload()
    {
        //Display "Reloading..." in console 
        Debug.Log("Reloading...");
        gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f);
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        ammo = clipSize;
        bulletsUI.bulletsReload();
        gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
    }
}
