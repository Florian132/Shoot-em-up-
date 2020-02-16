using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private float moveInputX;
    private float moveInputY;
    public float speed;
    private Rigidbody2D rb;

    public int playerLives = 3;
    private string livesText;
    PolygonCollider2D m_Collider;

    private Text l_Text;

    Hearts hearts;



    // Start is called before the first frame update
    void Start()
    {
        // Assigns rigidbody of gameobject to rb
        rb = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<PolygonCollider2D>();

        //l_Text = GameObject.Find("LivesText").GetComponent<Text>();
        //DisplayLives();

        hearts = GameObject.FindObjectOfType<Hearts>();
    }

    private void FixedUpdate()
    {
        // Check for player inout on x and y axis
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");

        // Forces applied to player depending on speed
        rb.velocity = new Vector2(moveInputX * speed, moveInputY * speed);

        /*if(livesCheck > playerLives)
        {
            //DisplayLives();
            livesCheck = playerLives;
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(PlayerHit());
            //Debug.Log("Lives left: " + playerLives);
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            StartCoroutine(PlayerHit());
            Destroy(collision.gameObject);
            Debug.Log("Lives left: " + playerLives);
        }

    }
    public IEnumerator PlayerHit()
    {
        // Lose 1 life
        playerLives--;
        hearts.livesDown();
        if (playerLives == 0)
        {
            //DisplayLives();
            SceneManager.LoadScene("DeathScene");
            Destroy(gameObject);
        }
        // Remove collider for 1 second
        m_Collider.enabled = false;
        yield return new WaitForSeconds(1f);

        m_Collider.enabled = true;
    }
    /*void DisplayLives()
    {
        
        l_Text.text = "Lives: " + playerLives.ToString();
    }*/
}
