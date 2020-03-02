using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Enemy")
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        else if(hitInfo.tag == "Boss")
        {
            BossBehaviour boss = hitInfo.GetComponent<BossBehaviour>();

            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
        }      
        Destroy(gameObject);
    }
}
