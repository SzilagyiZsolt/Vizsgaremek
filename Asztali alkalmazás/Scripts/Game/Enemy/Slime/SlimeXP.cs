using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeXP : MonoBehaviour
{
    public CountDown countDown;
    public ClassLoader classLoader;
    public KnightXP knightXP;
    public ArcherXP archerXP;
    public SlimeHealth slimeHealth;
    public SlimeDamage slimeDamage;
    public int slimeXP = 1;
    public int slimeCoin = 1;
    public int slimeLevel=1;
    public float timer;
    public int minutes=10;
    private void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (classLoader.isKnight)
        {
            knightXP=player.GetComponent<KnightXP>();
        }
        else
        {
            archerXP=player.GetComponent<ArcherXP>();
        }
        slimeHealth = GetComponent<SlimeHealth>();
        slimeDamage = GetComponent<SlimeDamage>();
        GameObject count = GameObject.FindWithTag("CountDown");
        countDown = count.GetComponent<CountDown>();
        SlimeLevelUp();
    }

    public void SlimeGiveXP()
    {
        if (!slimeHealth.slimealive && classLoader.isKnight)
        {
            knightXP.playerXP+=slimeXP;
        }
        else if (!slimeHealth.slimealive && !classLoader.isKnight)
        {
            archerXP.playerXP+=slimeXP;
        }
    }
    public void SlimeGiveGold()
    {
        if (!slimeHealth.slimealive && classLoader.isKnight)
        {
            knightXP.coinAmount+=slimeCoin;
            knightXP.coinText.text= knightXP.coinAmount.ToString();
        }
        else if (!slimeHealth.slimealive && !classLoader.isKnight)
        {
            archerXP.coinAmount+=slimeCoin;
            archerXP.coinText.text= archerXP.coinAmount.ToString();
        }
    }
    public void SlimeLevelUp()
    {
        while (countDown.min<minutes)
        {
            slimeLevel++;
            slimeCoin*=slimeLevel;
            switch (slimeLevel)
            {
                case 2:
                    slimeHealth.slimeMaxHealth*=4;
                    break;
                case 3:
                    slimeHealth.slimeMaxHealth*=3;
                    break;
                case 4:
                    slimeHealth.slimeMaxHealth*=2;
                    break;
                case 5:
                    slimeHealth.slimeMaxHealth*=2;
                    break;
            }
            slimeDamage.damage*=slimeLevel;
            minutes--;
        }
    }
}
