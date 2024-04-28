using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlimeXP : MonoBehaviour
{
    public KnightXP knightXP;
    public ArcherXP archerXP;
    public ClassLoader classLoader;
    public SlimeHealth slimeHealth;
    public SlimeDamage slimeDamage;
    public int slimeXP = 1;
    public int slimeCoin = 1;
    public int slimeLevel = 1;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        if (classLoader.isKnight)
        {
            knightXP = player.GetComponent<KnightXP>();
        }
        else
        {
            archerXP = player.GetComponent<ArcherXP>();
        }
        slimeHealth = GetComponent<SlimeHealth>();
        slimeDamage = GetComponent<SlimeDamage>();
    }

    public void SlimeGiveXP()
    {
        if (!slimeHealth.slimealive && classLoader.isKnight)
        {
            knightXP.playerXP += slimeXP;
        }
        else if (!slimeHealth.slimealive && !classLoader.isKnight)
        {
            archerXP.playerXP += slimeXP;
        }
    }
    public void SlimeGiveGold()
    {
        if (!slimeHealth.slimealive && classLoader.isKnight)
        {
            knightXP.coinAmount += slimeCoin;
            knightXP.coinText.text = knightXP.coinAmount.ToString();
        }
        else if (!slimeHealth.slimealive && !classLoader.isKnight)
        {
            archerXP.coinAmount += slimeCoin;
            archerXP.coinText.text = archerXP.coinAmount.ToString();
        }
    }
}
