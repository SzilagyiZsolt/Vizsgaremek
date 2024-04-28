using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBrownSlime : MonoBehaviour
{
    public ClassLoader classLoader;
    public KnightAttack knightAttack;
    public ArcherAttack archerAttack;
    public KnightMovement knightMovement;
    public KnightHealth knightHealth;
    public ArcherMovement archerMovement;
    public Transform playerTransform;
    public Animator anim;
    public SpriteRenderer brownSlime;
    public GameObject showDMG;
    public TextMeshProUGUI showDMGText;
    public Rigidbody2D rb;
    public Slider hpBar;
    public float timer;
    public float timer2;
    public float brownSlimeMaxHealth=500;
    public float brownSlimeHealth=500;
    public bool brownSlimealive = true;
    public float kbForce;
    public float kbCounter;
    public float kbTotalTime;
    public bool knockFromRight;
    public int random;
    void Start()
    {
        anim = GetComponent<Animator>();
        brownSlimeHealth = brownSlimeMaxHealth;
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        if (classLoader.isKnight)
        {
            knightAttack = player.GetComponent<KnightAttack>();
            knightMovement = player.GetComponent<KnightMovement>();
            knightHealth = player.GetComponent<KnightHealth>();
        }
        else
        {
            archerAttack = player.GetComponent<ArcherAttack>();
            archerMovement = player.GetComponent<ArcherMovement>();
        }
        hpBar.maxValue = brownSlimeMaxHealth;
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        hpBar.value = brownSlimeHealth;
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer > 0.3)
        {
            brownSlime.color = Color.white;
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
                        brownSlimeHealth -= damage;
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
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                knightAttack.timer = (float)0.5;
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

            brownSlimeHealth -= damage;
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
