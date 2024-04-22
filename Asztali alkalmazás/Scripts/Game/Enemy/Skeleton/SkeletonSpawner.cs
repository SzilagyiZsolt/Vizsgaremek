using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    public GameObject skeletons;
    public GameObject trigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            skeletons.SetActive(true);
            trigger.SetActive(false);
        }
    }
}
