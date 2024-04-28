using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip2 : MonoBehaviour
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
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }

        if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
    }
}