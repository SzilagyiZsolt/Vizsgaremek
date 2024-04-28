using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSkeletonKing : MonoBehaviour
{
    public HealthSkeletonKing skeletonKingHealth;
    public Transform playerTransform;
    public float moveSpeed;
    public bool chasing;
    public int chasingDistanceX;
    public int chasingDistanceY;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        skeletonKingHealth = GetComponent<HealthSkeletonKing>();
        playerTransform = player.GetComponent<Transform>();
    }
    private void Update()
    {
        if (skeletonKingHealth.skeletonKingalive)
        {
            if (chasing)
            {
                if (Vector2.Distance(transform.position, playerTransform.position) > chasingDistanceX)
                {
                    skeletonKingHealth.anim.SetBool("Walk", false);
                    chasing = false;
                }

                if (transform.position.x > playerTransform.position.x)
                {
                    transform.localScale = new Vector3((float)0.3, (float)0.3, 1);
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                }

                if (transform.position.x < playerTransform.position.x)
                {
                    transform.localScale = new Vector3((float)-0.3, (float)0.3, 1);
                    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, playerTransform.position) < chasingDistanceX)
                {
                    skeletonKingHealth.anim.SetBool("Walk", true);
                    chasing = true;
                }
            }
        }
    }
}
