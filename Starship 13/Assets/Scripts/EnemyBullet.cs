using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyBullet : MonoBehaviour
{
    public float speed = -4f;
    public Rigidbody2D rb;
    public int damage = 100;

    SpeedController speedController;
    // Start is called before the first frame update
    void Start()
    {
        speedController = FindObjectOfType<SpeedController>();
        speed = speedController.GetBulletSpeed();
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Deleter")
        {
            Destroy(gameObject);
        }
    }
}