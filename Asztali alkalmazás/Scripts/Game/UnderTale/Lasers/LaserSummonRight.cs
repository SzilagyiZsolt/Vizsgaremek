using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSummonRight : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject warningPrefab;
    public SlimeKingDeath slimeKingDeath;
    public float timerRight;
    public Transform player;
    public Vector3 playerDirection;
    private void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        player=p.GetComponent<Transform>();
    }
    void Update()
    {
        timerRight+=Time.deltaTime;
        if (timerRight>4 && slimeKingDeath.slimeKingAlive)
        {
            SummonRight();
        }
    }
    public void SummonRight()
    {
        playerDirection = player.position - transform.position;
        playerDirection.Normalize();
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        GameObject warning = Instantiate(warningPrefab, transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x)*Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        laser.transform.rotation = rotation;
        warning.transform.rotation = rotation;
        timerRight=0;
    }
}
