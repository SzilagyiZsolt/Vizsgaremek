using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkeletonKing : MonoBehaviour
{
    public ClassLoader classLoader;
    public HealthSkeletonKing skeletonKingHealth;
    public int damage;
    public float timer;
    public KnightHealth knightHealth;
    public ArcherHealth archerHealth;
    public KnightMovement knightMovement;
    public ArcherMovement archerMovement;
    private void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        GameObject player = GameObject.FindWithTag("Player");
        if (classLoader.isKnight)
        {
            knightHealth = player.GetComponent<KnightHealth>();
            knightMovement = player.GetComponent<KnightMovement>();
        }
        else
        {
            archerHealth = player.GetComponent<ArcherHealth>();
            archerMovement = player.GetComponent<ArcherMovement>();
        }
        skeletonKingHealth = GetComponent<HealthSkeletonKing>();
        
    }
    private void Update()
    {
        timer+=Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && skeletonKingHealth.skeletonKingalive && timer>=0.5 && classLoader.isKnight)
        {
            timer=0;
            knightMovement.kbCounter = knightMovement.kbTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                knightMovement.knockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                knightMovement.knockFromRight = false;
            }
            knightHealth.TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("Player") && skeletonKingHealth.skeletonKingalive && timer>=0.5 && !classLoader.isKnight)
        {
            timer=0;
            archerMovement.kbCounter = archerMovement.kbTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                archerMovement.knockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                archerMovement.knockFromRight = false;
            }
            archerHealth.TakeDamage(damage);
        }
    }
}