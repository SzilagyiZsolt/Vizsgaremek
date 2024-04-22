using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBrownSlime : MonoBehaviour
{
    public ClassLoader classLoader;
    public HealthBrownSlime brownSlimeHealth;
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
        brownSlimeHealth = GetComponent<HealthBrownSlime>();
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
        if (collision.gameObject.CompareTag("Player") && brownSlimeHealth.brownSlimealive && timer>=0.5 && classLoader.isKnight)
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
        else if (collision.gameObject.CompareTag("Player") && brownSlimeHealth.brownSlimealive && timer>=0.5 && !classLoader.isKnight)
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
