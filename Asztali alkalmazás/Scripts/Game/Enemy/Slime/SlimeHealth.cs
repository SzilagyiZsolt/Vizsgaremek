using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHealth : MonoBehaviour
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
    public Slider hpBar;
    public Rigidbody2D rb;
    public float timer;
    public float timer2;
    public float slimeMaxHealth;
    public float slimeHealth;
    public bool slimealive = true;
    public float kbForce;
    public float kbCounter;
    public float kbTotalTime;
    public bool knockFromRight;
    public int random;
    void Start()
    {
        anim = GetComponent<Animator>();
        slimeHealth = slimeMaxHealth;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        playerTransform = player.GetComponent<Transform>();
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
        hpBar.maxValue = slimeMaxHealth;
        rb=GetComponent<Rigidbody2D>();
        showDMGText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        hpBar.value = slimeHealth;
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
                    if (timer2 >= 1 && knightAttack.timer <= 0.5 && knightAttack.click <= 1)
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
                        slimeHealth -= damage;
                        showDMG.SetActive(true);
                        showDMGText.text=Mathf.Round(damage).ToString();
                        anim.SetBool("Hurt", true);
                        timer = 0;
                        knightAttack.timer = 0.55f;
                        knightAttack.spamdef = 0;
                    }
                }
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    knightAttack.timer = 0.5f;
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
            slimeHealth -= damage;
            showDMG.SetActive(true);
            showDMGText.text=Mathf.Round(damage).ToString();
            anim.SetBool("Hurt", true);
            timer = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox") && knightMovement.alive && timer>=0.5)
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
