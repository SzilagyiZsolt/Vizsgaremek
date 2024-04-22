using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class SlimeMovement : MonoBehaviour
{
    public SlimeHealth slimeHealth;
    public Transform playerTransform;
    public float moveSpeed;
    public bool chasing;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        slimeHealth = GetComponent<SlimeHealth>();
        playerTransform = player.GetComponent<Transform>();
    }
    private void Update()
    {
        if (slimeHealth.slimealive)
        {
            if (transform.position.x >playerTransform.position.x)
            {
                transform.localScale = new Vector3((float)0.25, (float)0.4, 1);
                transform.position += Vector3.left*moveSpeed*Time.deltaTime;
            }

            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3((float)-0.25, (float)0.4, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
    }
}
