using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovemen: MonoBehaviour
{
    //Movement
    public float horizontal;
    public float vertical=0;
    public PlayerStats playerStats;
    public PlayerHealt playerHealth;
    public Rigidbody2D rb;
    public Transform crosshairTransform;
    public SpriteRenderer playerSprite;
    public Animator anim;
    void Start()
    {
        playerHealth = GetComponent<PlayerHealt>();
        rb = GetComponentInChildren<Rigidbody2D>();
        GameObject crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        crosshairTransform = crosshair.GetComponent<Transform>();
        GameObject sprite = GameObject.FindGameObjectWithTag("Sprite");
        playerSprite = sprite.GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (playerHealth.alive)
        {
            //Movement
            horizontal = Input.GetAxisRaw("Horizontal");
            if(Input.GetKey(KeyCode.W)) 
            {
                vertical = 1;
            }
            if(Input.GetKey(KeyCode.S)) 
            {
                vertical = -1;
            }
            if(Input.GetKeyUp(KeyCode.W)) 
            {
                vertical = 0;
            }
            if(Input.GetKeyUp(KeyCode.S)) 
            {
                vertical = 0;
            }

            //vertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(horizontal * playerStats.Speed, vertical * playerStats.Speed);
            
            //Animation
            if (horizontal != 0 || vertical != 0)
            {
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false);
            }

            //Flip
            if (crosshairTransform.position.x > transform.position.x)
            {
                playerSprite.flipX = false;
            }
            else if (crosshairTransform.position.x < transform.position.x)
            {
                playerSprite.flipX = true;
            }
        }
    }
}
