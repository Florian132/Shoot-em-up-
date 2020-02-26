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

    public Animator animator;

    public int playerLives = 3;
    public int invulnTime;
    private string livesText;
    PolygonCollider2D m_Collider;

    private Text l_Text;

    Highscore highscore;
    Hearts hearts;
    Weapon gunjam;

    bool invulnerable = false;



    // Start is called before the first frame update
    void Start()
    {
        // Assigns rigidbody of gameobject to rb
        rb = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<PolygonCollider2D>();

        //l_Text = GameObject.Find("LivesText").GetComponent<Text>();
        //DisplayLives();

        highscore = GameObject.FindObjectOfType<Highscore>();
        hearts = GameObject.FindObjectOfType<Hearts>();
        gunjam = GameObject.FindObjectOfType<Weapon>();
    }

    /*private void OnDestroy()
    {
        Physics2D.IgnoreLayerCollision(8, 10, false);
        Physics2D.IgnoreLayerCollision(8, 12, false);
    }*/

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
        if(invulnerable == false)
        {
<<<<<<< Updated upstream

            PlayerHit();
            Destroy(collision.gameObject);
            //Debug.Log("Lives left: " + playerLives);
        }
=======
            if (collision.gameObject.tag == "Enemy")
            {
                PlayerHit();
                Destroy(collision.gameObject);
                //Debug.Log("Lives left: " + playerLives);
            }
>>>>>>> Stashed changes

            if (collision.gameObject.tag == "EnemyBullet")
            {
                PlayerHit();
                Destroy(collision.gameObject);
                Debug.Log("Lives left: " + playerLives);
            }
        }
    }
    private void PlayerHit()
    {
<<<<<<< Updated upstream
        // Lose 1 life
        playerLives--;
        hearts.livesDown();
        gunjam.chance = 30;
        if (playerLives == 0)
=======
        if(invulnerable == false)
>>>>>>> Stashed changes
        {
            if(playerLives > 1)
            {
                StartCoroutine("playerInvulnerable");
            }
            playerLives--;
            hearts.livesDown();
            
            if (playerLives == 0)
            {
                highscore.saveYourScore();
                highscore.newHighScoreCheck();
                //DisplayLives();
                SceneManager.LoadScene("DeathScene");
                Destroy(gameObject);
            }
        }
<<<<<<< Updated upstream
        else if(playerLives == 1)
        {
            gunjam.chance = 70;
        }
=======
        // Lose 1 life
        
    }

    IEnumerator playerInvulnerable()
    {

        //Play invulnerable animation
        //Make player invulnerable to damage
        invulnerable = true;
        animator.SetBool("Invuln", true);

        Physics2D.IgnoreLayerCollision(8, 10, true);
        Physics2D.IgnoreLayerCollision(8, 12, true);
        yield return new WaitForSeconds(invulnTime);
        Physics2D.IgnoreLayerCollision(8, 10, false);
        Physics2D.IgnoreLayerCollision(8, 12, false);
        invulnerable = false;
        animator.SetBool("Invuln", false);
>>>>>>> Stashed changes
    }
    /*void DisplayLives()
    {
        
        l_Text.text = "Lives: " + playerLives.ToString();
    }*/
}
