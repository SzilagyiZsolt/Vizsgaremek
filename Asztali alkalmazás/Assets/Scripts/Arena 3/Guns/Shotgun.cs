using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public PlayerStats playerStats;
    public BulletSpawner bulletSpawner;
    public GameObject crosshair;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        bulletSpawner = GetComponentInChildren<BulletSpawner>();
    }

    void Update()
    {
        playerStats.firerate += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && playerStats.firerate > 1.5)
        {
            bulletSpawner.Bullet();
            playerStats.firerate = 0;
        }

        if (crosshair.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(0.08f, -0.08f, 1);
        }
        else
        {
            transform.localScale = new Vector3(0.08f, 0.08f, 1);
        }
    }
}
