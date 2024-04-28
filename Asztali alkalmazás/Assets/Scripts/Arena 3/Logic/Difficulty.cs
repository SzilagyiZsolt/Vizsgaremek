using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Difficulty : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject spawner;
    public bool isOpen;

    void Start()
    {
        isOpen = true;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void Normal()
    {
        Destroy(spawner);
        playerStats.damage = 2;
        playerStats.firerate = 1;
        isOpen = false;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void Hard()
    {
        playerStats.Speed = 6;
        isOpen = false;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
