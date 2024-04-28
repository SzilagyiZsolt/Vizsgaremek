using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnFireBall : MonoBehaviour
{
    public BossMovement1 bossMovement;
    public BossHealth1 bossHealth;
    public GameObject fireBall;
    public GamePause pause;
    public Upgrade upgrade;
    public Transform playerTransform;
    public Vector3 playerDirection;
    public float timer;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    private void Update()
    {
        if (!bossMovement.chasing)
        {
            timer += Time.deltaTime;
            if (timer > 0.2 && bossHealth.alive && !pause.disable && !upgrade.isOpen)
            {
                FireBall();
            }
        }
        
    }
    public void FireBall()
    {
        playerDirection = playerTransform.position - transform.position;
        playerDirection.Normalize();
        GameObject fireball = Instantiate(fireBall, transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        fireball.transform.rotation = rotation;
        if (bossHealth.health>100)
        {
            timer = 0;
        }
    }

}
