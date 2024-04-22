using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossDeath1 : MonoBehaviour
{
    public BossHealth1 bossHealth;
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public GameObject canvas;
    public GameObject count;
    public Transform chest;
    public float timer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        bossHealth = GetComponent<BossHealth1>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!bossHealth.alive)
        {
            Destroy(boxCollider);
            timer += Time.deltaTime;
            Destroy(canvas);
            anim.SetBool("Death", true);
            if (timer > 2)
            {
                count.SetActive(true);
                chest.position = new Vector2(transform.position.x, transform.position.y);
                Destroy(gameObject);
            }
        }
    }
}
