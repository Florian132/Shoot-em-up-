using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    Spawner spawner;

    public float speed;

    private float speedChange;

    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        speed = -1;

        spawner = FindObjectOfType<Spawner>();

        speedChange = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {

        if (spawner.Wave_Counter == 1)
        {
            if(speed > -5)
            {
                speed = speed - (speedChange);
            }
            else
            {
                speed = -5;
            }
            
            //Debug.Log(speed);
            spawner.Wave_Zero();

            bulletSpeed = speed * 1.5f;
        }
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }
}
