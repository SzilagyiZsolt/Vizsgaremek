using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class UnderTalePlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public UnderTaleHP underTaleHP;
    public float speed;
    public float horizontal;
    public float vertical;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        underTaleHP = GetComponent<UnderTaleHP>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            vertical = 0;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            vertical = 0;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if (underTaleHP.HP>=0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, vertical*speed);
        }
    }
}
