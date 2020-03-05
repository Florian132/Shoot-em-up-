using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    Spawner spawner;
    Enemy enemy;

    public float speed = -2;
    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

        if (spawner.Wave_Counter == 1)
        {

            speed = speed - 2.0f;
            Debug.Log("Something");
            spawner.Wave_Zero();
        }
    }
}
