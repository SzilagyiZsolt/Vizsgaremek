using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlip : MonoBehaviour
{
    public Transform playerTransform;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    void Update()
    {

        if (transform.position.x > playerTransform.position.x)
        {
            transform.localScale = new Vector3(0.05f, 0.05f, 1);
        }

        if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector3(-0.05f, 0.05f, 1);
        }
    }
}