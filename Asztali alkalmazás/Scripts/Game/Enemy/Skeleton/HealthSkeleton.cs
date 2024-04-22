using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSkeleton : MonoBehaviour
{
    public ClassLoader classLoader;
    public Transform playerTransform;
    public KnightAttack knightAttack;
    public ArcherAttack archerAttack;
    public KnightHealth knightHealth;
    public ArcherHealth archerHealth;
    public KnightMovement knightMovement;
    public ArcherMovement archerMovement;
    public GameObject showDMG;
    public TextMeshProUGUI showDMGText;
    public Animator anim;
    public Rigidbody2D rb;
    public Slider hpBar;
    public float timer;
    public float timer2;
    public float skeletonMaxHealth;
    public float skeletonHealth;
    public bool skeletonalive = true;
    public float kbForce;
    public float kbCounter;
    public float kbTotalTime;
    public bool knockFromRight;
    public int random;
    void Start()
    {
        anim = GetComponent<Animator>();
        skeletonHealth = skeletonMaxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        if (classLoader.isKnight)
        {
            knightAttack = player.GetComponent<KnightAttack>();
            knightHealth = player.GetComponent<KnightHealth>();
            knightMovement = player.GetComponent<KnightMovement>();
        }
        else
        {
            archerAttack = player.GetComponent<ArcherAttack>();
            archerHealth = player.GetComponent<ArcherHealth>();
            archerMovement = player.GetComponent<ArcherMovement>();
        }

        hpBar.maxValue = skeletonMaxHealth;
        rb=GetComponent<Rigidbody2D>();
        showDMGText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        hpBar.value = skeletonHealth;
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer > 0.3)
        {
            anim.SetBool("Hurt", false);
        }
        if (timer > 0.4)
        {
            showDMG.SetActive(false);
        }
    }
    public void TakeDamage(float damage)
    {
        if (classLoader.isKnight)
        {
            if (knightHealth.health > 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    knightAttack.click++;
                }
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    knightAttack.timer -= Time.deltaTime;
                    if (timer2>=1&&knightAttack.timer <= 0.5 && knightAttack.click <= 1)
                    {
                        showDMGText.color = Color.white;
                        random=Random.Range(1, 101);
                        if (knockFromRight)
                        {
                            rb.velocity = new Vector2(-kbForce, 1);
                        }

                        if (!knockFromRight)
                        {
                            rb.velocity = new Vector2(kbForce, 1);
                        }
                        kbCounter -= Time.deltaTime;
                        if (random <= knightAttack.critRate)
                        {
                            damage*=(1+(knightAttack.critDMG/100));
                            showDMGText.color= Color.red;
                        }
                        skeletonHealth -= damage;
                        showDMG.SetActive(true);
                        showDMGText.text=Mathf.Round(damage).ToString();
                        anim.SetBool("Hurt", true);
                        timer = 0;
                        knightAttack.timer = 0.75f;
                        knightAttack.spamdef = 0;
                    }
                }
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    knightAttack.timer = (float)0.5;
                }
            }
        
        }
        else
        {
            showDMGText.color = Color.white;
            random=Random.Range(1, 101);

            if (knockFromRight)
            {
                rb.velocity = new Vector2(-kbForce, 1);
            }

            if (!knockFromRight)
            {
                rb.velocity = new Vector2(kbForce, 1);
            }

            kbCounter -= Time.deltaTime;

            if (random <= archerAttack.critRate)
            {
                damage*=(1+(archerAttack.critDMG/100));
                showDMGText.color= Color.red;
            }

            skeletonHealth -= damage;
            showDMG.SetActive(true);
            showDMGText.text=Mathf.Round(damage).ToString();
            anim.SetBool("Hurt", true);
            timer=0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox") && knightMovement.alive && timer>=0.5)
        {
            kbCounter = kbTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                knockFromRight = false;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                knockFromRight = true;
            }
            TakeDamage(knightAttack.damage);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            kbCounter = kbTotalTime;
            if (playerTransform.transform.position.x <= transform.position.x)
            {
                knockFromRight = false;
            }
            if (playerTransform.transform.position.x >= transform.position.x)
            {
                knockFromRight = true;
            }
            TakeDamage(archerAttack.damage);
        }
    }

}