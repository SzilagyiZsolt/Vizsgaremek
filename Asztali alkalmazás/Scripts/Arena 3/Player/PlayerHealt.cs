using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealt : MonoBehaviour
{

    public EnemyDamage enemyDamage;
    public PlayerStats playerStats;
    public Animator anim;
    public Slider hpSlider;
    public GameObject death;
    public bool alive = true;
    public float timer;

    private void Start()
    {
        GameObject logicManager = GameObject.FindGameObjectWithTag("LogicManager");
        enemyDamage = logicManager.GetComponent<EnemyDamage>();
        anim = GetComponentInChildren<Animator>();
        playerStats = GetComponent<PlayerStats>();
        hpSlider = GetComponentInChildren<Slider>();
        hpSlider.maxValue = playerStats.HP;
    }

    void Update()
    {
        hpSlider.value = playerStats.HP;
        timer += Time.deltaTime;
        if (playerStats.HP <= 0)
        {
            death.SetActive(true);
            alive = false;
        }
        if (timer > 0.4)
        {
            anim.SetBool("Hurt", false);
        }
    }

    public void TakeDamage(int damage)
    {
        playerStats.HP -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            anim.SetBool("Hurt", true);
            TakeDamage(enemyDamage.fireBallDamage);
        }
        else if (collision.gameObject.CompareTag("Fist"))
        {

            anim.SetBool("Hurt", true);
            TakeDamage(enemyDamage.fistDamage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            if (timer > 0.5)
            {
                anim.SetBool("Hurt", true);
                TakeDamage(enemyDamage.laserDamage);
                timer = 0;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            if (timer > 0.5)
            {
                anim.SetBool("Hurt", true);
                TakeDamage(enemyDamage.enemyDamage1);
                timer = 0;
            }
        }
        else if (collision.gameObject.CompareTag("Enemy2"))
        {
            if (timer > 0.5)
            {
                anim.SetBool("Hurt", true);
                TakeDamage(enemyDamage.enemyDamage2);
                timer = 0;
            }
        }
        else if (collision.gameObject.CompareTag("Enemy3"))
        {
            if (timer > 0.5)
            {
                anim.SetBool("Hurt", true);
                TakeDamage(enemyDamage.enemyDamage3);
                timer = 0;
            }
        }
        else if (collision.gameObject.CompareTag("Enemy4"))
        {
            if (timer > 0.5)
            {
                anim.SetBool("Hurt", true);
                TakeDamage(enemyDamage.enemyDamage4);
                timer = 0;
            }
        }
        else if (collision.gameObject.CompareTag("Boss1"))
        {
            if (timer > 0.5)
            {
                anim.SetBool("Hurt", true);
                TakeDamage(enemyDamage.bossDamage1);
                timer = 0;
            }
        }
        else if (collision.gameObject.CompareTag("Boss2"))
        {
            if (timer > 0.5)
            {
                anim.SetBool("Hurt", true);
                TakeDamage(enemyDamage.bossDamage2);
                timer = 0;
            }
        }
    }
}
