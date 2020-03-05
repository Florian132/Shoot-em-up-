using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public int health = 10;
    private Rigidbody2D rb;
    public float speed = -2.0f;
    public int pointsWorth;

    public Animator animator;

    //private float yPos = this.transform.position.y;

    private Vector2 finalY = new Vector2(0, 3);

    Highscore highscore;

    public GameObject stop;
    private void Start()
    {
         //yPos = this.transform.position.y;

        rb = GetComponent<Rigidbody2D>();

        highscore = GameObject.FindObjectOfType<Highscore>();

    }

    private void FixedUpdate()
    {



        rb.velocity= new Vector2(0, speed);
        //rb.velocity = new Vector2(0, speed);



        //if (yPos > 3.8)
        //{
        //    this.transform.position = new Vector3(0, yPos-0.01f, 0);
        //    yPos = this.transform.position.y;
        //}

        //if (rb.velocity.y == 0)
        //{
        //    this.transform.position = new Vector3(2 * Mathf.Sin(Time.time * speed), yPos, 0);
        //}


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
