using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public ClassLoader classLoader;
    public Animator anim;
    public UnderTaleEvent underTaleEvent;
    public KnightMovement knightMovement;
    public ArcherMovement archerMovement;
    public Rigidbody2D rbElevator;
    public bool isOn=false;

    private void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (classLoader.isKnight)
        {
            knightMovement = p.GetComponent<KnightMovement>();
        }
        else
        {
            archerMovement = p.GetComponent<ArcherMovement>();
        }

        anim=p.GetComponent<Animator>();
    }
    private void Update()
    {
        if (isOn)
        {
            rbElevator.velocity = Vector2.up;
        }
        else
        {
            rbElevator.velocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && underTaleEvent.isOn==false && classLoader.isKnight)
        {
            anim.SetBool("Empty", true);
            knightMovement.moveSpeed = 0;
            knightMovement.jumpForce = 0;
            isOn=true;
        }
        else if (collision.gameObject.CompareTag("Player") && underTaleEvent.isOn==false && !classLoader.isKnight)
        {
            anim.SetBool("Empty", true);
            archerMovement.moveSpeed = 0;
            archerMovement.jumpForce = 0;
            isOn=true;
        }
    }
}
