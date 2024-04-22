using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBrownSlime : MonoBehaviour
{
    public HealthBrownSlime brownSlimeHealth;
    public Transform playerTransform;
    public float moveSpeed;
    public bool chasing;
    public int chasingDistanceX;
    public bool rightLook;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        brownSlimeHealth = GetComponent<HealthBrownSlime>();
        playerTransform = player.GetComponent<Transform>();
    }
    private void Update()
    {
        if (brownSlimeHealth.brownSlimealive)
        {
            if (chasing)
            {
                if (Vector2.Distance(transform.position, playerTransform.position) < chasingDistanceX)
                {
                    brownSlimeHealth.anim.SetBool("Move", false);
                    brownSlimeHealth.anim.SetBool("Attack", true);
                    chasing = false;
                }

                if (transform.position.x > playerTransform.position.x)
                {
                    rightLook = false;
                    transform.localScale = new Vector3(5, 5, 1);
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                }

                if (transform.position.x < playerTransform.position.x)
                {
                    rightLook = true;
                    transform.localScale = new Vector3(-5, 5, 1);
                    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, playerTransform.position) > chasingDistanceX)
                {
                    brownSlimeHealth.anim.SetBool("Move", true);
                    brownSlimeHealth.anim.SetBool("Attack", false);
                    chasing = true;
                }
                if (transform.position.x > playerTransform.position.x)
                {
                    rightLook = false;
                    transform.localScale = new Vector3(5, 5, 1);
                }

                if (transform.position.x < playerTransform.position.x)
                {
                    rightLook = true;
                    transform.localScale = new Vector3(-5, 5, 1);
                }
            }
        }
    }
}
