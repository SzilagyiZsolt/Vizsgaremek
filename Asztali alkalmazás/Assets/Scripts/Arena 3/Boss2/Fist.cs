using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Fist : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody2D rb;
    public Vector3 direction;
    public int speed;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        direction = playerTransform.position - transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction.x, direction.y-1).normalized * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
