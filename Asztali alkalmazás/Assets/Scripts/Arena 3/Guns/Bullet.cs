using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform crosshairTransform;
    public Rigidbody2D rb;
    public Vector3 direction;
    public int speed;
    void Start()
    {
        GameObject crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        crosshairTransform = crosshair.GetComponent<Transform>();
        direction = crosshairTransform.position - transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Enemy2") || collision.gameObject.CompareTag("Boss1") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy3") || collision.gameObject.CompareTag("Enemy4") || collision.gameObject.CompareTag("Boss2"))
        {
            Destroy(gameObject);
        }
    }
}
