using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRandomMovementUp : MonoBehaviour
{

    public LaserSummonUp laserSummonUp;
    public Rigidbody2D rb;
    public float timer;
    public float speed;
    private void Start()
    {
        GameObject s = GameObject.FindGameObjectWithTag("SpawnPointUp");
        laserSummonUp = s.GetComponent<LaserSummonUp>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer>=1)
        {
            rb.velocity=laserSummonUp.playerDirection*speed;
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

