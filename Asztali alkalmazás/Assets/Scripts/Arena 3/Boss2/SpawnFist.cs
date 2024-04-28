using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnFist : MonoBehaviour
{
    public BossMovement2 bossMovement;
    public BossHealth2 bossHealth;
    public GameObject fist;
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
        if (bossMovement.attacking)
        {
            timer += Time.deltaTime;
            if (timer > 1.5 && bossHealth.alive)
            {
                Fist();
            }
        }
    }
    public void Fist()
    {
        playerDirection = playerTransform.position - transform.position;
        playerDirection.Normalize();
        GameObject Fist = Instantiate(fist, transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Fist.transform.rotation = rotation;
        timer = 1.3f;
    }
}
