using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public ArcherMovement archerMovement;
    public Transform playerTransform;
    public SpriteRenderer arrow;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        arrow = GetComponent<SpriteRenderer>();
        archerMovement = player.GetComponent<ArcherMovement>();
        
    }
    private void Update()
    {
        if (playerTransform.transform.position.x > transform.position.x)
        {
            rb.velocity = Vector3.left * speed;
            arrow.flipX = true;
        }
        else if (playerTransform.transform.position.x < transform.position.x)
        {
            rb.velocity = Vector3.right * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
