using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public int health = 10;
    private Rigidbody2D rb;
    public int speed = 1;
    public int pointsWorth;

    public Animator animator;

    private float yPos;

    Highscore highscore;


    private void Start()
    {
         yPos = this.transform.position.y;

        rb = GetComponent<Rigidbody2D>();

        highscore = GameObject.FindObjectOfType<Highscore>();

    }
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(2* Mathf.Sin(Time.time*speed), yPos, 0);
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
