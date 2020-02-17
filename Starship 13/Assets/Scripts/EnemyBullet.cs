using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyBullet : MonoBehaviour
{
    public float speed = -4f;
    public Rigidbody2D rb;
    public int damage = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void Update()
    {



    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //PlayerMove player = hitInfo.GetComponent<PlayerMove>();
        //if (player != null)
        //{
        //    StartCoroutine(player.PlayerHit());
        //    Destroy(gameObject);    
        //}
 
    }
}