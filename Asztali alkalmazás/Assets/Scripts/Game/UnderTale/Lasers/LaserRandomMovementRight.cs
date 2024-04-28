using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRandomMovementRight : MonoBehaviour
{

    public LaserSummonRight laserSummonRight;
    public Rigidbody2D rb;
    public float timer;
    public float speed;
    private void Start()
    {
        GameObject s = GameObject.FindGameObjectWithTag("SpawnPointRight");
        laserSummonRight = s.GetComponent<LaserSummonRight>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer>=1)
        {
            rb.velocity=laserSummonRight.playerDirection*speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
    }
}

