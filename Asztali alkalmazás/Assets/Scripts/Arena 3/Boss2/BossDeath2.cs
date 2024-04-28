using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BossDeath2 : MonoBehaviour
{
    public BossHealth2 bossHealth;
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public SpriteRenderer expSprite;
    public GameObject canvas;
    public GameObject THEEND;
    public GameObject laser;
    public GameObject pause;
    public GameObject enemySpawner;
    public float timer;
    
    private void Start()
    {
        expSprite = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        bossHealth = GetComponent<BossHealth2>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!bossHealth.alive)
        {
            Destroy(enemySpawner);
            Destroy(boxCollider);
            timer += Time.deltaTime;
            Destroy(canvas);
            Destroy(laser);
            Destroy(pause);
            anim.SetBool("Death", true);
            if (timer > 2)
            {
                THEEND.SetActive(true);
                Destroy(spriteRenderer);
                expSprite.sortingOrder = 2;
            }
        }
    }
}
