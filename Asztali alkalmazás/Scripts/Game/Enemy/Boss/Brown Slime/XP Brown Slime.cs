using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XPBrownSlime : MonoBehaviour
{
    public ClassLoader classLoader;
    public KnightXP knightXP;
    public ArcherXP archerXP;
    public HealthBrownSlime brownSlimeHealth;
    public DamageBrownSlime brownSlimeDamage;
    public SaveManager saveManager;
    public int brownSlimeCoin;
    public int brownSlimeLevel;
    public int counter;
    private void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        GameObject player = GameObject.FindWithTag("Player");
        if (classLoader.isKnight)
        {
            knightXP=player.GetComponent<KnightXP>();
        }
        else
        {
            archerXP=player.GetComponent<ArcherXP>();
        }
        brownSlimeHealth = GetComponent<HealthBrownSlime>();
        brownSlimeDamage = GetComponent<DamageBrownSlime>();
        GameObject save = GameObject.FindWithTag("SaveManager");
        saveManager=save.GetComponent<SaveManager>();
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}SecretBossBrownSlime.dat"))
        {
            saveManager.loadBrownSlime();
        }
        brownSlimeCoin*=brownSlimeLevel;
        brownSlimeHealth.brownSlimeMaxHealth*=brownSlimeLevel;
        brownSlimeDamage.damage*=brownSlimeLevel;
    }
    public void BrownSlimeGiveGold()
    {
        if (!brownSlimeHealth.brownSlimealive && classLoader.isKnight)
        {
            knightXP.coinAmount+=brownSlimeCoin;
            knightXP.coinText.text= knightXP.coinAmount.ToString();
            brownSlimeLevel++;
            saveManager.saveBrownSlime();
        }
        else if(!brownSlimeHealth.brownSlimealive && !classLoader.isKnight)
        {
            archerXP.coinAmount+=brownSlimeCoin;
            archerXP.coinText.text= archerXP.coinAmount.ToString();
            brownSlimeLevel++;
            saveManager.saveBrownSlime();
        }
    }
}
