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
    public Text iText;

    BulletsUi bulletsUI;

    public int chance = 30;
    private int JamChance;
    private bool Jammed1 = false;
    private bool Jammed2 = false;
    private bool Jammed3 = false;
    private int current;
    private KeyCode[] keys = {
        KeyCode.Alpha0,
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9
    };

    private KeyCode[] numpad =
    {
        KeyCode.Keypad0,
        KeyCode.Keypad1,
        KeyCode.Keypad2,
        KeyCode.Keypad3,
        KeyCode.Keypad4,
        KeyCode.Keypad5,
        KeyCode.Keypad6,
        KeyCode.Keypad7,
        KeyCode.Keypad8,
        KeyCode.Keypad9,
    };


    private void Start()
    {
        ammo = clipSize;
        bText = GameObject.Find("BulletsText").GetComponent<Text>();
        iText = GameObject.Find("InputText").GetComponent<Text>();
        ammunition = ammo.ToString();

        bulletsUI = GameObject.FindObjectOfType<BulletsUi>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(Jammed1)
        {
            if(Input.GetKeyDown(keys[current]) || Input.GetKeyDown(numpad[current]))
            { 
                current = Random.Range(0, 9);
                Debug.Log("Press " + current);
                iText.text = current.ToString();
                Jammed1 = false;
                Jammed2 = true;
            }
            for (int i = 0; i <= keys.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]) && !Input.GetKeyDown(keys[current]))
                {
                    current = Random.Range(0, 9);
                    iText.text = current.ToString();
                }
                if (Input.GetKeyDown(numpad[i]) && !Input.GetKeyDown(numpad[current]))
                {
                    current = Random.Range(0, 9);
                    iText.text = current.ToString();
                }
            }
        }

        if(Jammed2)
        {
            if(Input.GetKeyDown(keys[current]) || Input.GetKeyDown(numpad[current]))
            {
                current = Random.Range(0, 9);
                Debug.Log("Press " + current);

                iText.text = current.ToString();
                Jammed2 = false;
                Jammed3 = true;
            }
                for (int i = 0; i <= keys.Length; i++)
                {
                    if (Input.GetKeyDown(keys[i]) && !Input.GetKeyDown(keys[current]))
                    {
                        current = Random.Range(0, 9);
                        iText.text = current.ToString();
                    }
                if (Input.GetKeyDown(numpad[i]) && !Input.GetKeyDown(numpad[current]))
                {
                    current = Random.Range(0, 9);
                    iText.text = current.ToString();
                }
            }
        }
        if (Jammed3)
        {
            if (Input.GetKeyDown(keys[current]) || Input.GetKeyDown(numpad[current]))
            {
                Debug.Log("Reloading");
                ammo = clipSize;
                bulletsUI.bulletsReload();
                gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
                iText.text = null;
                isReloading = false;
                Jammed3 = false;
            }

            for (int i = 0; i <= keys.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]) && !Input.GetKeyDown(keys[current]))
                {
                    Debug.Log("Wrong Number Key Pressed!");
                    current = Random.Range(0, 9);
                    Debug.Log("Press " + current + " to reload!");
                    iText.text = current.ToString();
                }
                if (Input.GetKeyDown(numpad[i]) && !Input.GetKeyDown(numpad[current]))
                {
                    Debug.Log("Wrong Number Key Pressed!");
                    current = Random.Range(0, 9);
                    Debug.Log("Press " + current + " to reload!");
                    iText.text = current.ToString();
                }
            }
        }


        if (isReloading)
            return;

        //Change so the ammo doesn't update every single frame
        ammunition = ammo.ToString();
        bText.text = "Bullets: " + ammunition;
        //
        //Reload if ammo is less or equal to zero
        if (ammo <= 0)
        {
            JamChance = Random.Range(0, 100);
            if(JamChance <= chance)
            {
                GunJam();
            }
            else
            {
                StartCoroutine(Reload());
            }
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
    void GunJam()
    {
        Debug.Log("JAMMED");
        gameObject.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f);
        current = Random.Range(0, 9);
        Debug.Log("Press " + current);
        iText.text = current.ToString();
        isReloading = true;
        Jammed1 = true;     
    }
}
