<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private float moveInputX;
    private float moveInputY;
    public float speed;
    private Rigidbody2D rb;

    private int livesCheck = 3;
    public int playerLives = 3;
    private string livesText;
    CircleCollider2D m_Collider;

    private Text l_Text;



    // Start is called before the first frame update
    void Start()
    {
        // Assigns rigidbody of gameobject to rb
        rb = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<CircleCollider2D>();

        l_Text = GameObject.Find("LivesText").GetComponent<Text>();
        DisplayLives();
    }

    private void FixedUpdate()
    {
        // Check for player inout on x and y axis
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");

        // Forces applied to player depending on speed
        rb.velocity = new Vector2(moveInputX * speed, moveInputY * speed);

        if(livesCheck > playerLives)
        {
            DisplayLives();
            livesCheck = playerLives;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            StartCoroutine(PlayerHit());
            Debug.Log("Lives left: " + playerLives);
            

        }
    }
    IEnumerator PlayerHit()
    {
        // Lose 1 life
        playerLives--;
        if (playerLives == 0)
        {
            Destroy(gameObject);
        }
        // Remove collider for 1 second
        m_Collider.enabled = false;
        yield return new WaitForSeconds(1f);

        m_Collider.enabled = true;
    }
    void DisplayLives()
    {
        livesText = playerLives.ToString();
        l_Text.text = "Lives: " + livesText;
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private float moveInputX;
    private float moveInputY;
    public float speed;
    private Rigidbody2D rb;

    private int livesCheck = 3;
    public int playerLives = 3;
    private string livesText;
    CircleCollider2D m_Collider;

    private Text l_Text;



    // Start is called before the first frame update
    void Start()
    {
        // Assigns rigidbody of gameobject to rb
        rb = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<CircleCollider2D>();

        l_Text = GameObject.Find("LivesText").GetComponent<Text>();
        DisplayLives();
    }

    private void FixedUpdate()
    {
        // Check for player inout on x and y axis
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");

        // Forces applied to player depending on speed
        rb.velocity = new Vector2(moveInputX * speed, moveInputY * speed);

        if(livesCheck > playerLives)
        {
            DisplayLives();
            livesCheck = playerLives;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            StartCoroutine(PlayerHit());
            Debug.Log("Lives left: " + playerLives);
            

        }
    }
    IEnumerator PlayerHit()
    {
        // Lose 1 life
        playerLives--;
        if (playerLives == 0)
        {
            Destroy(gameObject);
        }
        // Remove collider for 1 second
        m_Collider.enabled = false;
        yield return new WaitForSeconds(1f);

        m_Collider.enabled = true;
    }
    void DisplayLives()
    {
        livesText = playerLives.ToString();
        l_Text.text = "Lives: " + livesText;
    }
}
>>>>>>> Stashed changes
