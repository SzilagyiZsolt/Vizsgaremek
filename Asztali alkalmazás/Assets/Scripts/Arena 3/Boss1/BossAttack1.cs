using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossAttack1 : MonoBehaviour
{
    public BossMovement1 bossMovement;
    public GameObject projectile;
    public Transform spawnPoint;
    public BossHealth1 bossHealth;
    public float timer; 
    private void Start()
    {
        bossMovement=GetComponent<BossMovement1>();
    }
    //private void Update()
    //{
    //    if (!bossMovement.chasing)
    //    {
    //        timer+=Time.deltaTime;
    //        if (timer > 1 && bossHealth.alive)
    //        {
    //            Spawn();
    //        }
    //    }
    //}
    public void Spawn()
    {
        Instantiate(projectile, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0), transform.rotation);
        timer=0;
    }
}
