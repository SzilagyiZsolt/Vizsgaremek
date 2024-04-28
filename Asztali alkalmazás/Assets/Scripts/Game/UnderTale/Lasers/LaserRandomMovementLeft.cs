using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LaserRandomMovementLeft : MonoBehaviour
{

    public LaserSummonLeft laserSummonLeft;
    public Rigidbody2D rb;
    public float speed;
    public float timer;
    private void Start()
    {
        GameObject s = GameObject.FindGameObjectWithTag("SpawnPointLeft");
        laserSummonLeft = s.GetComponent<LaserSummonLeft>();
    }
    private void Update()
    {
        timer +=Time.deltaTime;
        if (timer > 1)
        {
            rb.velocity=laserSummonLeft.playerDirection*speed;
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
