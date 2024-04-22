using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossMovement2 : MonoBehaviour
{
    public BossHealth2 bossHealth;
    public GameObject player;
    public SpriteRenderer sprite;
    public Transform playerTransform;
    public GameObject laserSpawn;
    public bool attacking;
    public float moveSpeed;
    public float timer;
    public bool laserOn=false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        bossHealth = GetComponent<BossHealth2>();
        playerTransform = player.GetComponent<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (bossHealth.alive)
        {
            if (bossHealth.health >= 13)
            {
                if (timer > 10)
                {
                    bossHealth.anim.SetBool("Attack", true);
                    attacking = true;
                    if (timer > 15)
                    {
                        timer = 0;
                    }
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                    bossHealth.anim.SetBool("Attack", false);
                    attacking = false;
                }
            }
            else if (bossHealth.health < 13)
            {
                if (timer > 10 && !attacking)
                {
                    bossHealth.anim.SetBool("Attack2", true);
                    if (timer > 11.1)
                    {
                        laserSpawn.SetActive(true);
                        laserOn = true;
                    }
                    if (timer > 19.1)
                    {
                        timer = 0;
                    }
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                    bossHealth.anim.SetBool("Attack2", false);
                    bossHealth.anim.SetBool("Attack", false);
                    laserSpawn.SetActive(false);
                    laserSpawn.transform.eulerAngles = Vector3.zero;
                    laserOn= false;
                    attacking= false;
                }
            }

            if (!laserOn)
            {
                if (transform.position.x < player.transform.position.x)
                {
                    transform.localScale = new Vector3(10, 10, 0);
                }
                else
                {
                    transform.localScale = new Vector3(-10, 10, 0);
                }
            }
        }
    }
}
