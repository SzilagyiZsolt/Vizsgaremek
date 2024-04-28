using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth4 : MonoBehaviour
{
    public PlayerStats playerStats;
    public Animator anim;
    public Slider hpbar;
    public float health;
    public bool alive = true;
    private float timer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        hpbar = GetComponentInChildren<Slider>();
        hpbar.maxValue = health;
    }
    void Update()
    {
        hpbar.value = health;
        if (health <= 0)
        {
            alive = false;
        }
        timer += Time.deltaTime;
        if (timer > 0.3)
        {
            anim.SetBool("Hurt", false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            anim.SetBool("Hurt", true);
            TakeDamage(playerStats.damage);
            timer = 0;
        }
    }
}
