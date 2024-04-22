using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MovementSkeleton : MonoBehaviour
{
    public Animator anim;
    public HealthSkeleton skeletonHealth;
    public Transform playerTransform;
    public float moveSpeed;
    public bool chasing;
    private void Start()
    {
        anim = GetComponent<Animator>();
        GameObject player = GameObject.FindWithTag("Player");
        skeletonHealth = GetComponent<HealthSkeleton>();
        playerTransform = player.GetComponent<Transform>();
    }
    private void Update()
    {
        if (skeletonHealth.skeletonalive)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3((float)-0.7, (float)0.7, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                skeletonHealth.anim.SetBool("Walk", true);
            }

            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3((float)0.7, (float)0.7, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                skeletonHealth.anim.SetBool("Walk", true);
            }
        }
        else
        {
            skeletonHealth.anim.SetBool("Walk", false);
        }
    }
}