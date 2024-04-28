using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XPSkeletonKing : MonoBehaviour
{
    public ClassLoader classLoader;
    public KnightXP knightXP;
    public ArcherXP archerXP;
    public HealthSkeletonKing healthSkeletonKing;
    public DamageSkeletonKing damageSkeletonKing;
    public SaveManager saveManager;
    public int skeletonKingCoin;
    public int skeletonKingLevel;
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
        healthSkeletonKing = GetComponent<HealthSkeletonKing>();
        damageSkeletonKing = GetComponent<DamageSkeletonKing>();
        GameObject save = GameObject.FindWithTag("SaveManager");
        saveManager=save.GetComponent<SaveManager>();
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}SecretBossSkeletonKing.dat"))
        {
            saveManager.loadSkeletonKing();
        }
        skeletonKingCoin*=skeletonKingLevel;
        healthSkeletonKing.skeletonKingMaxHealth*=skeletonKingLevel;
        damageSkeletonKing.damage*=skeletonKingLevel;
    }
    public void SkeletonKingGiveGold()
    {
        if (!healthSkeletonKing.skeletonKingalive && classLoader.isKnight)
        {
            knightXP.coinAmount+=skeletonKingCoin;
            knightXP.coinText.text= knightXP.coinAmount.ToString();
            skeletonKingLevel++;
            saveManager.saveSkeletonKing();
        }
        else if(!healthSkeletonKing.skeletonKingalive && !classLoader.isKnight)
        {
            archerXP.coinAmount+=skeletonKingCoin;
            archerXP.coinText.text= archerXP.coinAmount.ToString();
            skeletonKingLevel++;
            saveManager.saveSkeletonKing();
        }
    }
}