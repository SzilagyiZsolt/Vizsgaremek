using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    public GameObject boss1;
    public GameObject boss2;
    public GameObject[] enemy;
    public GameObject count;
    public CountDownArena3 countDown;
    public float timer;
    public int randomLeft;
    public int randomRight;
    public int randomUp;
    public int randomDown;
    public int randomDownEnemy;
    public int randomUpEnemy;
    public int randomRightEnemy;
    public int randomLeftEnemy;
    public bool boss1Spawned=false;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > countDown.min+1)
        {
            Left();
            Right();
            Up();
            Down();
        }
        if(countDown.countDown < 300 && !boss1Spawned)
        {
            boss1.SetActive(true);
            count.SetActive(false);
            boss1Spawned= true;
        }
        if (countDown.countDown < 1)
        {
            boss2.SetActive(true);
        }
    }

    public void Left()
    {
        randomLeftEnemy = Random.Range(0, 4);
        randomLeft = Random.Range(12, -12);
        Instantiate(enemy[randomLeftEnemy], new Vector3(-23, randomLeft, 0), transform.rotation);
        timer = 0;
    }
    public void Right()
    {
        randomRightEnemy = Random.Range(0, 4);
        randomRight= Random.Range(12, -12);
        Instantiate(enemy[randomRightEnemy], new Vector3(23, randomRight, 0), transform.rotation);
    }
    public void Up()
    {
        randomUpEnemy = Random.Range(0, 4);
        randomUp = Random.Range(21, -21);
        Instantiate(enemy[randomUpEnemy], new Vector3(randomUp, 14, 0), transform.rotation);
    }
    public void Down()
    {
        randomDownEnemy = Random.Range(0, 4);
        randomDown = Random.Range(21, -21);
        Instantiate(enemy[randomDownEnemy], new Vector3(randomDown, -14, 0), transform.rotation);
    }
}
