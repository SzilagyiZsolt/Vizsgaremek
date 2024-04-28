using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackBrownSlime : MonoBehaviour
{
    public MovementBrownSlime brownSlimeMovement;
    public GameObject projectile;
    public Transform spawnPoint;
    public float timer;
    public float random;

    private void Start()
    {
        random=Random.Range(0.7f, 1.6f);
        brownSlimeMovement=GetComponent<MovementBrownSlime>();
    }
    private void Update()
    {
        if (brownSlimeMovement.chasing==false)
        {
            timer+=Time.deltaTime;
            if (timer > random)
            {
                Spawn();
            }
        }
    }
    public void Spawn()
    {
        random=Random.Range(1, 1.6f);
        Instantiate(projectile, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y-0.05f, 0), transform.rotation);
        timer=0;
    }
}
