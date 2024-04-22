using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;

public class ArcherMovement : MonoBehaviour
{
    //Player
    public Animator player;
    public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer Archer;
    public bool alive=true;
    public float timer;

    //Movement
    public float moveSpeed;
    public float horizontal;

    //Jump
    [SerializeField] private LayerMask jumpableGround;
    private BoxCollider2D coll;
    public float jumpForce;

    //Panels
    public GameObject deadpanel;

    //KnockBack
    public float kbForce;
    public float kbCounter;
    public float kbTotalTime;
    public bool knockFromRight;

    //SoundEffect
    public AudioManager audioManager;
    public float movementTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        rb=GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (kbCounter <= 0)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (alive && !anim.GetBool("Attack"))
            {
                movementTimer += Time.deltaTime;
                rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
                if (Input.GetKey(KeyCode.A) && movementTimer > 0.5 || Input.GetKey(KeyCode.D) && movementTimer > 0.5)
                {
                    audioManager.playSFX(audioManager.archerEffects[0]);
                    movementTimer = 0;
                }
            }

            
            if (Input.GetButtonDown("Jump") && IsGround() && player.GetBool("Pause") == false && alive && !anim.GetBool("Attack"))
            {
                anim.SetBool("Jump", true);
                rb.AddForce(Vector2.up * jumpForce);
            }
            else
            {
                anim.SetBool("Jump", false);
            }
        }
        else
        {
            if (knockFromRight)
            {
                rb.velocity = new Vector2(-kbForce,1);
            }

            if (!knockFromRight)
            {
                rb.velocity = new Vector2(kbForce, 1);
            }
            kbCounter -= Time.deltaTime;
        }
                                      
        //Movement Animation
        timer += Time.deltaTime;
        if (horizontal != 0)
        {
            timer = 0;
            anim.SetBool("Run", true);           
        }
        else
        {
            if (timer>=0.08)
            {
                anim.SetBool("Run", false);
            }
        }
    }

    private void FixedUpdate()
    {
        //Flip
        if (alive)
        {
            if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
    public bool IsGround()
    {
        anim.SetBool("Jump", false);
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Deadzone"))
        {
            alive=false;
            Time.timeScale = 0f;
            deadpanel.SetActive(true);
        }
    }
}
