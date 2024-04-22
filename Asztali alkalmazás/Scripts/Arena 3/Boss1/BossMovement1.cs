using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossMovement1 : MonoBehaviour
{
    public BossHealth1 bossHealth;
    public GameObject player;
    public SpriteRenderer sprite;
    public Transform playerTransform;
    public int chasingDistance;
    public bool chasing;
    public float moveSpeed;
    public float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        bossHealth = GetComponent<BossHealth1>();
        playerTransform = player.GetComponent<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (bossHealth.alive)
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chasingDistance)
            {
                bossHealth.anim.SetBool("Attack", true);
                chasing = false;
                timer = 0;
            }
            else
            {
                if (Vector2.Distance(transform.position, playerTransform.position) > chasingDistance)
                {
                    
                    if (timer > 1)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                    }
                    bossHealth.anim.SetBool("Attack", false);
                    chasing = true;
                }
            }

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
