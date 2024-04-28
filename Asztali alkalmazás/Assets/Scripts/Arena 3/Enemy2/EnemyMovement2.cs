using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    public EnemyHealth2 enemyHealth;
    public GameObject player;
    public SpriteRenderer sprite;
    public float moveSpeed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        enemyHealth = GetComponent<EnemyHealth2>();
    }

    void Update()
    {
        if (enemyHealth.alive)
        {
            if (transform.position.x < player.transform.position.x)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }

    }
}
