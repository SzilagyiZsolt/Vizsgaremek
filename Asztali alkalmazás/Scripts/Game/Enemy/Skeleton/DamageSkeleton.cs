using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkeleton : MonoBehaviour
{
    public ClassLoader classLoader;
    public KnightHealth knightHealth;
    public ArcherHealth archerHealth;
    public KnightMovement knightMovement;
    public ArcherMovement archerMovement;
    public HealthSkeleton skeletonHealth;
    public float damage;
    public float timer;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        skeletonHealth = GetComponent<HealthSkeleton>();
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
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
        
    }
    private void Update()
    {
        timer+=Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && skeletonHealth.skeletonalive && timer>=0.5 && classLoader.isKnight)
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
        else if (collision.gameObject.CompareTag("Player") && skeletonHealth.skeletonalive && timer>=0.5 && !classLoader.isKnight)
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