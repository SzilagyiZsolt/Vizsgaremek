using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public ClassLoader classLoader;
    public Rigidbody2D rb;
    public KnightHealth knightHealth;
    public ArcherHealth archerHealth;
    public MovementBrownSlime brownSlimeMovement;
    public int damage;
    public float speed;
    private void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        GameObject player = GameObject.FindWithTag("Player");
        GameObject brownSlime = GameObject.FindWithTag("BrownSlime");
        rb=GetComponent<Rigidbody2D>();
        if (classLoader.isKnight)
        {
            knightHealth=player.GetComponent<KnightHealth>();
        }
        else
        {
            archerHealth=player.GetComponent<ArcherHealth>();
        }
        brownSlimeMovement=brownSlime.GetComponent<MovementBrownSlime>();
        if (!brownSlimeMovement.rightLook)
        {
            rb.velocity=Vector2.left*speed;
        }
        else
        {
            rb.velocity= Vector2.right*speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (classLoader.isKnight)
            {
                knightHealth.TakeDamage(damage);
            }
            else
            {
                archerHealth.TakeDamage(damage);
            }
        }
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Trigger"))
        {
            Destroy(gameObject);
        }
    }
}
