using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthExecutioner : MonoBehaviour
{
    public ClassLoader classLoader;
    public KnightHealth knightHealth;
    public ArcherHealth archerHealth;
    public KnightAttack knightAttack;
    public ArcherAttack archerAttack;
    public KnightMovement knightMovement;
    public ArcherMovement archerMovement;
    public Animator anim;
    public Rigidbody2D rb;
    public Slider hpBar;
    public GameObject showDMG;
    public TextMeshProUGUI showDMGText;
    public Transform  playerTransform;
    public float timer;
    public float timer2;
    public float executionerMaxHealth = 50;
    public float executionerHealth;
    public bool executioneralive = true;
    public float kbForce;
    public float kbCounter;
    public float kbTotalTime;
    public float random;
    public bool knockFromRight;
    void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        anim = GetComponent<Animator>();
        executionerHealth = executionerMaxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        if (classLoader.isKnight)
        {
            knightMovement=player.GetComponent<KnightMovement>();
            knightAttack = player.GetComponent<KnightAttack>();
            knightHealth = player.GetComponent<KnightHealth>();
        }
        else
        {
            archerMovement = player.GetComponent<ArcherMovement>();
            archerAttack = player.GetComponent<ArcherAttack>();
            archerHealth = player.GetComponent<ArcherHealth>();
        }
        rb = GetComponent<Rigidbody2D>();
        hpBar.maxValue = executionerMaxHealth;
    }
    private void Update()
    {
        hpBar.value = executionerHealth;
        timer+=Time.deltaTime;
        timer2+=Time.deltaTime;
        if (timer > 0.4)
        {
            showDMG.SetActive(false);
        }
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Clicking2");
        if (classLoader.isKnight)
        {
            if (knightHealth.health > 0)
            {
                Debug.Log("Clicking");
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
                        executionerHealth -= damage;
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
            executionerHealth -= damage;
            showDMG.SetActive(true);
            showDMGText.text=Mathf.Round(damage).ToString();
            anim.SetBool("Hurt", true);
            timer = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Hitbox") && timer >= 0.5 && executioneralive)
        {
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
