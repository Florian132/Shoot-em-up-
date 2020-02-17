using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 1f;

    public float ReloadHW;

    public Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }


    private void FixedUpdate()
    {
        float Newposition = Mathf.Repeat(Time.time * speed, ReloadHW);
        transform.position = StartPosition + Vector3.up * Newposition;
    }

}