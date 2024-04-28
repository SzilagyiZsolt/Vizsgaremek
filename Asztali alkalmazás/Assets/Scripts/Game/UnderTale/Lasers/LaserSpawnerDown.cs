using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawnerDown : MonoBehaviour
{
    public GameObject laserDown;
    public GameObject laserDownWarning;
    public GameObject[] spawnPoint;
    public SlimeKingDeath slimeKingDeath;
    public float timerDown;
    public int warningDownCount;

    void Update()
    {
        timerDown += Time.deltaTime;
        if (slimeKingDeath.slimeKingAlive)
        {
            SpawnEnemyDown();
        }
    }
    public void SpawnEnemyDown()
    {
        if (timerDown >= 4) 
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                if (warningDownCount < spawnPoint.Length)
                {
                    Instantiate(laserDownWarning, new Vector3(spawnPoint[i].transform.position.x, spawnPoint[i].transform.position.y, 0), transform.rotation);
                    warningDownCount++;
                }
            }
        }
        if (timerDown >= 4.5)
        {
            warningDownCount = 0;
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(laserDown, new Vector3(spawnPoint[i].transform.position.x, spawnPoint[i].transform.position.y, 0), transform.rotation);
            }
            timerDown=0;
        }
    }
}
