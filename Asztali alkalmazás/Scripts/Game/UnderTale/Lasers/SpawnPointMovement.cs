using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnPointMovement : MonoBehaviour
{
    public Rigidbody2D rbLeft;
    public Rigidbody2D rbRight;
    public Rigidbody2D rbDown;
    public Rigidbody2D rbUp;
    public Transform transformLeft;
    public Transform transformRight;
    public Transform transformDown;
    public Transform transformUp;
    public int speed;
    public Vector2 directionVerticalLeft;
    public Vector2 directionVerticalRight;
    public Vector2 directionHorizontalUp;
    public Vector2 directionHorizontalDown;
    void Update()
    {
        SpawnerLeft();
        SpawnerRight();
        SpawnerUp();
        SpawnerDown();
    }
    public void SpawnerLeft()
    {
        if (transformLeft.position.y>=-3.8 && transformLeft.position.y<=0)
        {
            directionVerticalLeft.y=-1;
        }
        else if (transformLeft.position.y<=-8.8 && transformLeft.position.y >= -10)
        {
            directionVerticalLeft.y=1;
        }
        rbLeft.velocity = directionVerticalLeft;
    }
    public void SpawnerRight()
    {
        if (transformRight.position.y<=-8.8 && transformRight.position.y>=-10)
        {
            directionVerticalRight.y=1;
        }
        else if (transformRight.position.y>=-4 && transformRight.position.y <= 0)
        {
            directionVerticalRight.y=-1;
        }
        rbRight.velocity = directionVerticalRight;
    }
    public void SpawnerUp()
    {
        if (transformUp.position.x>=6 && transformUp.position.x<=7)
        {
            directionHorizontalUp.x=-1;
        }
        else if (transformUp.position.x<=-5.6 && transformUp.position.x >= -6)
        {
            directionHorizontalUp.x=1;
        }
        rbUp.velocity = directionHorizontalUp;
    }
    public void SpawnerDown()
    {
        if (transformDown.position.x>=6 && transformDown.position.x<=7)
        {
            directionHorizontalDown.x=-1;
        }
        else if (transformDown.position.x<=-5.6 && transformDown.position.x >= -6)
        {
            directionHorizontalDown.x=1;
        }
        rbDown.velocity = directionHorizontalDown;
    }
}
