using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageExecutioner : MonoBehaviour
{
    public ClassLoader classLoader;
    public HealthExecutioner executionerHealth;
    public int damage;
    public float timer;
    public KnightHealth knightHealth;
    public ArcherHealth archerHealth;
    public KnightAttack knightAttack;
    public ArcherAttack archerAttack;
    public KnightMovement knightMovement;
    public ArcherMovement archerMovement;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public Collider2D hitbox;
    public Animator anim;
    private void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        GameObject player = GameObject.FindWithTag("Player");
        executionerHealth = GetComponent<HealthExecutioner>();
        if (classLoader.isKnight)
        {
            knightHealth = player.GetComponent<KnightHealth>();
            knightAttack = player.GetComponent<KnightAttack>();
            knightMovement = player.GetComponent<KnightMovement>();
        }
        else
        {
            archerHealth = player.GetComponent<ArcherHealth>();
            archerAttack = player.GetComponent<ArcherAttack>();
            archerMovement = player.GetComponent<ArcherMovement>();
        }
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer > 0.7)
        {
            anim.SetBool("Skill", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && executionerHealth.executioneralive && timer>=1)
        {
            if (classLoader.isKnight)
            {
                timer=0;
                anim.SetBool("Skill", true);
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
            else
            {
                timer=0;
                anim.SetBool("Skill", true);
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
}