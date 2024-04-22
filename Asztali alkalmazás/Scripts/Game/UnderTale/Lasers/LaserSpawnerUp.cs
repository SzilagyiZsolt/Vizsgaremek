using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawnerUp : MonoBehaviour
{
    public GameObject laserUp;
    public GameObject laserUpWarning;
    public GameObject[] spawnPoint;
    public SlimeKingDeath slimeKingDeath;
    public float timerUp;
    public int warningUpCount;
    void Update()
    {
        timerUp += Time.deltaTime;
        if (slimeKingDeath.slimeKingAlive)
        {
            SpawnEnemyUp();
        }
    }
    public void SpawnEnemyUp()
    {
        if (timerUp >= 5)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                if (warningUpCount<=spawnPoint.Length)
                {
                    Instantiate(laserUpWarning, new Vector3(spawnPoint[i].transform.position.x, spawnPoint[i].transform.position.y, 0), transform.rotation);
                    warningUpCount++;
                }
            }
        }
        if (timerUp >= 5.5)
        {
            warningUpCount=0;
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(laserUp, new Vector3(spawnPoint[i].transform.position.x, spawnPoint[i].transform.position.y, 0), transform.rotation);
            }
            timerUp=0;
        }
    }
}
