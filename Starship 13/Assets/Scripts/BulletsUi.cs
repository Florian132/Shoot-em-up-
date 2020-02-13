using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsUi : MonoBehaviour
{
    public int bullets;
    public int clip;

    public Image[] shots;
    public Sprite bullet_s;

    Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.FindObjectOfType<Weapon>();
        clip = weapon.clipSize;
        bullets = clip;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < shots.Length; i++)
        {
            if(i < bullets)
            {
                shots[i].enabled = true;
            }
            else
            {
                shots[i].enabled = false;
            }
        }
    }
    public void bulletsDown()
    {
        bullets--;
    }
    public void bulletsReload()
    {
        bullets = clip;
    }
}
