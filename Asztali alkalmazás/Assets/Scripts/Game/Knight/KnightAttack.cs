using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    public float damage;
    public float timer=1;
    public float attackTimer;
    public float spamdef=1;
    public int click=0;
    public float critRate;
    public float critDMG;
    public Collider2D hitbox;
    public KnightHealth knightHealth;
    public KnightMovement knightMovement;
    public HealthExecutioner healthExecutioner;
    public Movement movementExecutioner;
    public Transform attackPoint;
    public AudioManager audioManager;
    public float attackRange = 0.5f;

    private void Start()
    {
        knightHealth = GetComponent<KnightHealth>();
        knightMovement = GetComponent<KnightMovement>();
    }
    void Update()
    {
        if (knightHealth.health>0)
        {
            Attack();
        }
        spamdef += Time.deltaTime;
        if (spamdef>=0.6)
        {
            click = 0;
        }
        attackTimer += Time.deltaTime;
    }
    public void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {   
            knightMovement.anim.SetInteger("Attack", 3);
            if(attackTimer > 0.54)
            {
                audioManager.playSFX(audioManager.knightEffects[1]);
                attackTimer = 0;
            }
        }
        else
        {
            knightMovement.anim.SetInteger("Attack", 0);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Executioner") && knightMovement.alive && timer>=0.5)
        {
            timer=0;
            healthExecutioner.kbCounter = healthExecutioner.kbTotalTime;
        }
    }
}
