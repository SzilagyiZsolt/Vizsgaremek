using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRandomMovementDown : MonoBehaviour
{

    public LaserSummonDown laserSummonDown;
    public Rigidbody2D rb;
    public float timer;
    public float speed;
    private void Start()
    {
        GameObject s = GameObject.FindGameObjectWithTag("SpawnPointDown");
        laserSummonDown = s.GetComponent<LaserSummonDown>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer>=1)
        {
            rb.velocity=laserSummonDown.playerDirection*speed;
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

