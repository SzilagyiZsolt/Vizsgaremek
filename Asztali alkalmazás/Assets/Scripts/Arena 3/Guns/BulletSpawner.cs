using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;

    public void Bullet()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
 }
