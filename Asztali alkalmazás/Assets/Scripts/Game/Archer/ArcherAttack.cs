using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherAttack : MonoBehaviour
{
    public bool skillActive = false;
    public float damage;
    public float timer=1;
    public float timer2;
    public float attackSpeed;
    public float critRate;
    public float critDMG;
    public float animwait;
    public float attackTimer;
    public float mana;
    public float maxMana;
    public float rapidFire;
    public Slider Mana;
    public ArcherHealth archerHealth;
    public ArcherMovement archerMovement;
    public HealthExecutioner healthExecutioner;
    public ArrowSpawner arrowSpawner;
    public AudioManager audioManager;


    private void Start()
    {
        archerHealth = GetComponent<ArcherHealth>();
        archerMovement = GetComponent<ArcherMovement>();
    }
    void Update()
    {
        timer2 += Time.deltaTime;
        attackSpeed+=Time.deltaTime;
        if (attackSpeed>=0.5)
        {
            Attack();
        }
        if (timer2 < 1)
        {
            mana = maxMana;
        }
        Mana.maxValue = maxMana;
        Mana.value = mana;
        if (skillActive && mana > 0 && archerHealth.health > 0)
        {
            mana -= rapidFire * Time.deltaTime;
        }
        else
        {
            skillActive = false;
        }
        ManaUsage();
    }
    public void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !archerMovement.anim.GetBool("Run"))
        {
            animwait += Time.deltaTime;
            archerMovement.anim.SetBool("Attack", true);
            if (animwait >= 0.75)
            {
                
                audioManager.playSFX(audioManager.archerEffects[1]);
                arrowSpawner.SpawnArrow();
                if (skillActive)
                {
                    animwait = 0.5f;
                }
                else
                {
                    animwait = 0;
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            archerMovement.anim.SetBool("Attack", false);
            attackSpeed = 0;
            animwait = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Executioner") && archerMovement.alive && timer>=0.5)
        {
            timer=0;
            healthExecutioner.kbCounter = healthExecutioner.kbTotalTime;
        }
    }
    public void ManaUsage()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !skillActive)
        {
            skillActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && skillActive)
        {
            skillActive = false;
        }
    }
}
