using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public float timer;
    public GameObject clouds;
    void Start()
    {
        SpawnClouds();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 92)
        {
            SpawnClouds();
            timer = 0;
        }
    }
    public void SpawnClouds()
    {
        Instantiate(clouds, new Vector3(transform.position.x, transform.position.y ,0), transform.rotation);
    }
}
