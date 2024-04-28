using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrow;
    public void SpawnArrow()
    {
        Instantiate(arrow, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
