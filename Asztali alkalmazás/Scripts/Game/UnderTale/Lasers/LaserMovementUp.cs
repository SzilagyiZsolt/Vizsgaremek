using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovementUp : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity= Vector2.up*speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
    }
}
