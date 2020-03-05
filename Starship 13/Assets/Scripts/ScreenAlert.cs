using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAlert : MonoBehaviour
{
    public Animator animator;

    Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon = FindObjectOfType<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon.GetJamming())
        {
            animator.SetBool("IsJamming", true);
        }
        else
        {
            animator.SetBool("IsJamming", false);
        }
    }
}
