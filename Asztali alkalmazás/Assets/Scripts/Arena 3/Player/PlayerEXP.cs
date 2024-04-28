using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEXP : MonoBehaviour
{
    public Text LevelText;
    public Slider sliderXP;
    public GameObject lvlUP;
    public int playerEXP;
    public int EXPNeeded;
    public int playerLevel;
    void Update()
    {
        sliderXP.maxValue = EXPNeeded;
        sliderXP.value = playerEXP;
        while (playerEXP >= EXPNeeded)
        {
            playerEXP -= EXPNeeded;
            playerLevel++;
            EXPNeeded += 5;
            LevelText.text = playerLevel.ToString();
            lvlUP.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
