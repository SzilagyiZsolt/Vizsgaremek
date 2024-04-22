using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherHealth : MonoBehaviour
{
    public Slider HP;
    public ArcherMovement archerMovement;
    public DamageExecutioner damageExecutioner;
    public GameObject skill;
    public GameObject death;
    public SpriteRenderer skillSprite;
    public Color skillColor;
    public float timer;
    public float timer2;
    public float health;
    public float maxHealth;
    public float manaRegen;
    public float hpRegen;
    void Start()
    {
        archerMovement = GetComponent<ArcherMovement>();
    }
    private void Update()
    {
        timer2 += Time.deltaTime;
        if (health <= 0)
        {
            death.SetActive(true);
        }
        if (timer2 < 1)
        {
            health=maxHealth;
        }
        HP.maxValue=maxHealth;
        HP.value=health;
        timer += Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        timer = 0;
    }
}
