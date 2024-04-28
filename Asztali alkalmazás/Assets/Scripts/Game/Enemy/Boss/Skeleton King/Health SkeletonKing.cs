using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSkeletonKing : MonoBehaviour
{
    public ClassLoader classLoader;
    public KnightAttack knightAttack;
    public ArcherAttack archerAttack;
    public Animator anim;
    public GameObject showDMG;
    public TextMeshProUGUI showDMGText;
    public Transform playerTransform;
    public Slider hpBar;
    public Rigidbody2D rb;
    public float timer;
    public float skeletonKingMaxHealth;
    public float skeletonKingHealth;
    public bool skeletonKingalive = true;
    public float kbForce;
    public float kbCounter;
    public float kbTotalTime;
    public bool knockFromRight;
    public int random;
    void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        anim = GetComponent<Animator>();
        skeletonKingHealth = skeletonKingMaxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        if (classLoader.isKnight)
        {
            knightAttack = player.GetComponent<KnightAttack>();
        }
        else
        {
            archerAttack = player.GetComponent<ArcherAttack>();
        }
        rb=GetComponent<Rigidbody2D>();
        hpBar.maxValue = skeletonKingMaxHealth;
    }
    void Update()
    {
        hpBar.value=skeletonKingHealth;
        timer += Time.deltaTime;
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
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                knightAttack.click++;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                knightAttack.timer -= Time.deltaTime;
                if (knightAttack.timer <= 0.5 && knightAttack.click <= 1)
                {
                    showDMGText.color = Color.white;
                    random = Random.Range(1, 101);
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
                    skeletonKingHealth -= damage;
                    anim.SetBool("Hurt", true);
                    showDMG.SetActive(true);
                    showDMGText.text=Mathf.Round(damage).ToString();
                    timer = 0;
                    knightAttack.timer = 1;
                    knightAttack.spamdef = 0;
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

            skeletonKingHealth -= damage;
            showDMG.SetActive(true);
            showDMGText.text=Mathf.Round(damage).ToString();
            anim.SetBool("Hurt", true);
            timer=0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox"))
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
