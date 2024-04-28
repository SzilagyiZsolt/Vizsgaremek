using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawnPoint;
    public CountDown countDown;
    public float timer;
    private void Update()
    {
        timer+=Time.deltaTime;
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        if (timer >= 2.5 && countDown.countDown>=1)
        {
            Instantiate(enemy, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0), transform.rotation);
            timer=0;
        }
    }
}
