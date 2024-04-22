using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawnerRight : MonoBehaviour
{
    public GameObject laserRight;
    public GameObject laserRightWarning;
    public GameObject[] spawnPoint;
    public SlimeKingDeath slimeKingDeath;
    public int warningRightCount;
    public float timerRight;
    private void Update()
    {
        timerRight+=Time.deltaTime;
        if (slimeKingDeath.slimeKingAlive)
        {
            SpawnEnemyRight();
        }
    }
    public void SpawnEnemyRight()
    {
        if (timerRight >= 8)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                if (warningRightCount < spawnPoint.Length)
                {
                    Instantiate(laserRightWarning, new Vector3(spawnPoint[i].transform.position.x, spawnPoint[i].transform.position.y, 0), transform.rotation);
                    warningRightCount++;
                }
            }
        }
        if (timerRight >= 8.5)
        {
            warningRightCount=0;
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(laserRight, new Vector3(spawnPoint[i].transform.position.x, spawnPoint[i].transform.position.y, 0), transform.rotation);
            }
            timerRight=0;
        }
    }

}
