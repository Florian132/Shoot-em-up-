using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public int health = 10;
    private Rigidbody2D rb;
    public float speed = -2.0f;
    public int pointsWorth;

    private float yPos;

    float timeoffset;

    public Animator animator;

    //private float yPos = this.transform.position.y;

    //private Vector2 finalY = new Vector2(0, 3);

    Highscore highscore;

    public GameObject stop;
    private void Start()
    {
         yPos = this.transform.position.y;

        rb = GetComponent<Rigidbody2D>();

        highscore = GameObject.FindObjectOfType<Highscore>();


    }

    private void FixedUpdate()
    {



        //rb.velocity= new Vector2(0, speed);
        //rb.velocity = new Vector2(0, speed);



        if (yPos > 3.8)
        {
            rb.velocity = new Vector2(0, -1f);
            yPos = this.transform.position.y;
            timeoffset = Time.time;
        }

        else
        {
            this.transform.position = new Vector3(2 * Mathf.Sin((Time.time - timeoffset) * speed), yPos, 0);
        }


    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        animator.SetTrigger("HitTrigger");

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        highscore.addScore(pointsWorth);
        Destroy(gameObject);
    }
}
