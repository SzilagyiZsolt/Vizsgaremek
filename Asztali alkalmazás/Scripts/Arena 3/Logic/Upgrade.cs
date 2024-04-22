using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject lvlUP;
    public int damage;
    public float firerate;
    public int health;
    public int movespeed;
    public Text currentTextDamage;
    public Text currentTextFirerate;
    public Text currentTextHealth;
    public Text currentTextMovespeed;
    public Text newTextDamage;
    public Text newTextFirerate;
    public Text newTextMovespeed;
    public Button ButtonDamage;
    public Button ButtonFirerate;
    public Button ButtonMovespeed;
    public GameObject GameObjectDamage;
    public GameObject GameObjectFirerate;
    public GameObject GameObjectMovespeed;
    public bool isOpen=false;

    private void Update()
    {
        isOpen=true;
        Cursor.visible = true;
        currentTextDamage.text = playerStats.damage.ToString();
        currentTextFirerate.text  = playerStats.firerate.ToString();
        currentTextHealth.text  = playerStats.HP.ToString();
        currentTextMovespeed.text  = playerStats.Speed.ToString();
        if (currentTextDamage.text == 10.ToString())
        {
            newTextDamage.text = "Max";
            newTextDamage.color = Color.red;
            ButtonDamage.interactable = false;
            GameObjectDamage.SetActive(false);
        }
        if (currentTextFirerate.text == 0.6.ToString())
        {
            newTextFirerate.text = "Max";
            newTextFirerate.color = Color.red;
            ButtonFirerate.interactable = false;
            GameObjectFirerate.SetActive(false);
        }
        if (currentTextMovespeed.text == 8.ToString())
        {
            newTextMovespeed.text = "Max";
            newTextMovespeed.color = Color.red;
            ButtonMovespeed.interactable = false;
            GameObjectMovespeed.SetActive(false);
        }
    }

    public void DamageUpgrade()
    {
        isOpen=false;
        playerStats.damage += damage;
        Time.timeScale = 1f;
        lvlUP.SetActive(false);
        Cursor.visible = false;
    }
    public void FirerateUpgrade()
    {
        if(playerStats.firerate == 0.6)
        {

        }
        isOpen = false;
        playerStats.firerate -= firerate;
        Time.timeScale = 1f;
        lvlUP.SetActive(false);
        Cursor.visible = false;
    }
    public void HealthUpgrade()
    {
        isOpen = false;
        playerStats.HP += health;
        Time.timeScale = 1f;
        lvlUP.SetActive(false);
        Cursor.visible = false;
    }
    public void MovespeedUpgrade()
    {
        isOpen = false;
        playerStats.Speed += movespeed;
        Time.timeScale = 1f;
        lvlUP.SetActive(false);
        Cursor.visible = false;
    }
}
