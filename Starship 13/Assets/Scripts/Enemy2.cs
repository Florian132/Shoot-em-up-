using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int health;
    private Rigidbody2D rb;
    public int enemySpeed;

    Highscore highscore;

    public int pointsWorth = 150;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        highscore = GameObject.FindObjectOfType<Highscore>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, enemySpeed);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

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
