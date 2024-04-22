using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public PlayerStats playerStats;
    public BulletSpawner bulletSpawner;
    public GameObject crosshair;
    public AudioManager audioManager;
    public float timer;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        bulletSpawner = GetComponentInChildren<BulletSpawner>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && timer > playerStats.firerate)
        {
            audioManager.playSFX(audioManager.arena3Effects[1]);
            bulletSpawner.Bullet();
            timer = 0.5f;
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
