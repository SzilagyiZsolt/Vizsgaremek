using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public ClassLoader classLoader;
    public Animator anim;
    public HealthExecutioner healthExecutioner;
    public Transform playerTransform;
    public KnightHealth knightHealth;
    public ArcherHealth archerHealth;
    public DamageExecutioner damageExecutioner;
    public KnightMovement knightMovement;
    public ArcherMovement archerMovement;
    public GameObject player;
    public float moveSpeed;
    public bool chasing;
    public bool inrange=false;
    public float attackRange;
    public int chasingDistance;
    public float timer;
    private void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        anim = GetComponent<Animator>();
        GameObject Player = GameObject.FindWithTag("Player");
        if (classLoader.isKnight)
        {
            knightHealth=Player.GetComponent<KnightHealth>();
            knightMovement = Player.GetComponent<KnightMovement>();
        }
        else
        {
            archerHealth = Player.GetComponent<ArcherHealth>();
            archerMovement = Player.GetComponent<ArcherMovement>();
        }
        healthExecutioner = GetComponent<HealthExecutioner>();
        damageExecutioner = GetComponent<DamageExecutioner>();
        playerTransform = Player.GetComponent<Transform>();
    }
    private void Update()
    {
        if (healthExecutioner.executioneralive)
        {
                if (inrange)
                {
                    anim.SetBool("Attack", true);
                    timer+=Time.deltaTime;
                    if (timer > 0.35)
                    {
                        if (classLoader.isKnight)
                        {
                            knightHealth.TakeDamage(damageExecutioner.damage);
                            knightMovement.kbCounter = knightMovement.kbTotalTime;
                            if (player.transform.position.x <= transform.position.x)
                            {
                                knightMovement.knockFromRight = true;
                            }
                            if (player.transform.position.x >= transform.position.x)
                            {
                                knightMovement.knockFromRight = false;
                            }
                            timer=0;
                        }
                        else
                        {
                            archerHealth.TakeDamage(damageExecutioner.damage);
                            archerMovement.kbCounter = archerMovement.kbTotalTime;
                            if (player.transform.position.x <= transform.position.x)
                            {
                                archerMovement.knockFromRight = true;
                            }
                            if (player.transform.position.x >= transform.position.x)
                            {
                                archerMovement.knockFromRight = false;
                            }
                            timer=0;
                        }
                    }
                    if (Vector2.Distance(transform.position, playerTransform.position) > attackRange)
                    {
                        inrange = false;
                    }
                }
                else
                {
                    if (Vector2.Distance(transform.position, playerTransform.position) < attackRange)
                    {
                        inrange = true;
                    }
                    anim.SetBool("Attack", false);
                }
                if (chasing && !inrange)
                {
                    if (Vector2.Distance(transform.position, playerTransform.position) > chasingDistance)
                    {
                        chasing = false;
                    }

                    if (transform.position.x > playerTransform.position.x)
                    {
                        transform.localScale = new Vector3(-1.3f, 1.3f, 1);
                        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                    }

                    if (transform.position.x < playerTransform.position.x)
                    {
                        transform.localScale = new Vector3(1.3f, 1.3f, 1);
                        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                    }
                }
                else
                {
                    if (Vector2.Distance(transform.position, playerTransform.position) < chasingDistance)
                    {
                        chasing = true;
                    }
                }
            }
        }
    }