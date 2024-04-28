using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawnPoint;
    public float timer;
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>3)
        {
            Summon();
        }
    }
    public void Summon()
    {
        Instantiate(enemy, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0), transform.rotation);
        timer=0;
    }
}
