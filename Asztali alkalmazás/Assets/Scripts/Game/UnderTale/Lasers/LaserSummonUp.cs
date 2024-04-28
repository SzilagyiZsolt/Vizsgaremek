using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSummonUp : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject warningPrefab;
    public SlimeKingDeath slimeKingDeath;
    public float timerUp;
    public Transform player;
    public Vector3 playerDirection;
    private void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        player=p.GetComponent<Transform>();
    }
    void Update()
    {
        timerUp+=Time.deltaTime;
        if (timerUp>6 && slimeKingDeath.slimeKingAlive)
        {
            SummonUp();
        }
    }
    public void SummonUp()
    {
        playerDirection = player.position - transform.position;
        playerDirection.Normalize();
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        GameObject warning = Instantiate(warningPrefab, transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        laser.transform.rotation = rotation;
        warning.transform.rotation = rotation;
        timerUp = 0;
    }
}
